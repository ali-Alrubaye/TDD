using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VideoStoreProject
{
    public class VideoStore: IVideoStore
    {
        public List<Customer> Customers = new List<Customer>();
        public List<Movie> Movies = new List<Movie>();
        private IRentals _iRentals;
        private IDateTime _iDateTime;

        public VideoStore()
        {
            
        }
        public VideoStore(IRentals iRentals,IDateTime iDateTime)
        {
            this._iRentals = iRentals;
            this._iDateTime = iDateTime;
        }
        public void RegisterCustomer(string name, string socialSecurityNumber)
        {
            //var result = DateTime.ParseExact(socialSecurityNumber, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            string ssn = String.Format("{0:0000-00-00}", socialSecurityNumber);
            var valideSsn = Regex.IsMatch(socialSecurityNumber, ssn);
            var checkNameCust = Customers.Count(c => c.Name == name);
            if (checkNameCust>=1)
            {
                throw new DuplicateException();
            }
            if (valideSsn)
            {
                Customer c = new Customer
                {
                   Name = name,
                   SSn = socialSecurityNumber
                };
                Customers.Add(c);
            }
        }

        public void AddMovie(Movie movie)
        {
            if (movie == null)
            {
                throw new NullExceptionMovie();
            }
            var result = Movies.Count(x=> x.MovieTitle == movie.MovieTitle);
            if (result>0)
            {
                throw new DuplicateException();
            }
            Movies.Add(movie);
        }

        public void RentMovie(string movieTitle, string socialSecurityNumber)
        {
            //var checkC = _iRentals.GetRentalsFor(socialSecurityNumber);
            var checkCust = Customers.Count(c => c.SSn == socialSecurityNumber);
            var checkMovie = Movies.Count(m => m.MovieTitle == movieTitle);
            if (checkMovie == 0)
            {
                throw new NullExceptionMovie();
            }
            else if(checkCust == 0)
            {
                throw new NullExceptionCustomerNotRegistered();
            }
            _iRentals.AddRental(movieTitle,socialSecurityNumber);
        }

        public List<Customer> GetCustomers()
        {
            var getCust = Customers;
            return getCust;
        }

        public void ReturnMovie(string movieTitle, string socialSecurityNumber)
        {
            throw new NotImplementedException();
        }
    }
}
