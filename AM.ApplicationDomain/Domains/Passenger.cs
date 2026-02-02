namespace AM.ApplicationDomain.Domains;

public class Passenger
{
    public int Id { get; set; }
    public DateTime BirthDate { get; set; }
    public string EmailAddress { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PassportNumber { get; set; }
    public int TelNumber { get; set; }
    public ICollection<Flight> Flights { get; set; }

    public Passenger(string emailAddress, string firstName, string lastName)
    {
        EmailAddress = emailAddress;
        FirstName = firstName;
        LastName = lastName;
    }
    public Passenger() { }


    public bool CheckProfile(string firstName, string lastName)
    {
        return (FirstName == firstName) && (LastName == lastName);
    }

    public bool CheckProfile(string firstName, string lastName, string emailAddress)
    {
        return CheckProfile(firstName, lastName) && emailAddress == EmailAddress;
    }

    public bool login(string firstName, string lastName, string emailAddress = null)
    {
        if (emailAddress == null)
            return CheckProfile(firstName, lastName);
        return CheckProfile(firstName, lastName, emailAddress);

    }

    public virtual void PassengerType()
    {
        Console.WriteLine("I am a passenger");
    }
}