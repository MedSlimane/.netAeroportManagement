namespace AM.ApplicationDomain.Domains;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Passenger
{
    public int Id { get; set; }
    
    [Display(Name = "Date of Birth")]
    [DataType(DataType.Date)]
    public DateTime BirthDate { get; set; }
    
    [EmailAddress]
    public string EmailAddress { get; set; }
    
    [MinLength(3, ErrorMessage = "FirstName must be at least 3 characters")]
    [MaxLength(25, ErrorMessage = "FirstName must be at most 25 characters")]
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    [StringLength(7)]
    public string PassportNumber { get; set; }
    
    [RegularExpression(@"^\d{8}$", ErrorMessage = "TelNumber must contain exactly 8 digits")]
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