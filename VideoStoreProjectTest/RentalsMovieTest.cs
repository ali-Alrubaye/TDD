using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework.Internal;
using NUnit.Framework;
using VideoStoreProject;

namespace VideoStoreProjectTest
{
    [TestFixture]
    public class RentalsMovieTest
    {
        private RentalsMovie sut;
        private IDateTime iDateTime;

        [SetUp]
        public void SetUp()
        {
            iDateTime = Substitute.For<IDateTime>();
            sut = new RentalsMovie(iDateTime);
        }

        [Test]
        public void CanAddRental()
        {
            sut.AddRental("Movie1", "20170101");
            var result = sut.GetRentalsFor("20170101");
            Assert.AreEqual(1, result.Count);
        }
        [Test]
        public void Get_Three_Day_Later()
        {
            iDateTime.Now().Returns(new DateTime(2017 - 06 - 14));
            sut.AddRental("Movie1", "20170101");
            var result = sut.GetRentalsFor("20170101");
            Assert.AreEqual(iDateTime.Now().AddDays(3), result[0].DateTime);
        }
        [Test]
        public void Get_rentals_by_SSN()
        {
            iDateTime.Now().Returns(new DateTime(2017 - 06 - 14));
            Rentals rent = new Rentals("Movie1", "20170101");
            sut.AddRental("Movie1", "20170101");
            var result = sut.GetRentalsFor("20170101");
            Assert.AreEqual(rent.Title,result[0].Title);
        }
        [Test]
        public void Can_rent_more_than_one_movie()
        {
            Rentals rent = new Rentals("Movie2", "20170102");
            sut.AddRental("Movie1", "20170101");
            sut.AddRental("Movie2", "20170102");
           
            var result = sut.GetRentalsFor("20170102");
            Assert.AreEqual(rent.Title, result[0].Title);
        }

        [Test]
        public void Cannot_rent_more_than_3_movies()
        {
            sut.AddRental("Movie1", "20170101");
            sut.AddRental("Movie2", "20170101");
            sut.AddRental("Movie3", "20170101");
            Assert.Throws<CanNotRetMorThenThreeException>(() => sut.AddRental("Movie4", "20170101"));
        }

        [Test]
        public void Customers_may_not_posses_two_copies_of_the_same_movie()
        {
            sut.AddRental("Movie1", "20170101");
            sut.AddRental("Movie2", "20170101");
            Assert.Throws<CanNotRetSamMovieException>(() => sut.AddRental("Movie1", "20170101"));
        }

        [Test]
        public void TimeExceptioD()
        {
            iDateTime.Now().Returns(new DateTime(2017 - 06 - 14));

            sut.AddRental("Movie1", "20170101");
            //var result = sut.GetRentalsFor("20170101");
            iDateTime.Now().Returns(new DateTime(2017 - 06 - 14).AddDays(4));
            Assert.Throws<DueDatesMovieException>(() => sut.AddRental("Movie2", "20170101"));
        }
    }
}
