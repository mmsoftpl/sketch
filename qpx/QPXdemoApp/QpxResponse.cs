using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace QPXdemoApp
{
    public class Airport
    {
        public string code { get; set; }
        public string city { get; set; }
        public string name { get; set; }
    }

    public class City
    {
        public string code { get; set; }
        public string name { get; set; }
    }

    public class Aircraft
    {
        public string code { get; set; }
        public string name { get; set; }
    }

    public class Tax
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Carrier
    {
        public string code { get; set; }
        public string name { get; set; }
    }

    public class Data
    {
        public Airport[] airporty { get; set; }
        public City[] city { get; set; }
        public Aircraft[] aircraft { get; set; }
        public Tax[] tax { get; set; }
        public Carrier[] carrier { get; set; }
    }

    public class Leg
    {
        public string aircraft { get; set; }
        public DateTime arrivalTime { get; set; }
        public DateTime departureTime { get; set; }
        public string origin { get; set; }
        public string destination { get; set; }
        public string destinationTerminal { get; set; }
        public int duration { get; set; }
        public int mileage { get; set; }
        public string operatingDisclosure { get; set; }
        public string meal { get; set; }

        internal Segment Parent = null; // hack!
    }

    public class Flight
    {
        public string carrier { get; set; }
        public string number { get; set; }
    }

    public class Segment
    {
        public int duration { get; set; }  //minutes
        public int connetionDuration { get; set; }  //minutes
        public Flight fligh { get; set; }
        public string cabin { get; set; }
        public string bookingCode { get; set; }
        public Leg[] leg { get; set; }
    }

    public class TripOptionSlice
    {
        public int duration { get; set; }  //minutes
        public Segment[] segment { get; set; }
    }

    public class TripOption
    {
        public string saleTotal { get; set; }
        public string id { get; set; } //?

        public TripOptionSlice[] slice { get; set; }

        public DateTime? DepTime
        {
            get
            {
                Leg firstLeg = this.Legs().FirstOrDefault<Leg>();

                if (firstLeg != null)
                    return firstLeg.departureTime;
                return null;
            }
        }

        public DateTime? ArrTime
        {
            get
            {
                Leg lastLeg = this.Legs().LastOrDefault<Leg>();

                if (lastLeg != null)
                    return lastLeg.arrivalTime;
                return null;
            }
        }

        public TimeSpan? DurationTotal
        {
            get
            {
                DateTime? depTime = DepTime;
                DateTime? arrTime = ArrTime;

                if (depTime.HasValue && arrTime.HasValue)
                {
                    return (arrTime - depTime);
                }
                return null;
            }
        }
    }

    public class Trips
    {
        public TripOption[] tripOption { get; set; }
    }

    public class QpxResponse
    {
        public Trips trips { get; set; }
    }

    public static class QpxResponseExtensions
    {
        public static IEnumerable<Leg> Legs(this TripOption tripOption)
        {
            if (tripOption != null)
            {
                foreach (var slice in tripOption.slice)
                {
                    foreach (var segment in slice.segment)
                    {
                        foreach (var leg in segment.leg)
                        {
                            leg.Parent = segment; //ugly hack!
                            yield return leg;
                        }
                    }
                }
            }

            yield break;
        }


        public static string ToReadableString(this TimeSpan? span)
        {
            if (span != null)
                return ToReadableString(span.Value, false);
            return "";
        }

        public static string ToReadableString(this TimeSpan span, bool showMiliseconds)
        {
            try
            {
                if (span.TotalSeconds == 0)
                    return "0 seconds";

                bool isNegative = span.Ticks < 0;
                if (isNegative)
                    span = span.Negate();

                string formatted = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}",
                    span.Days == 1 ? string.Format("{0:0} day, ", span.Days) : string.Empty,
                    span.Days > 1 ? string.Format("{0:0} days, ", span.Days) : string.Empty,
                    span.Hours == 1 ? string.Format("{0:0} hour, ", span.Hours) : string.Empty,
                    span.Hours > 1 ? string.Format("{0:0} hours, ", span.Hours) : string.Empty,
                    span.Minutes == 1 ? string.Format("{0:0} minute, ", span.Minutes) : string.Empty,
                    span.Minutes > 1 ? string.Format("{0:0} minutes, ", span.Minutes) : string.Empty,
                    span.Seconds == 1 ? string.Format("{0:0} second, ", span.Seconds) : string.Empty,
                    span.Seconds > 1 ? string.Format("{0:0} seconds, ", span.Seconds) : string.Empty);

                if (showMiliseconds)
                    if (span.Milliseconds > 0)
                    {
                        formatted += string.Format("{0} ms", span.Milliseconds);
                    }
                

                if (formatted.EndsWith(", ")) formatted = formatted.Substring(0, formatted.Length - 2);

                if (isNegative)
                    formatted = "-" + formatted;

                return formatted;
            }
            catch
            {
                return "?";
            }
        }

        public static string AsString(this QpxResponse response)
        {
            StringBuilder sb = new StringBuilder();

            if (response != null)
                if (response.trips != null)
                {

                    foreach (var trip in response.trips.tripOption)
                    {
                        sb.AppendLine();
                        sb.AppendLine();
                        sb.AppendLine("PRICE: " + trip.saleTotal);
                        sb.AppendLine("DURATION: " + trip.DurationTotal.ToReadableString());

                        int legno = 0;

                        foreach (var leg in trip.Legs())
                        {
                            legno++;

                            sb.AppendLine(leg.departureTime.ToString(legno + "     " + "yyyy-MM-dd hh:mm") + " " + leg.origin + " -> " + leg.destination + " " + leg.arrivalTime.ToString("yyyy-MM-dd hh:mm"));
                            sb.AppendLine("                  [Terminal = " + leg.destinationTerminal + " ] [ Class = " + leg.Parent.cabin + " ] [ " + leg.mileage + " miles ] [ AcType = " + leg.aircraft + " ]");
                        }
                    }
                }

            return sb.ToString();
        }
    }
}
