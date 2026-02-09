using AM.ApplicationDomain.Domains;

namespace AM.ApplicationCore.Interfaces;

public interface IFlightMethods
{
    List<Flight> Flights { get; set; }

    IEnumerable<DateTime> GetFlightDates(string destination);

    void GetFlights(string filterType, string filterValue);

    void ShowFlightDetails(Plane plane);

    int ProgrammedFlightNumber(DateTime startDate);

    IEnumerable<Traveller> SeniorTravellers(Flight flight);


}
