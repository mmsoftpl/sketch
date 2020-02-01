using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QPXdemoApp
{

    public class PermittedDepartureTime
    {
        public string earliestTime { get; set; }//"HH:MM"
        public string latestTime { get; set; } //"HH:MM"
    }

    public class Slice
    {
        public string origin { get; set; }
        public string destination { get; set; }
        public string date { get; set; }
        public int maxStops { get; set; }
        public string preferredCabin { get; set; } // "BUSINESS", "PREMIUM_COACH", "COACH", "BUSINESS"
        public string alliance { get; set; } // "STAR", "SKYTEAM", "ONEWORLD"
        public string[] permittedCarrier { get; set; }
        public string[] prohibitedCarrier { get; set;}
        public PermittedDepartureTime permittedDepartureTime { get; set; }
        public int maxConnectionDuration { get; set;} // in minutes

        public Slice()
        {
           // permittedDepartureTime = new PermittedDepartureTime();
            maxStops = 100;
            maxConnectionDuration = 1440;
        }
    }

    public class Passengers
    {
        public int adultCount { get; set; }
        public int infantInLapCount { get; set; }
        public int infantInSeatCount { get; set; }
        public int childCount { get; set; }
        public int seniorCount { get; set; }

        public Passengers()
        {

        }
    }

    public class Request
    {
        public Passengers passengers { get; set; }
        public Slice[] slice { get; set; }

        public int solutions { get; set; }
        public bool Refundable { get; set; }
        public string maxPrice { get; set; }
        public string saleCountry { get; set; }

        public Request()
        {
            passengers = new Passengers() { adultCount = 1 };
            solutions = 20; //max 20 
        }
    }

    public class QpxRequest
    {
        public Request request { get; set; }

        public QpxRequest()
        {
            request = new Request();
        }
    }

}
