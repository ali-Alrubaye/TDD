using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;

namespace TravelAgencys
{
    public class BookingSystem
    {
        private List<Booking> bookings = new List<Booking>();
        private ITourSchedule tourSchedule;

        public BookingSystem(ITourSchedule turSchedule)
        {
           this.tourSchedule = turSchedule;
        }

        public void CreateBooking(Tour tour, Passenger passenger)
        {
            //var checkSeat = tourSchedule.GetToursFor(tour.Date).FirstOrDefault(x => x.Name == tour.Name);
            //if (checkSeat == null) throw new ArgumentNullException(nameof(checkSeat));
            var tours = tourSchedule.GetToursFor(tour.Date).FirstOrDefault(x => x.Name == tour.Name);
            var bookingCount = bookings.Count(x => x.Tours == tour);
            if (tour == null || tour.Seats == bookingCount)
            {
                throw new ExceptionNotSeatsEnough();
            }

            Booking b = new Booking
            {
              Tours = tours,
              PassengerBooking = passenger
              
            };
          bookings.Add(b);
           
        }

        public List<Booking> GetBookingsFor(Passenger passenger)
        {
           
            var getbooking = bookings.Where(b => b.PassengerBooking.FirstName == passenger.FirstName).ToList();
            return getbooking;
        }

    }
}