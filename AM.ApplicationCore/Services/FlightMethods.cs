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

        foreach (var flight in Flights)
        {
            if (flight.Destination == destination)
            {
                flightDates.Add(flight.FlightDate);
            }
        }

        return flightDates;
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
}