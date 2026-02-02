// See https://aka.ms/new-console-template for more information
using AM.ApplicationDomain.Domains;
using AM.ApplicationCore.Services;

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

FlightMethods flightService = new FlightMethods();

// You can add flights to flightService.Flights and test:
// flightService.Flights = TestData.listFlights; // If you create test data
// var parisDates = flightService.GetFlightDates("Paris");
// flightService.GetFlights("Destination", "Paris");
