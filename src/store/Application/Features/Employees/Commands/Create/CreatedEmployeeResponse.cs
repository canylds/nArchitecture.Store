using Core.Application.Responses;

namespace Application.Features.Employees.Commands.Create;

public class CreatedEmployeeResponse : IResponse
{
    public int Id { get; set; }
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
    public string Email { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public CreatedEmployeeResponse()
    {
        Title = string.Empty;
        Address = string.Empty;
        City = string.Empty;
        Region = string.Empty;
        PostalCode = string.Empty;
        Country = string.Empty;
        Phone = string.Empty;
        Email = string.Empty;
        Password = string.Empty;
        FirstName = string.Empty;
        LastName = string.Empty;
    }

    public CreatedEmployeeResponse(int id,
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
        string? photoUrl,
        string email,
        string password,
        string firstName,
        string lastName)
    {
        Id = id;
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
        Email = email;
        Password = password;
        FirstName = firstName;
        LastName = lastName;
    }
}
