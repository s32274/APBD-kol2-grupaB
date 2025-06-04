using System.Data;
using ExampleTest2.Data;
using ExampleTest2.DTOs;
using ExampleTest2.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace ExampleTest2.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;

    public DbService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<CustomerDto> GetOrdersByCustomerId(int customerId)
    {
        var order = await _context.Customers
            .Select(e => new CustomerDto()
            {
                FirstName = e.FirstName,
                LastName = e.LastName,
                PhoneNumber = e.PhoneNumber,
                Purchases = e.PurchasedTickets.Select(pt => new PurchasedTicketDto()
                {
                    Date = pt.TicketConcert.Concert.Date,
                    Price = pt.TicketConcert.Price,
                    Ticket = new TicketDto()
                    {
                        Serial = pt.TicketConcert.Ticket.SerialNumber,
                        SeatNumber = pt.TicketConcert.Ticket.SeatNumber
                    },
                    Concert = new ConcertDto()
                    {
                        Name = pt.TicketConcert.Concert.Name,
                        Date = pt.TicketConcert.Concert.Date
                    }
                }).ToList()
            })
            .FirstOrDefaultAsync(e => e.CustomerId == customerId);

        if (order is null)
            throw new NotFoundException();
        
        return order;
    }
    
}