using System;
using System.Collections.Generic;
using System.Text;
using DiningHallServer.DiningHallStuff;

namespace DiningHallServer
{
    class DiningHall
    {

        public List<Waiter> Waiters { get; set; }
        public List<Table> Tables { get; set; }

        public void StartWork()
        {
            foreach(var waiter in Waiters)
            {
                waiter.Work();
            }
        }

    }
}
