namespace AM.ApplicationDomain.Domains;

using System.ComponentModel.DataAnnotations;

public class Plane
{
    [Range(1, int.MaxValue, ErrorMessage = "Capacity must be a positive integer")]
    public int Capacity { get; set; }
    public DateTime ManufactureDate { get; set; }
    public int PlaneId { get; set; }
    public PlaneType PlaneType { get; set; }
    public ICollection<Flight> Flights { get; set; }

    public Plane()
    {
    }

    public Plane(int capacity, DateTime manufactureDate, int planeId, PlaneType planeType, ICollection<Flight> flights)
    {
        Capacity = capacity;
        ManufactureDate = manufactureDate;
        PlaneId = planeId;
        PlaneType = planeType;
        Flights = flights;
    }

    public override string ToString() => $"Plane [{PlaneId}]: {PlaneType}, Capacity: {Capacity}";
}