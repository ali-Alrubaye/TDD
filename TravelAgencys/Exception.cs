using System;

namespace TravelAgencys
{
    public class TourAllocationException : Exception
    {
        public DateTime? SuggestedTime { get; private set; }

        public TourAllocationException(DateTime? suggestedTime)
        {
            this.SuggestedTime = suggestedTime;
        }
    }

    public class ExceptionNotSeatsEnough : Exception
    {
        
    }
}
