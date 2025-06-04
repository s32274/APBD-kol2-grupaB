using ExampleTest2.DTOs;

namespace ExampleTest2.Services;

public interface IDbService
{
    Task<CustomerDto> GetOrdersByCustomerId(int customerId);
}