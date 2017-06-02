using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TravelAgencys;

namespace TravelAgencysTests
{
    [TestFixture]
    public class BookingSystemTests
    {
        public TourScheduleStub _TourScheduleStub { get; private set; }
        public BookingSystem Sut { get; private set; }

        [SetUp]
        public void SetUp()
        {
            _TourScheduleStub = new TourScheduleStub();
            Sut = new BookingSystem(_TourScheduleStub);
        }

        [Test]
        public void CanCreateBooking()
        {
           var tour = new Tour
            {
                Name = "New years day Safari",
                Date = new DateTime(2015,5,1),
                Seats = 1
            };
            _TourScheduleStub.Tours.Add(tour);
            Passenger passenger = new Passenger
            {
                FirstName = "Ali",
                LastName = "Al-Rubaye"
            };
            Sut.CreateBooking(_TourScheduleStub.Tours[0], passenger);
            var result = Sut.GetBookingsFor(passenger);
           
            Assert.AreEqual(_TourScheduleStub.Tours[0].Name,result[0].Tours.Name);
        }

        [Test] 
        public void CanNotCreateBooking()
        {
            var tour = new Tour
            {
                Name = "New years day Safari",
                Date = new DateTime(2015, 5, 1),
                Seats = 0
            };
            _TourScheduleStub.Tours.Add(tour);


            Passenger passenger = new Passenger(); 
            passenger.FirstName = "GoGo"; 
            passenger.LastName = "Tomato"; 


            Assert.Throws<ExceptionNotSeatsEnough>(() => Sut.CreateBooking(_TourScheduleStub.Tours[0],passenger)); 
  
        } 
        [Test] 
        public void ExceptionNotSeatsEnough()
        {
            var tour = new Tour
            {
                Name = "New years day Safari",
                Date = new DateTime(2015, 5, 1),
                Seats = 1
            };
            _TourScheduleStub.Tours.Add(tour);


            Passenger passenger1 = new Passenger(); 
            passenger1.FirstName = "Toto"; 
            passenger1.LastName = "Jan"; 


            Passenger passenger2 = new Passenger(); 
            passenger2.FirstName = "Chock"; 
            passenger2.LastName = "Chock"; 


            Sut.CreateBooking(_TourScheduleStub.Tours[0], passenger1); 


            Assert.Throws<ExceptionNotSeatsEnough>(() => 
            { 
                Sut.CreateBooking(_TourScheduleStub.Tours[0], passenger2); 
            }); 


        } 

 

    }
}
