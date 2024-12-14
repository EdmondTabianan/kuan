using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kuan
{
    public class Player : Character
    {
        public string Race { get; set; }
        public string Role { get; set; }

        public Player(string name, string race, string role)
            : base(name, 1, 50, 10, 5) // Starting stats for the player
        {
            Race = race;
            Role = role;
            SetRoleStats();
        }

        private void SetRoleStats()
        {
            switch (Role.ToLower())
            {
                case "mage":
                    Attack += 5;
                    Defense -= 2;
                    break;
                case "warrior":
                    Attack += 3;
                    Defense += 3;
                    break;
                case "healer":
                    Health += 20;
                    break;
                case "archer":
                    Attack += 4;
                    Defense += 1;
                    break;
                case "tanker":
                    Health += 30;
                    Defense += 5;
                    break;
                default:
                    Console.WriteLine("Invalid input");           
                    System.Threading.Thread.Sleep(2000);
                    Program.Main();
                    break;
            }
        }

        public void LevelUp()
        {
            Level++;
            Health += 10;
            Attack += 2;
            Defense += 1;
            Console.WriteLine(Name + " leveled up to Level " + Level + "!");
            System.Threading.Thread.Sleep(2000);
        }

        public override void AttackEnemy(Character enemy)
        {
            Console.WriteLine(Name + " attacks " + enemy.Name + " for " + Attack + " damage!");
            enemy.TakeDamage(Attack);  // Ensure damage affects the correct enemy instance.
            System.Threading.Thread.Sleep(2000);
        }

        public void UseSkill(Enemy enemy)
        {
            switch (Role.ToLower())
            {
                case "mage":
                    UseFireball(enemy);
                    break;
                case "healer":
                    UseHeal();
                    break;
                case "archer":
                    UsePiercingShot(enemy);
                    break;
                case "warrior":
                    UsePowerStrike(enemy);
                    break;
                case "tanker":
                    UseShieldTackle(enemy);
                    break;
                default:
                    Console.WriteLine(Name + " does not have a unique skill for their role.");
                    break;
            }
        }

        private void UseFireball(Enemy enemy)
        {
            int skillDamage = Attack * 2; // Fireball skill
            Console.WriteLine(Name + " uses Fireball! It deals " + skillDamage + " damage to " + enemy.Name + "!");
            enemy.TakeDamage(skillDamage);
            System.Threading.Thread.Sleep(2000);
        }

        private void UseHeal()
        {
            int healAmount = 20; // Healing skill
            Health += healAmount;
            Console.WriteLine(Name + " uses Heal! " + Name + " recovers " + healAmount + " HP.");
            System.Threading.Thread.Sleep(2000);
        }

        private void UsePiercingShot(Enemy enemy)
        {
            int skillDamage = Attack + 5; // Piercing shot skill
            Console.WriteLine(Name + " uses Piercing Shot! It deals " + skillDamage + " damage to " + enemy.Name + "!");
            enemy.TakeDamage(skillDamage);
            System.Threading.Thread.Sleep(2000);
        }

        private void UsePowerStrike(Enemy enemy)
        {
            int skillDamage = Attack + 10; // Power strike skill
            Console.WriteLine(Name + " uses Power Strike! It deals " + skillDamage + " damage to " + enemy.Name + "!");
            enemy.TakeDamage(skillDamage);
            System.Threading.Thread.Sleep(2000);
        }

        private void UseShieldTackle(Enemy enemy)
        {
            int skillDamage = Defense * 2; // Shield tackle skill based on defense
            Console.WriteLine(Name + " uses Shield Tackle! It deals " + skillDamage + " damage to " + enemy.Name + " and stuns them for 1 turn!");
            enemy.TakeDamage(skillDamage);
            // Implement a stun effect if needed (e.g., skip enemy's next turn).
            System.Threading.Thread.Sleep(2000);
        }

        public void DisplayStatus()
        {
            base.DisplayStatus();  // Call base class DisplayStatus method
            Console.WriteLine(Race + " " + Role + " - Health: " + Health + " | Attack: " + Attack + " | Defense: " + Defense);
        }
    }
}
