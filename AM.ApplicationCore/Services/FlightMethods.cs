using System.Collections.Immutable;
using System.Reflection;
using AM.ApplicationCore.Interfaces;
using AM.ApplicationDomain.Domains;

namespace AM.ApplicationCore.Services;

public class FlightMethods : IFlightMethods
{
    public List<Flight> Flights { get; set; } = new List<Flight>();

    public IEnumerable<DateTime> GetFlightDates(string destination)
    {
        List<DateTime> flightDates = new List<DateTime>();

        for (int i = 0; i < Flights.Count; i++)
        {
            if (Flights[i].Destination == destination)
            {
                flightDates.Add(Flights[i].FlightDate);
            }
        }

        return flightDates;
    }

    public List<DateTime> GetFlightDatesForEach(string destination)
    {
        List<DateTime> flightDates = new List<DateTime>();

        //foreach (var flight in Flights)
        //{
        //    if (flight.Destination == destination)
        //    {
        //        flightDates.Add(flight.FlightDate);
        //    }
        //}

        //return flightDates;
        //var query = from flight in Flights 
        //            where flight.Destination == destination
        //            select flight.FlightDate;
        //return query.ToList();
        return Flights
            .Where(f => f.Destination == destination)
            .Select(f => f.FlightDate)
            .ToList();
    }

    public void GetFlights(string filterType, string filterValue)
    {
        foreach (var flight in Flights)
        {
            switch (filterType)
            {
                case "FlightDate":
                    if (flight.FlightDate.ToString() == filterValue)
                        Console.WriteLine(flight);
                    break;
                case "Destination":
                    if (flight.Destination == filterValue)
                        Console.WriteLine(flight);
                    break;
                case "FlightId":
                    if (flight.FlightId.ToString() == filterValue)
                        Console.WriteLine(flight);
                    break;
                case "Departure":
                    if (flight.Departure == filterValue)
                        Console.WriteLine(flight);
                    break;
                case "EffectiveArrival":
                    if (flight.EffectiveArrival.ToString() == filterValue)
                        Console.WriteLine(flight);
                    break;
                case "EstimatedDuration":
                    if (flight.EstimatedDuration.ToString() == filterValue)
                        Console.WriteLine(flight);
                    break;
                default:
                    break;
            }
        }
    }

    public int ProgrammedFlightNumber(DateTime startDate)
    {
        //var query = from f in Flights
        //            //where f.FlightDate >= startDate && f.FlightDate < startDate.AddDays(7)
        //            where DateTime.Compare(f.FlightDate, startDate) >= 0
        //            && (f.FlightDate - startDate).TotalDays < 7
        //            select f;
        //return query.Count();
        return Flights
            .Count(f => DateTime.Compare(f.FlightDate, startDate) >= 0
                && (f.FlightDate - startDate).TotalDays < 7);
    }

    public IEnumerable<Traveller> SeniorTravellers(Flight flight)
    {
        //var query = from p in flight.Passengers.OfType<Traveller>()
        //            orderby p.BirthDate
        //            select p;
        //return query.Take(3);
        return flight.Passengers
            .OrderBy(p => p.BirthDate)
            .OfType<Traveller>()
            .Take(3);
    }

    public void ShowFlightDetails(Plane plane)
    {
        //var flightDetils = from f in Flights
        //            where f.Plane == plane
        //            select new { f.FlightDate, f.Destination };
        var flightDetails = Flights
           .Where(f => f.Plane == plane)
           .Select(f => new { f.FlightDate, f.Destination });
        foreach (var item in flightDetails)
        {
            Console.WriteLine("destination = " +
                item.FlightDate.ToString() +
                " date = " +
                item.Destination);
        }
    }

    public Double DurationAverage(string Destination)
    {
        return Flights
            .Where(f => f.Destination == Destination)
            .Average(f => f.EstimatedDuration);
    }

    public IEnumerable<Flight> OrderedDurationFlights()
    {
        return Flights
            .OrderByDescending(f => f.EstimatedDuration);
    }
    
    public void DestinationGroupedFlights()
    {
        var flightsEnumerable = Flights
            .OrderBy(f => f.Destination)
            .ThenBy(f => f.FlightDate)
            .GroupBy(f => f.Destination);
        
        foreach (var group in flightsEnumerable)
        {
            Console.WriteLine("Destination : " + group.Key);
            foreach (var flight in group)
            {
                Console.WriteLine("Décollage : " + flight.FlightDate);
            }
        }
    }
}
