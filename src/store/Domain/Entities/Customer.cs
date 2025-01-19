using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Customer : Entity<int>
{
    public int UserId { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Region { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }
    public string Phone { get; set; }

    public virtual User User { get; set; } = default!;

    public Customer()
    {
        Address = string.Empty;
        City = string.Empty;
        Region = string.Empty;
        PostalCode = string.Empty;
        Country = string.Empty;
        Phone = string.Empty;
    }

    public Customer(int userId, 
        string address, 
        string city, 
        string region, 
        string postalCode, 
        string country, 
        string phone)
    {
        UserId = userId;
        Address = address;
        City = city;
        Region = region;
        PostalCode = postalCode;
        Country = country;
        Phone = phone;
    }

    public Customer(int id,
        int userId,
        string address,
        string city,
        string region,
        string postalCode,
        string country,
        string phone) : base(id)
    {
        UserId = userId;
        Address = address;
        City = city;
        Region = region;
        PostalCode = postalCode;
        Country = country;
        Phone = phone;
    }
}