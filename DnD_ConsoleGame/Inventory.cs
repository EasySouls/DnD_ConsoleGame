using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_ConsoleGame
{
    internal class Inventory
    {
        //something's wrong with the array initialization
        private int cap;
        private int nrOfItems;
        private Item[] itemArr;

        private void Expand()
        {
            cap *= 2;
            Item[] tempArr = new Item[cap];

            for (int i = 0; i < nrOfItems; i++)
            {
                tempArr[i] = itemArr[i];
            }

            itemArr = new Item[cap];
            itemArr = tempArr;
            Initialize(nrOfItems);
        }

        private void Initialize(int from = 0)
        {
            for (int i = from; i < cap; i++)
            {
                // this might be problematic
                itemArr[i] = new Item();
            }
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
            if (nrOfItems >= cap)
            {
                Expand();
            }
            itemArr[nrOfItems++] = item;
        }

        public void RemoveItem(int index)
        {
            // TODO
            // all items after the removed one gets assigned one place
            // backwards in the array

            for (int i = index; i < cap; i++)
            {

            }
        }

        public int Size()
        {
            return this.nrOfItems;
        }
        
        public Item Item(int index)
        {
            if (index < 0 || index >= this.nrOfItems)
            {
                throw new Exception("Bad index!");
            }

            return itemArr[index];
        }

        public Item Item(string itemName)
        {

            foreach (Item item in itemArr)
            {
                if (item.GetName() == itemName) 
                {
                    return item;  
                }           
            }

            throw new Exception("Item with this name wasn't found!");
        }

        public void DebugPrint()
        {
            for (int i = 0; i < nrOfItems; i++)
            {
                Console.WriteLine(itemArr[i]);
            }
        }
    }
}
