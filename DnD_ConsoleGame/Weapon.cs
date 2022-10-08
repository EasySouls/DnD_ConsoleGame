using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_ConsoleGame
{
    internal class Weapon : Item
    {
        private int damageMin;
        private int damageMax;

        public Weapon(int damageMin, int damageMax, string name, int level, int buyValue, int sellValue, int rarity)
        {
            this.damageMin = damageMin;
            this.damageMax = damageMax;
            this.name = name;
            this.level = level;
            this.buyValue = buyValue;
            this.sellValue = sellValue;
            this.rarity = rarity;
        }

        // I do not know yet if it works
        public override Weapon Clone() { return this; }

        public override string ToString()
        {
            string str = damageMin + " " + damageMax;
            return str;
        }

        // Accessors
        public int GetDameMin() { return damageMin; }
        public int GetDameMax() { return damageMax; }
    }
}
