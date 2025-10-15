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

        static int shield = 100;
        static int lives = 3;

        static void Main(string[] args)
        {



            ShowHUD();

            TakeDamage(10);

            RegenerateShield(10);

            TakeDamage(110);

            Heal(10);

            TakeDamage(100);

            

            void ShowHUD()
            {
                if (health >= 100)
                {
                    
                }
                else if (health <= 99)
                {
                    
                }
                else if (health <= 75)
                {
                    
                }
                else if (health <= 50)
                {
                    
                }
                else if (health <= 10)
                {
                    
                }

                Console.WriteLine("Player");
                Console.Write("Health:" + health);
                Console.Write(" Shield:" + shield);
                Console.WriteLine(" Lives:" + lives);
                Console.Write("Health Status:" + healthStatus[0]);

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
                }

            }

        }

    }

  }
