using System;
using System.Collections.Generic;

namespace APIGroupProject.Models
{
    public partial class Favorite
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public DateTime? StartDate { get; set; }
        public string VenueName { get; set; }
        public string VenueAddress { get; set; }
        public string EventUrl { get; set; }
        public string UserId { get; set; }

        public virtual AspNetUsers User { get; set; }

        public Favorite() { }

        public Favorite(string _eventName, DateTime _startDate, string _venueName, string _venueAddress, string _eventURL)
        {
            EventName = _eventName;
            StartDate = _startDate;
            VenueName = _venueName;
            VenueAddress = _venueAddress;
            EventUrl = _eventURL;
        }
    }

    
}
