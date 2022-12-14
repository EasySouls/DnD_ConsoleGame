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

        bool upgradeable;
        int level;
        int maxLevel;

        public Weapon(int damageMin, int damageMax, bool upgradeable, int level, int maxLevel, string name, int buyValue, int sellValue, int rarity)
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

        public void Upgrade()
        {
            if (upgradeable && level < maxLevel)
            {
                level++;
            }
        }

        public override string ToString()
        {
            string str = damageMin + " " + damageMax;
            return str;
        }

        // Accessors
        public int GetDamageMin() { return damageMin; }
        public int GetDamageMax() { return damageMax; }
    }
}
