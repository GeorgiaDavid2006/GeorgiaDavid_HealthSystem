using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace GeorgiaDavid_HealthSystem
{
    internal class Program
    {
        static int health = 100;
        static string[] healthStatus = { "Perfect Health", "Healthy", "Hurt", "Badly Hurt", "Imminent Danger" };
        static int currentHealthStatus;

        static int shield = 100;
        static int lives = 3;
        static int XP = 0;
        static int level = 1;

        static void Main(string[] args)
        {

            UnitTestHealthSystem();
            UnitTestXPSystem();

            ShowHUD();

            TakeDamage(10);

            IncreaseXP(15);

            RegenerateShield(10);

            TakeDamage(110);

            Heal(10);

            TakeDamage(100);

            void ShowHUD()
            {
                if (health >= 100)
                {
                    currentHealthStatus = 0;
                }
                else if (health <= 99 && health > 75)
                {
                    currentHealthStatus = 1;
                }
                else if (health <= 75 && health > 50)
                {
                    currentHealthStatus = 2;
                }
                else if (health <= 50 && health > 10)
                {
                    currentHealthStatus = 3;
                }
                else if (health <= 10)
                {
                    currentHealthStatus = 4;
                }
                

                Console.WriteLine("Player");
                Console.Write("Health:" + health);
                Console.Write(" Shield:" + shield);
                Console.Write(" Lives:" + lives);
                Console.Write(" XP:" + XP);
                Console.WriteLine(" Level:" + level);
                Console.Write("Health Status:" + healthStatus[currentHealthStatus]);

                Console.ReadKey();
                Console.Clear();
            }

            void TakeDamage(int damage)
            {
                Console.WriteLine("You took " + damage + " damage!");
                Console.ReadKey();
                Console.Clear();

                if(damage > shield)
                {
                    int newDamage = damage - shield;

                    shield = 0;

                    health = health - newDamage;
                }
                else
                {
                    shield = shield - damage;
                }

                if(health <= 0)
                {
                    Revive();
                }
                else
                {
                    ShowHUD();
                }
                    
            }

            void Heal(int hp)
            {
                Console.WriteLine("You gained " + hp + " health!");
                Console.ReadKey();
                Console.Clear();

                health = health + hp;

                ShowHUD();
            }

            void RegenerateShield(int hp)
            {
                Console.WriteLine("You gained " + hp + " shield points!");
                Console.ReadKey();
                Console.Clear();

                shield = shield + hp;

                ShowHUD();
            }

            void Revive()
            {
                if(lives > 0)
                {
                    Console.WriteLine("You died!");
                    Console.ReadKey();
                    Console.Clear();

                    health = 100;
                    shield = 100;
                    lives = lives - 1;

                    ShowHUD();
                }
                else
                {
                    Console.WriteLine("Game Over!");
                    Console.ReadKey();
                    Console.Clear();

                    health = 100;
                    shield = 100;
                    lives = 3;

                    ShowHUD();
                }

            }

            void IncreaseXP(int exp)
            {
                Console.WriteLine("You defeated an enemy!");
                Console.Write("You gained " + exp + " XP");
                Console.ReadKey();
                Console.Clear();

                XP = XP + exp;

                ShowHUD();
            }

        }
        static void UnitTestHealthSystem()
        {
            Debug.WriteLine("Unit testing Health System started...");

            // TakeDamage()

            // TakeDamage() - only shield
            shield = 100;
            health = 100;
            lives = 3;
            TakeDamage(10);
            Debug.Assert(shield == 90);
            Debug.Assert(health == 100);
            Debug.Assert(lives == 3);

            // TakeDamage() - shield and health
            shield = 10;
            health = 100;
            lives = 3;
            TakeDamage(50);
            Debug.Assert(shield == 0);
            Debug.Assert(health == 60);
            Debug.Assert(lives == 3);

            // TakeDamage() - only health
            shield = 0;
            health = 50;
            lives = 3;
            TakeDamage(10);
            Debug.Assert(shield == 0);
            Debug.Assert(health == 40);
            Debug.Assert(lives == 3);

            // TakeDamage() - health and lives
            shield = 0;
            health = 10;
            lives = 3;
            TakeDamage(25);
            Debug.Assert(shield == 0);
            Debug.Assert(health == 0);
            Debug.Assert(lives == 3);

            // TakeDamage() - shield, health, and lives
            shield = 5;
            health = 100;
            lives = 3;
            TakeDamage(110);
            Debug.Assert(shield == 0);
            Debug.Assert(health == 0);
            Debug.Assert(lives == 3);

            // TakeDamage() - negative input
            shield = 50;
            health = 50;
            lives = 3;
            TakeDamage(-10);
            Debug.Assert(shield == 50);
            Debug.Assert(health == 50);
            Debug.Assert(lives == 3);

            // Heal()

            // Heal() - normal
            shield = 0;
            health = 90;
            lives = 3;
            Heal(5);
            Debug.Assert(shield == 0);
            Debug.Assert(health == 95);
            Debug.Assert(lives == 3);

            // Heal() - already max health
            shield = 90;
            health = 100;
            lives = 3;
            Heal(5);
            Debug.Assert(shield == 90);
            Debug.Assert(health == 100);
            Debug.Assert(lives == 3);

            // Heal() - negative input
            shield = 50;
            health = 50;
            lives = 3;
            Heal(-10);
            Debug.Assert(shield == 50);
            Debug.Assert(health == 50);
            Debug.Assert(lives == 3);

            // RegenerateShield()

            // RegenerateShield() - normal
            shield = 50;
            health = 100;
            lives = 3;
            RegenerateShield(10);
            Debug.Assert(shield == 60);
            Debug.Assert(health == 100);
            Debug.Assert(lives == 3);

            // RegenerateShield() - already max shield
            shield = 100;
            health = 100;
            lives = 3;
            RegenerateShield(10);
            Debug.Assert(shield == 100);
            Debug.Assert(health == 100);
            Debug.Assert(lives == 3);

            // RegenerateShield() - negative input
            shield = 50;
            health = 50;
            lives = 3;
            RegenerateShield(-10);
            Debug.Assert(shield == 50);
            Debug.Assert(health == 50);
            Debug.Assert(lives == 3);

            // Revive()

            // Revive()
            shield = 0;
            health = 0;
            lives = 2;
            Revive();
            Debug.Assert(shield == 100);
            Debug.Assert(health == 100);
            Debug.Assert(lives == 1);

            Debug.WriteLine("Unit testing Health System completed.");
            Console.Clear();
        }

        static void UnitTestXPSystem()
        {
            Debug.WriteLine("Unit testing XP / Level Up System started...");

            // IncreaseXP()

            // IncreaseXP() - no level up; remain at level 1
            xp = 0;
            level = 1;
            IncreaseXP(10);
            Debug.Assert(xp == 10);
            Debug.Assert(level == 1);

            // IncreaseXP() - level up to level 2 (costs 100 xp)
            xp = 0;
            level = 1;
            IncreaseXP(105);
            Debug.Assert(xp == 5);
            Debug.Assert(level == 2);

            // IncreaseXP() - level up to level 3 (costs 200 xp)
            xp = 0;
            level = 2;
            IncreaseXP(210);
            Debug.Assert(xp == 10);
            Debug.Assert(level == 3);

            // IncreaseXP() - level up to level 4 (costs 300 xp)
            xp = 0;
            level = 3;
            IncreaseXP(315);
            Debug.Assert(xp == 15);
            Debug.Assert(level == 4);

            // IncreaseXP() - level up to level 5 (costs 400 xp)
            xp = 0;
            level = 4;
            IncreaseXP(499);
            Debug.Assert(xp == 99);
            Debug.Assert(level == 5);

            Debug.WriteLine("Unit testing XP / Level Up System completed.");
            Console.Clear();
        }

    }

  }
