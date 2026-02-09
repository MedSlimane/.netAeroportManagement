namespace AM.ApplicationDomain.Domains;

public class Staff : Passenger
{
    public DateTime EmploymentDate { get; set; }
    public string Function { get; set; }
    public double Salary { get; set; }

    public override void PassengerType()
    {
        base.PassengerType();
        Console.WriteLine("I am a Staff Member");
    }
}
