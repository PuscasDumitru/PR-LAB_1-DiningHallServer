using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiningHallServer.DiningHallStuff
{
    class Order
    {
        public Guid Id { get; set; }
        public int[] Items { get; set; }
        public int Priority { get; set; }
        public double MaxWait { get; set; }
        public int TableId { get; set; }

        public Order(int[] items, int priority, int id)
        {
            Id = Guid.NewGuid();
            TableId = id;
            Items = items;
            Priority = priority;
            MaxWait = Menu.menuDishes.Where(x => Items.Contains(x.Id)).Select(x => x.PrepTime).Max() * 1.3;
        }

    }
}
