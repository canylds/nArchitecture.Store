using Core.Application.Responses;

namespace Application.Features.Customers.Commands.UpdateFromAuth;

public class UpdatedCustomerFromAuthResponse : IResponse
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Region { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }
    public string Phone { get; set; }

    public UpdatedCustomerFromAuthResponse()
    {
        Address = string.Empty;
        City = string.Empty;
        Region = string.Empty;
        PostalCode = string.Empty;
        Country = string.Empty;
        Phone = string.Empty;
    }

    public UpdatedCustomerFromAuthResponse(int id,
        int userId,
        string address,
        string city,
        string region,
        string postalCode,
        string country,
        string phone)
    {
        Id = id;
        UserId = userId;
        Address = address;
        City = city;
        Region = region;
        PostalCode = postalCode;
        Country = country;
        Phone = phone;
    }
}
