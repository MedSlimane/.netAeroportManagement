namespace AM.ApplicationDomain.Domains;

public class Flight
{
    public string Departure { get; set; }
    public string Destination { get; set; }
    public DateTime EffectiveArrival { get; set; }
    public int EstimatedDuration { get; set; }
    public DateTime FlightDate { get; set; }
    public int FlightId { get; set; }
    public Plane Plane { get; set; }
    public ICollection<Passenger> Passengers { get; set; }

    public override string ToString()
    {
        return
            $"{nameof(Departure)}: {Departure}, {nameof(Destination)}: {Destination}, {nameof(EffectiveArrival)}: {EffectiveArrival}, {nameof(EstimatedDuration)}: {EstimatedDuration}, {nameof(FlightDate)}: {FlightDate}, {nameof(FlightId)}: {FlightId}, {nameof(Plane)}: {Plane}, {nameof(Passengers)}: {Passengers}";
    }
}