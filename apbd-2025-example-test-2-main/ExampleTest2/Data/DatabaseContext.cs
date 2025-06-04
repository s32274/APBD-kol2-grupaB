using ExampleTest2.Models;
using Microsoft.EntityFrameworkCore;

namespace ExampleTest2.Data;

public class DatabaseContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Concert> Concerts { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<PurchasedTicket> PurchasedTickets { get; set; }
    public DbSet<TicketConcert> TicketConcerts { get; set; }
    
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>().HasData(new List<Customer>()
        {
            new Customer() 
            {
                CustomerId = 1, 
                FirstName = "John", 
                LastName = "Doe", 
                PhoneNumber = "12345678" 
            }
        });
        
        modelBuilder.Entity<Concert>().HasData(new List<Concert>()
        {
            new Concert() { ConcertId = 1, Name = "Concert 1", Date = DateTime.Parse("2025-05-02"), AvailableTickets = 20},
            new Concert() { ConcertId = 2, Name = "Concert 2" , Date = DateTime.Parse("2025-05-02"), AvailableTickets = 30}
        });
        
        modelBuilder.Entity<Ticket>().HasData(new List<Ticket>()
        {
            new Ticket() { TicketId = 1, SerialNumber = "123", SeatNumber = 1 },
            new Ticket() { TicketId = 2, SerialNumber = "456", SeatNumber = 2 },
            new Ticket() { TicketId = 3, SerialNumber = "789", SeatNumber = 3 }
        });
        
        modelBuilder.Entity<TicketConcert>().HasData(new List<TicketConcert>()
        {
            new TicketConcert() { TicketConcertId = 1, TicketId = 1, ConcertId = 1, Price = 33.4 },
            new TicketConcert() { TicketConcertId = 2, TicketId = 2, ConcertId = 2, Price = 33.4 }
        });
        
        modelBuilder.Entity<PurchasedTicket>().HasData(new List<PurchasedTicket>()
        {
            new PurchasedTicket() { TicketConcertId = 1, CustomerId = 1, PurchaseDate = DateTime.Parse("2025-05-02")},
            new PurchasedTicket() { TicketConcertId = 2, CustomerId = 1, PurchaseDate = DateTime.Parse("2025-05-03")}
        });
        
        
    }
}