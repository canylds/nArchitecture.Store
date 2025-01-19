using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Employee : Entity<int>
{
    public int UserId { get; set; }
    public string Title { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime HireDate { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Region { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }
    public string Phone { get; set; }
    public string? PhotoUrl { get; set; }

    public virtual User User { get; set; } = default!;

    public Employee()
    {
        Title = string.Empty;
        Address = string.Empty;
        City = string.Empty;
        Region = string.Empty;
        PostalCode = string.Empty;
        Country = string.Empty;
        Phone = string.Empty;
    }

    public Employee(int userId,
        string title,
        DateTime birthDate,
        DateTime hireDate,
        string address,
        string city,
        string region,
        string postalCode,
        string country,
        string phone,
        string? photoUrl)
    {
        UserId = userId;
        Title = title;
        BirthDate = birthDate;
        HireDate = hireDate;
        Address = address;
        City = city;
        Region = region;
        PostalCode = postalCode;
        Country = country;
        Phone = phone;
        PhotoUrl = photoUrl;
    }

    public Employee(int id,
        int userId,
        string title,
        DateTime birthDate,
        DateTime hireDate,
        string address,
        string city,
        string region,
        string postalCode,
        string country,
        string phone,
        string? photoUrl) : base(id)
    {
        UserId = userId;
        Title = title;
        BirthDate = birthDate;
        HireDate = hireDate;
        Address = address;
        City = city;
        Region = region;
        PostalCode = postalCode;
        Country = country;
        Phone = phone;
        PhotoUrl = photoUrl;
    }
}