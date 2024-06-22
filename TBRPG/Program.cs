using System;

namespace TBRPG
{
    class Program
    {
        static void Main(string[] args)
        {
            Unit player = new Unit(100, 20, 12, "Player");
            Unit enemy = new Unit(75, 10, 7, "Enemy Goblin");
            Random random = new Random();

            while (!player.IsDead && !enemy.IsDead)
            {
                Console.WriteLine(player.UnitName + " HP = " + player.Hp + ". " + enemy.UnitName + " HP = " + enemy.Hp);
                Console.WriteLine("Player Turn! What will you do?");
                Console.WriteLine("Press 'a' to attack and 'h' to heal!");
                string choice = Console.ReadLine();

                if (choice == "a")
                {
                    player.Attack(enemy);
                }
                else if(choice == "h")
                {
                    player.Heal();
                }
                else {
                        Console.WriteLine("Try again!");
                        Console.WriteLine("Player Turn! What will you do?");
                        Console.WriteLine("Press 'a' to attack and 'h' to heal!");
                    }

                if (player.IsDead || enemy.IsDead)
                {
                    break;
                }

                Console.WriteLine(player.UnitName + " HP = " + player.Hp + ". " + enemy.UnitName + " HP = " + enemy.Hp);
                Console.WriteLine("Enemy Turn!");

                int ran = random.Next(0, 3);
                if (ran != 0)
                {
                    enemy.Attack(player); // Corrected to attack the player
                }
                else
                {
                    enemy.Heal();
                }
            }
        }
    }
}
