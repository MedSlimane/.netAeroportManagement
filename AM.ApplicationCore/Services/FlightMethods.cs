using System.Reflection;
using AM.ApplicationCore.Interfaces;
using AM.ApplicationDomain.Domains;

namespace AM.ApplicationCore.Services;

public class FlightMethods : IFlightMethods
{
    public List<Flight> Flights { get; set; } = new List<Flight>();
    
    public List<DateTime> GetFlightDates(string destination)
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
        Console.WriteLine($"Flights where {filterType} = {filterValue}:");
        Console.WriteLine("----------------------------------------");

        PropertyInfo? property = typeof(Flight).GetProperty(filterType);

        if (property == null)
        {
            Console.WriteLine($"Property '{filterType}' not found in Flight class.");
            return;
        }

        foreach (var flight in Flights)
        {
            var propertyValue = property.GetValue(flight);

            if (propertyValue != null && propertyValue.ToString() == filterValue)
            {
                Console.WriteLine($"Flight to {flight.Destination} on {flight.FlightDate}, Duration: {flight.EstimatedDuration} min");
            }
        }
    }
}
