using ProjectWinformCarDealer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWinformCarDealer.Logics
{
    internal class GuestLogic
    {
        public void AddGuest(Guest guest)
        {
            using (var context = new ProjectWinformContext())
            {
                
                context.Guests.Add(guest);
                context.SaveChanges();
                
            }
        }
    }
}
