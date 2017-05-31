using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency;

namespace TravelAgencyTests
{
    [TestFixture]
    public class TourScheduleTests
    {
        private TourSchedule sut;
        [SetUp]
        public void Setup()
        {
            sut = new TourSchedule();
        }
        [Test]
        public void CanCreateNewTour()
        {
            var sut = new TourSchedule();
            sut.CreateTour("New years day safari", new DateTime(2013, 1, 1), 20);

            var result = sut.GetToursFor(new DateTime(2013, 1, 1));
            Assert.AreEqual("New years day safari", result[0].Name);

        }

        [Test]
        public void ToursAreScheduledByDateOnly()
        {

            sut.CreateTour(
                "New years day safari",
                new DateTime(2013, 1, 1, 10, 15, 0), 20);
            var tour = sut.GetToursFor(new DateTime(2013, 1, 1));
            Assert.AreEqual("New years day safari", tour[0].Name);

        }

        [Test]
        public void GetToursForGivenDayOnly()
        {
            sut.CreateTour("New years day safari", new DateTime(2013, 1, 1, 10, 15, 0), 20);
            sut.CreateTour("February safari", new DateTime(2013, 2, 1, 10, 15, 0), 20);
            sut.CreateTour("March safari", new DateTime(2013, 3, 1, 10, 15, 0), 20);
            //sut.CreateTour("April safari", new DateTime(2013, 4, 1, 10, 15, 0), 20);

            var result = sut.GetToursFor(new DateTime(2013, 1, 1));

            Assert.AreEqual(new DateTime(2013, 1, 1), result[0].Date.Date);
            Assert.AreEqual(1, result.Count);

        }
        [Test]
        public void TourAllocationException()
        {
            sut.CreateTour("New years day safari01", new DateTime(2013, 1, 1), 20);
            sut.CreateTour("New years day safari02", new DateTime(2013, 2, 1), 20);
            sut.CreateTour("New years day safari03", new DateTime(2013, 3, 1), 20);
            //sut.CreateTour("New years day safari04", new DateTime(2013, 1, 1, 10, 15, 0), 20);

            Assert.Throws<TourAllocationException>(() => sut.CreateTour("Fabruary safari", new DateTime(2013, 1, 1), 20));


        }
    }
}
