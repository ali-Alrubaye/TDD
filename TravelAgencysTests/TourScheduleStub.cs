using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencys;

namespace TravelAgencysTests
{
    public class TourScheduleStub: ITourSchedule
    {
        public List<Tour> Tours { get; set; }

        public TourScheduleStub()
        {
            Tours= new List<Tour>();
        }
        public void CreateTour(string name, DateTime dateTime, int seats)
        {
            throw new NotImplementedException();
        }

        public List<Tour> GetToursFor(DateTime dateTime)
        {
            return Tours;
        }
    }
}
