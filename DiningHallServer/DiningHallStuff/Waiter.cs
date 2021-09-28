using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DiningHallServer.DiningHallStuff
{
    class Waiter
    {
        public int Id { get; set; }
        private DiningHall diningHall;
        public Waiter(int id, DiningHall diningHall)
        {
            Id = id;
            this.diningHall = diningHall;
           
        }

        public void SendOrder(Order order)
        {
            string json = JsonConvert.SerializeObject(new
            {
                OrderId = order.Id,
                WaiterId = this.Id,
                order.TableId,
                order.Items,
                order.Priority,
                order.MaxWait,
                PickUpTime = DateTimeOffset.Now.ToUnixTimeSeconds()
            });

            Console.WriteLine($"Order {order.Id} from table {order.TableId} has been sent to the Kitchen!");
            SendOrderKitchen.SendOrder(json);
        }
        public void Work()
        {
            Thread t = new Thread(new ThreadStart(() =>
            {
                
                    foreach (var table in diningHall.Tables)
                    {
                        // if (table.hasOrder) -> later
                       
                        SendOrder(table.GenerateOrder());
                        
                    }
                
            }));

            t.Start();
        }
    }
}
