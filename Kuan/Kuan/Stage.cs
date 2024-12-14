using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kuan
{
    public class Stage
    {
        public string StageName { get; set; }
        public Enemy Enemy { get; set; }
        public int EnemiesDefeated { get; set; }  
        public int EnemiesRequired { get; set; }  

        public Stage(string stageName, Enemy enemy, int enemiesRequired)
        {
            StageName = stageName;
            Enemy = enemy;
            EnemiesDefeated = 0;
            EnemiesRequired = enemiesRequired;  // Set the required number of enemies for this stage
        }

        public void StartStage(Player player)
        {
            bool stageComplete = false;

            while (!stageComplete)
            {
                Console.WriteLine("Stage " + StageName + " begins! A " + Enemy.Name + " appears!");
                Console.ReadKey();  // Wait for player to start

                while (player.IsAlive() && EnemiesDefeated < EnemiesRequired)
                {
                    Enemy.ResetHealth();  // Reset enemy health only before combat begins.

                    // Combat loop
                    while (Enemy.IsAlive() && player.IsAlive())
                    {
                        Console.Clear();

                        // Display current status
                        Console.WriteLine("\n----- Current Status -----");
                        player.DisplayStatus();
                        Enemy.DisplayStatus();

                        // Player's action
                        Console.WriteLine("\nWhat would you like to do?");
                        Console.WriteLine("1: Fight");
                        Console.WriteLine("2: Use Skill");
                        Console.WriteLine("3: quit");

                        string choice = Console.ReadLine();
                        switch (choice)
                        {
                            case "1":
                                player.AttackEnemy(Enemy);
                                break;
                            case "2":
                                player.UseSkill(Enemy);
                                break;
                            case "3":
                                Environment.Exit(0);
                                return;  // Exit the stage.
                            default:
                                Console.WriteLine("Invalid choice, try again.");
                                continue;
                        }

                        // Enemy's turn
                        if (Enemy.IsAlive())
                        {
                            int enemyActionChoice = new Random().Next(0, 2);
                            if (enemyActionChoice == 0)
                            {
                                Enemy.AttackEnemy(player);
                            }
                            else
                            {
                                Enemy.UseSkill(player);
                            }
                        }

                        // Pause between rounds
                        System.Threading.Thread.Sleep(2000);
                    }

                    if (player.IsAlive())
                    {
                        Console.WriteLine("You defeated the " + Enemy.Name + "!");
                        System.Threading.Thread.Sleep(2000);
                        EnemiesDefeated++;
                        player.LevelUp();
                    }
                    else
                    {
                        Console.WriteLine(player.Name + " died.");
                        System.Threading.Thread.Sleep(2000);
                        AskRetry(player);
                    }
                }

                if (EnemiesDefeated >= EnemiesRequired)
                {
                    System.Threading.Thread.Sleep(2000);
                    Console.WriteLine("You have defeated enough enemies in this stage!");
                    System.Threading.Thread.Sleep(2000);
                    stageComplete = true;
                }
            }
        }


        // Ask the player if they want to try again after death
        private bool AskRetry(Player player)
        {
            Console.WriteLine("\nWould you like to try again? (yes/no)");
            string retryChoice = Console.ReadLine().ToLower();

            if (retryChoice == "no" || retryChoice == "n" || retryChoice == "NO")
            {
                Console.WriteLine("Game Over! Thank you for playing!");
                Environment.Exit(0);  // Exit the game if the player chooses not to retry
                return true;  // Exit condition for the loop
            }
            else
            {
                // Restart the stage if the player chooses to try again
                Console.Clear();
                Console.WriteLine("Restarting the stage...\n");
                Program.Main();  // Restart the program
                return true;
            }
        }

    }
}
