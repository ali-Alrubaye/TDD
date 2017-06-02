using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencys
{
    public class Booking
    {
        public Passenger PassengerBooking { get; set; }
        public Tour Tours { get; set; }

        //public Booking(Tour tour, Passenger pass)
        //{
        //    this.Tours = tour;
        //    this.PassengerBooking = pass;
        //}
    }
}
