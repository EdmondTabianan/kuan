using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kuan
{
    public class Program
    {
        public static void Main()
        {
            Console.Clear();
            // Ask for username
            Console.Write("Enter your username: ");
            string username = Console.ReadLine();

            // Choose race and role
            Console.WriteLine("Choose your race: Human, Elf, Barbarian, dwarf");
            string race = Console.ReadLine();

            string role = "";
            if (race.ToLower() == "human")
            {
                Console.WriteLine("Choose your role: Mage, Warrior, Healer, Archer");
                role = Console.ReadLine();
            }
            else if (race.ToLower() == "elf")
            {
                Console.WriteLine("Choose your role: Mage, Archer");
                role = Console.ReadLine();
            }
            else if (race.ToLower() == "barbarian")
            {
                Console.WriteLine("Choose your role: warrior, tanker");
                role = Console.ReadLine();
            }
            else if (race.ToLower() == "dwarf")
            {
                Console.WriteLine("Choose your role: warrior, tanker");
                role = Console.ReadLine();
            }
            else 
            {
                Console.Write("invalid input");
                System.Threading.Thread.Sleep(2000);
                Program.Main();
            }

            try
            {
                Player player = new Player(username, race, role);

                // Create enemies
                Enemy slime = new Enemy("Slime", 1);
                Enemy goblin = new Enemy("Goblin", 5);
                Enemy golem = new Enemy("Golem", 15);

                // Start game stages
                Stage stage1 = new Stage("Slime Valley", slime, 2);
                stage1.StartStage(player);

                Stage stage2 = new Stage("Goblin Forest", goblin, 2);
                stage2.StartStage(player);

                Stage stage3 = new Stage("Golem Mountain", golem, 2);
                stage3.StartStage(player);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

}
