using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ExampleTest2.Models;

[Table("Purchased_Ticket")]
[PrimaryKey(nameof(TicketConcertId), nameof(CustomerId))]
public class PurchasedTicket
{
    [ForeignKey(nameof(Customer))]
    public int CustomerId { get; set; }
    
    [ForeignKey(nameof(TicketConcert))]
    public int TicketConcertId { get; set; }
    
    public DateTime PurchaseDate { get; set; }
    
    public TicketConcert TicketConcert { get; set; } = null!;
    public Customer Customer { get; set; } = null!;

}