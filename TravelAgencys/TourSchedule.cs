using System;
using System.Collections.Generic;
using System.Linq;

namespace TravelAgencys
{
    public interface ITourSchedule
    {
        void CreateTour(string name, DateTime dateTime, int seats);
        List<Tour> GetToursFor(DateTime dateTime);
    }

    public class TourSchedule : ITourSchedule
    {
        private Dictionary<DateTime,List<Tour>>_scheduleByDay=
            new Dictionary<DateTime, List<Tour>>();
        
         
        public void CreateTour(string name, DateTime dateTime, int seats)
        {


            if (_scheduleByDay.ContainsKey(dateTime))
            {
                var tours = _scheduleByDay[dateTime];
                if (tours.Count >= 3)
                {
                  throw new TourAllocationException(dateTime.AddDays(1).Date);
                }
                tours.Add(new Tour(name, dateTime, seats));
            }
            else
            {
                 _scheduleByDay.Add(dateTime.Date,new List<Tour> {new Tour(name,dateTime,seats)});
            }
          
        }
        public List<Tour> GetToursFor(DateTime dateTime)
        {
            var tours = _scheduleByDay[dateTime.Date].OrderBy(x => x.Date).ToList();
            return tours;
        }
       
    }
   
}
