namespace AM.ApplicationDomain.Domains;

using System.ComponentModel.DataAnnotations.Schema;

public class Staff : Passenger
{
    public DateTime EmploymentDate { get; set; }
    public string Function { get; set; }
    
    [Column(TypeName = "decimal(18,2)")]
    public double Salary { get; set; }

    public override void PassengerType()
    {
        base.PassengerType();
        Console.WriteLine("I am a Staff Member");
    }
}
