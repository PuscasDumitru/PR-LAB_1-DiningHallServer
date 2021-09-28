using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DiningHallServer.DiningHallStuff
{
    class Table
    {
        public int Id { get; set; }
        public bool hasOrder = false;
        public bool isFree = true;
        public bool waitingToOrder = true;

        public void OccupyTable()
        {
            if(isFree)
            {
                Thread.Sleep(new Random().Next(50, 100)); // the time a client spends to occupy a table
                isFree = false;
            }
            else
                Console.WriteLine("This table is not free yet");
        }
        public Table(int id)
        {
            Id = id;
        }
        
        public Order GenerateOrder()
        {
            var random = new Random();

            int[] items = new int[random.Next(1, 20)];
            for (int i = 0; i < items.Length; i++)
            {
                items[i] = random.Next(1, 10);
            }

            int priority = random.Next(1, 5);

            return new Order(items, priority, this.Id);
        }
    }
}
