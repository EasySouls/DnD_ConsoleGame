using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_ConsoleGame
{
    internal class Inventory
    {
        private int cap;
        private int nrOfItems;
        private Item[] itemArr;

        private void Expand()
        {
            
        }

        private void Initialize(int from = 0)
        {

        }

        public Inventory()
        {
            cap = 5;
            nrOfItems = 0;
            itemArr = new Item[cap];
            Initialize();
        }

        public Inventory(Inventory obj)
        {
            cap = obj.cap;
            nrOfItems = obj.nrOfItems;
            itemArr = obj.itemArr;

            for (int i = 0; i < nrOfItems; i++)
            {
                itemArr[i] = obj.itemArr[i].Clone();
            }

            Initialize(nrOfItems);
        }

        public void AddItem(Item item)
        {

        }

        public void RemoveItem(int index)
        {

        }

        public int Size()
        {
            return this.nrOfItems;
        }

        //Item& operator[] (int index)
        //{

        //}

        public void DebugPrint()
        {
            for (int i = 0; i < nrOfItems; i++)
            {
                Console.WriteLine(itemArr[i]);
            }
        }
    }
}
