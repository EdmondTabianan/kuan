using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kuan
{
    public class Enemy : Character
    {
        public string EnemyType { get; set; }

        public Enemy(string enemyType, int level)
            : base(enemyType, level, 50 + level * 5, 5 + level, 2 + level)
        {
            EnemyType = enemyType;
        }

        public override void AttackEnemy(Character player)
        {
            Console.WriteLine(Name + " attacks " + player.Name + " for " + Attack + " damage!");
            player.TakeDamage(Attack);
            System.Threading.Thread.Sleep(2000);
        }

        // Reset health after each defeat
        public void ResetHealth()
        {
            Health = GetMaxHealth();  // Correctly resets to max health.
            Console.WriteLine(Name + "'s health has been reset to " + Health + ".");
        }

        public int GetMaxHealth()
        {
            return 50 + Level * 5;  // Adjust max health calculation if necessary.
        }


        // Enemy skill usage
        public void UseSkill(Player player)
        {
            switch (EnemyType.ToLower())
            {
                case "slime":
                    SlimeSkill(player);
                    break;
                case "goblin":
                    GoblinSkill(player);
                    break;
                case "golem":
                    GolemSkill(player);
                    break;
                default:
                    Console.WriteLine(Name + " has no special skill.");
                    break;
            }
        }

        private void SlimeSkill(Player player)
        {
            int damage = 5 + Level;
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine(Name + " uses Slime Splash! It deals " + damage + " damage to " + player.Name + "!");
            player.TakeDamage(damage);
        }

        private void GoblinSkill(Player player)
        {
            int damage = 7 + Level;
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine(Name + " uses Goblin Stab! It deals " + damage + " damage to " + player.Name + "!");
            player.TakeDamage(damage);
        }

        private void GolemSkill(Player player)
        {
            int damage = 10 + Level;
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine(Name + " uses Golem Earthquake! It deals " + damage + " damage to " + player.Name + "!");
            player.TakeDamage(damage);
        }
    }

}