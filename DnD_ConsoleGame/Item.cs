using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_ConsoleGame
{
    internal class Item
    {
        protected string name;
        protected int sellValue;
        protected int buyValue;
        protected int rarity;

        public Item(string name = "NONE", int sellValue = 0, int buyValue = 0, int rarity = 0 )
        {
            this.name = name;
            this.sellValue = sellValue;
            this.buyValue = buyValue;
            this.rarity = rarity;
        }

        public virtual Item Clone() { return null; }

        // Accessors
        public string GetName() { return name; }
        public int GetSellValue() { return sellValue; }
        public int GetBuyValue() { return buyValue; }
        public virtual int GetRarity() { return rarity; }

        // Modifiers 
        public void SetName(string name) { this.name = name; }
        public void SetSellValue(int value) { this.sellValue = value; }
        public void SetBuyValue(int value) { this.buyValue = value; }
        public void SetRarity(int value) { this.rarity = value; }
    }
}
