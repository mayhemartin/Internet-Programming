using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IP_FinalProject
{
    public class Reservation
    {
        public int roomID { set; get; }
        public DateTime checkIn { set; get; }
        public DateTime checkOut { set; get; }
        public int nights { set; get; }
        public int custID { set; get; }
        public String message { set; get; }
    }
}