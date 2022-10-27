using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_ConsoleGame
{
    enum armorType { NONE = 0, LIGHT, MEDIUM, HEAVY }

    class Armor : Item
    {
        int armorClass;
        int type;

        bool upgradeable;
        int level;
        int maxLevel;

        public Armor(int armorClass, int type, bool upgradeable, int level, int maxLevel, string name, int buyValue, int sellValue, int rarity)
        {
            this.armorClass = armorClass;
            this.type = type;   
            this.upgradeable = upgradeable;
            this.level = level;
            this.maxLevel = maxLevel;
            this.buyValue = buyValue;
            this.sellValue = sellValue;
            this.rarity = rarity;
        }

        public void Upgrade()
        {
            if (upgradeable && level < maxLevel)
            {
                level++;
            }
        }

        public override string ToString()
        {
            string str = armorClass + " " + type;
            return str;
        }

        // Accessors
        public int GetArmorType() { return type; }
        public int GetArmorClass() { return armorClass; }
    }
}
