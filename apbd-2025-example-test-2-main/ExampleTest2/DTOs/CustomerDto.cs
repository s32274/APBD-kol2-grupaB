using ExampleTest2.Models;

namespace ExampleTest2.DTOs;

public class CustomerDto 
{
    public int CustomerId { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? PhoneNumber { get; set; } = null!;
    
    public List<PurchasedTicketDto> Purchases { get; set; } = null!;
}

public class PurchasedTicketDto
{
    public DateTime Date { get; set; }
    public double Price { get; set; }

    public TicketDto Ticket { get; set; } = null!;
    public ConcertDto Concert { get; set; } = null!;
}

public class TicketDto
{
    public string Serial {get; set;} = null!;
    public int SeatNumber {get; set;}
}

public class ConcertDto
{
    public string Name {get; set;} = null!;
    public DateTime Date {get; set;}
}