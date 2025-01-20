using Core.Application.Dtos;

namespace Application.Features.Employees.Queries.GetList;

public class GetListEmployeeListItemDto : IDto
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
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public GetListEmployeeListItemDto()
    {
        Title = string.Empty;
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

    public GetListEmployeeListItemDto(int id,
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
        FirstName = firstName;
        LastName = lastName;
    }
}
