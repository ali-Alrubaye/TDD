using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VideoStoreProject
{
    public class RentalsMovie : IRentals
    {
        private List<Rentals> _rentalses;
        private IDateTime _datetime;

        public RentalsMovie()
        {
            
        }
        public RentalsMovie(IDateTime dateTime)
        {
            this._datetime = dateTime;
            this._rentalses = new List<Rentals>();
        }
        public void AddRental(string movieTitle, string socialSecurityNumber)
        {
            var checkInput = _rentalses.Count(m => m.Title == movieTitle && m.SecurityNumber == socialSecurityNumber);
            var ch = _rentalses.Count(c => c.SecurityNumber == socialSecurityNumber);
            var checkTime = _rentalses.Any(t => t.DateTime < _datetime.Now()); 
            
            string ssn = string.Format("{0:0000-00-00}", socialSecurityNumber);
            var valideSsn = Regex.IsMatch(socialSecurityNumber, ssn);
          
            if (checkInput == 1)
            {
                throw new CanNotRetSamMovieException();
            }
            if (checkInput == 0)
            {
                if (checkTime)
                {
                    throw new DueDatesMovieException();
                }
                if (ch >= 3)
                {
                    throw new CanNotRetMorThenThreeException();
                }
                if (valideSsn)
                {
                    Rentals r = new Rentals
                    {
                        Title = movieTitle,
                        SecurityNumber = socialSecurityNumber,
                        DateTime = _datetime.Now().AddDays(3)
                    };
                    _rentalses.Add(r);
                }
            }

        }

        public List<Rentals> GetRentalsFor(string socialSecurityNumber)
        {
            var getRent = _rentalses.Where(r => r.SecurityNumber == socialSecurityNumber).ToList();
            return getRent;
        }

        public void RemoveRental(string movieTitle, string socialSecurityNumber)
        {
            throw new NotImplementedException();
        }
    }
}
