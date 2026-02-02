using AM.ApplicationDomain.Domains;

namespace AM.ApplicationCore.Interfaces;

public interface IFlightMethods
{
    List<Flight> Flights { get; set; }

    List<DateTime> GetFlightDates(string destination);

    void GetFlights(string filterType, string filterValue);
}
