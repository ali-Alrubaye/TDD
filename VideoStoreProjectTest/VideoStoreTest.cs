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
    public class VideoStoreTest
    {
        private VideoStore sut;
        private IRentals rentalMock;
        private IDateTime iDateTime;

        [SetUp]
        public void SetUp()
        {
            rentalMock = Substitute.For<IRentals>();
            iDateTime = Substitute.For<IDateTime>();
            sut = new VideoStore(rentalMock,iDateTime);
         
        }
        [Test]
        public void CanAddMovie()
        {
            var movie = new Movie
            {
                MovieTitle = "Movie1"
            };
            sut.AddMovie(movie);
            Assert.AreEqual(1,sut.Movies.Count);
        }

        [Test]
        public void NullExceptionMovie()
        {
            //var movie =new Movie {MovieTitle = ""};
            //sut.AddMovie(movie);
            Assert.Throws<NullExceptionMovie>(() => sut.AddMovie(null));
        }

        [Test]
        public void duplicate_NameException_movie_Title()
        {
            var movie = new Movie { MovieTitle = "Movie1" };
            sut.AddMovie(movie);
            Assert.Throws<DuplicateException>(() => sut.AddMovie(movie));
        }

        [Test]
        public void Duplicate_Customer_NameException()
        {
            Customer c= new Customer("Ali", "19780501");
            sut.RegisterCustomer(c.Name,c.SSn);
            Assert.Throws<DuplicateException>(()=> sut.RegisterCustomer(c.Name, c.SSn));
        }

        [Test]
        public void Rent_non_existent_movie_Exception()
        {
            //sut.RegisterCustomer("", "1978-05-01");
            Assert.Throws<NullExceptionMovie>(()=> sut.RentMovie("", "19780501"));
        }
        [Test]
        public void Customer_Not_Registered_CannotRent_Movie_Exception()
        {
            var movie = new Movie { MovieTitle = "Movie1" };
            sut.AddMovie(movie);
            //rentalMock.GetRentalsFor("1978-05-01").Returns(new List<Rentals>())
            Assert.Throws<NullExceptionCustomerNotRegistered>(() => sut.RentMovie("Movie1", ""));
        }
        //Start IRentals
        //[Test]
        //public void Add_Rental()
        //{
        //    //Rentals r = new Rentals { Title = "Movie1", SecurityNumber = "", DateTime = new DateTime(2017, 06, 17) };
        //    //rentalMock.GetRentalsFor("20170617").Returns(new List<Rentals>
        //    //{
        //    //    new Rentals {Title = "Movie1", SecurityNumber = "20170616"},
        //    //    new Rentals {Title = "Movie2", SecurityNumber = "20170617"}
        //    //});
        //    rentalMock.AddRental("Movie1", "20170616");
      
        //    rentalMock.GetRentalsFor("20170617").Returns(new List<Rentals>
        //    {
        //        new Rentals {Title = "Movie1", SecurityNumber = "20170616"}
        //    });
        //}
        //[Test]
        //public void Get_Three_Day_Later()
        //{
        //    iDateTime.Now().Returns(new DateTime(2017, 06, 14));
        //    rentalMock.AddRental("Movie1", "20170616");

        //    rentalMock.GetRentalsFor("20170617").Returns(new List<Rentals>
        //    {
        //        new Rentals {Title = "Movie1", SecurityNumber = "20170616", DateTime = DateTime.Now.AddDays(-3)}
        //    });

        //}
        //[Test]
        //public void Can_rent_more_than_one_movie()
        //{
        //    iDateTime.Now().Returns(new DateTime(2017, 06, 14));
        //    rentalMock.AddRental("Movie1", "20170616");


        //    rentalMock.GetRentalsFor("20170617").Returns(new List<Rentals>
        //    {
        //        new Rentals {Title = "Movie1", SecurityNumber = "20170616", DateTime = DateTime.Now.AddDays(3)},
        //        new Rentals {Title = "Movie2", SecurityNumber = "20170616", DateTime = DateTime.Now.AddDays(3)},
        //        new Rentals {Title = "Movie1", SecurityNumber = "20170616", DateTime = DateTime.Now.AddDays(3)}
        //    });
        //}
    }
}
