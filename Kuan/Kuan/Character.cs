using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kuan
{
    public abstract class Character
    {
        public string Name { get; set; }
        public int Health { get; protected set; }
        public int Attack { get; protected set; }
        public int Defense { get; protected set; }
        public int Level { get; protected set; }

        public Character(string name, int level, int health, int attack, int defense)
        {
            Name = name;
            Level = level;
            Health = health;
            Attack = attack;
            Defense = defense;
        }

        public virtual void TakeDamage(int damage)
        {
            int finalDamage = Math.Max(damage - Defense, 0);
            Health -= finalDamage;
            Console.WriteLine(Name + " takes " + finalDamage + " damage, " + Math.Max(Health, 0) + " HP remaining.");
        }


        public bool IsAlive()
        {
            return Health > 0;
        }

        public abstract void AttackEnemy(Character enemy);

        // Method to display the status of the character (player or enemy)
        public void DisplayStatus()
        {
            Console.WriteLine(Name + " [Level: " + Level + "] - HP: " + Health + " | Attack: " + Attack + " | Defense: " + Defense);
        }

    }

}
