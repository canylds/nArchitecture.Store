using Core.Application.Dtos;

namespace Application.Features.Customers.Queries.GetList;

public class GetListCustomerListItemDto : IDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Region { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public GetListCustomerListItemDto()
    {
        Address = string.Empty;
        City = string.Empty;
        Region = string.Empty;
        PostalCode = string.Empty;
        Country = string.Empty;
        Phone = string.Empty;
        Email = string.Empty;
        FirstName = string.Empty;
        LastName = string.Empty;
    }

    public GetListCustomerListItemDto(int id,
        int userId,
        string address,
        string city,
        string region,
        string postalCode,
        string country,
        string phone,
        string email,
        string firstName,
        string lastName)
    {
        Id = id;
        UserId = userId;
        Address = address;
        City = city;
        Region = region;
        PostalCode = postalCode;
        Country = country;
        Phone = phone;
        Email = email;
        FirstName = firstName;
        LastName = lastName;
    }
}
