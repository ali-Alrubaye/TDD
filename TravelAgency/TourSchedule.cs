using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency
{
    public class TourSchedule
    {
        private Dictionary<DateTime,List<Tour>>_scheduleByDay=
            new Dictionary<DateTime, List<Tour>>();
        
         
        public void CreateTour(string name, DateTime dateTime, int seats)
        {
            var checkDay = (from day in _scheduleByDay.Keys
                where day.Day == dateTime.Day
                select day).Count();
            if (checkDay >= 3)
                throw new TourAllocationException(dateTime.AddDays(1).Date);
            if(_scheduleByDay.ContainsKey(dateTime))
                _scheduleByDay[dateTime].Add(new Tour(name, dateTime, seats));
            _scheduleByDay.Add(dateTime.Date,new List<Tour> {new Tour(name,dateTime,seats)});
          
        }

        public List<Tour> GetToursFor(DateTime dateTime)
        {
            var tours = _scheduleByDay[dateTime.Date].OrderBy(x => x.Date).ToList();
            return tours;
        }
       
    }
    public class Tour
    {
        public string Name { get; private set; }
        public DateTime Date { get; private set; }
        public int Seats { get; private set; }

        public Tour(string name, DateTime date, int seats)
        {
            this.Name = name;
            this.Date = date;
            this.Seats = seats;
        }
    }
}
