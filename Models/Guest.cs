using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectWinformCarDealer.Models
{
    public partial class Guest
    {
        public int GuestId { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
