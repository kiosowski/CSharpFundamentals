using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards
{
    public abstract class Bag
    {
        private List<Item> items;

        public Bag(int capacity)
        {
            this.Capacity = capacity;
            this.items = new List<Item>();
        }

        public int Capacity { get; }

        public int Load => this.Items.Sum(i => i.Weight);

        public IReadOnlyCollection<Item> Items
        {
            get
            {
                return this.items;
            }
        }


        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > this.Capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }
            this.items.Add(item);
        }
        public Item GetItem(string name)
        {
            if (items.Count == 0)
            {
                throw new InvalidOperationException("Bag is empty!");
            }
            if (!this.Items.Any(i=>i.GetType().Name == name))
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }
            var item = this.Items.First(i => i.GetType().Name == name);
            this.items.Remove(item);
            return item;
        }
    }
}