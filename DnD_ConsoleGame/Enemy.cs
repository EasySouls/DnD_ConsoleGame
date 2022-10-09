using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_ConsoleGame
{
    internal class Enemy
    {
        string name;
        int level;
        int hp;
        int hpMax;
        int damageMin;
        int damageMax;
        float dropChance;
        int defence;
        int accuracy;

        Random rand = new Random();

        public Enemy(int level = 1, string name = "basic enemy")
        {
            this.name = name;
            this.level = level;
            this.hpMax = level * 10;
            this.hp = hpMax;
            this.damageMin = level * 2;
            this.damageMax = level * 3;
            this.dropChance = rand.Next() % 100 + 1;
            this.defence = rand.Next() % level * 4 + 1;
            this.accuracy = rand.Next() % level * 4 + 1;
        }

        public void TakeDamage(int damage)
        {
            this.hp -= damage;

            if (this.hp <= 0)
            {
                this.hp = 0;
                // enemy dies
            }
        }

        public string GetAsString()
        {
            return this.name; //TODO
        }

        // Accessors
        public bool IsAlive() { return hp > 0; }
        public string GetName() { return name; }
        public int GetDamage() { return rand.Next() % damageMax + damageMin; } 
        public int GetExpValue() { return level * 100; }
        public int GetHp() { return hp; }
        public int GetHpMax() { return hpMax; }
        public int GetLevel() { return level; }
        public int GetDefence() { return defence; }
        public int GetAccuracy() { return accuracy; }
    }
}
