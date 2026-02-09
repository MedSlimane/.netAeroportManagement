// See https://aka.ms/new-console-template for more information

using AM.ApplicationCore.Domain;
using AM.ApplicationDomain.Domains;
using AM.ApplicationCore.Services;
using AM.Application.Core.Services;

Plane p = new Plane(250,
    new DateTime(2020, 10, 10),
    1,
    PlaneType.Airbus,
    new List<Flight>()
    );
Plane p2 = new Plane();
p2.Capacity = 300;
p2.ManufactureDate = new DateTime(2020, 10, 10);
p2.PlaneType = PlaneType.Airbus;
p2.PlaneId = 2;

Console.WriteLine(p);
Console.WriteLine(p2);

Passenger passenger = new Passenger(
    firstName: "dahmen",
    lastName: "dah dah",
    emailAddress: "dah@dah.com"
    );
Console.WriteLine(passenger.CheckProfile("dah", "dah"));
Console.WriteLine(passenger.CheckProfile("dahmen", "dah dah"));
Console.WriteLine(passenger.CheckProfile("dah", "dah", "gege"));
Console.WriteLine(passenger.login("dahmen", "dah dah"));

// ========================================
// Test Polymorphism by Inheritance (PassengerType)
// ========================================
Console.WriteLine("\n--- Testing PassengerType Polymorphism ---");

Passenger p1 = new Passenger("test@test.com", "John", "Doe");
Staff staff = new Staff
{
    FirstName = "Alice",
    LastName = "Smith",
    EmailAddress = "alice@airline.com",
    EmploymentDate = new DateTime(2020, 1, 1),
    Salary = 50000
};
Traveller traveller = new Traveller
{
    FirstName = "Bob",
    LastName = "Johnson",
    EmailAddress = "bob@email.com",
    Nationality = "French",
    HealthInformation = "No troubles"
};

Console.WriteLine("\nPassenger:");
p1.PassengerType();

Console.WriteLine("\nStaff:");
staff.PassengerType();

Console.WriteLine("\nTraveller:");
traveller.PassengerType();

// ========================================
// Test FlightMethods Service
// ========================================
Console.WriteLine("\n--- Testing FlightMethods Service ---");


// You can add flights to flightService.Flights and test:,,,,,
// flightService.Flights = TestData.listFlights; // If you create test data
// var parisDates = flightService.GetFlightDates("Paris");
// flightService.GetFlights("Destination", "Paris");


FlightMethods flightService = new FlightMethods();
List<Flight> flights = TestData.listFlights;
flightService.Flights = flights;


IEnumerable<DateTime> dateTimes = flightService.GetFlightDates("Paris");
foreach (DateTime date in dateTimes)
{
    Console.WriteLine(date);
}
flightService.GetFlights("Destination", "Paris");

flightService.ShowFlightDetails(TestData.Airbusplane);
int count = flightService.ProgrammedFlightNumber(new DateTime(2022, 01, 01));
Console.WriteLine($"Number of flights programmed after 01/01/2022: {count}");

foreach (var traveller1 in flightService.SeniorTravellers(TestData.flight1))
{
    Console.WriteLine(traveller1.BirthDate);
}

Passenger passenger2 = new 
    Passenger { FirstName = "mohamed", LastName = "slimane"};

passenger2.UpperFullName();
Console.WriteLine(passenger2.FirstName + passenger2.LastName);