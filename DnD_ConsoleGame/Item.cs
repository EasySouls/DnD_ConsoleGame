using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_ConsoleGame
{
    internal class Item
    {
        private string name;
        private int level;
        private int sellValue;
        private int buyValue;
        private int rarity;

        public Item(string name = "NONE", int level = 0, int sellValue = 0, int buyValue = 0, int rarity = 0 )
        {
            this.name = name;
            this.level = level;
            this.sellValue = sellValue;
            this.buyValue = buyValue;
            this.rarity = rarity;
        }

        public virtual Item Clone() { return null; }

        // Accessors
        public string GetName() { return name; }
        public int GetLevel() { return level; }
        public int GetSellValue() { return sellValue; }
        public int GetBuyValue() { return buyValue; }
        public virtual int GetRarity() { return rarity; }

        // Modifiers 
        public void SetName(string name) { this.name = name; }
        public void SetLevel(int level) { this.level = level; }
        public void SetSellValue(int value) { this.sellValue = value; }
        public void SetBuyValue(int value) { this.buyValue = value; }
        public void SetRarity(int value) { this.rarity = value; }
    }
}
