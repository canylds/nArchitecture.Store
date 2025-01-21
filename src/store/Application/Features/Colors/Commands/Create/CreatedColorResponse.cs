using Core.Application.Responses;



namespace Application.Features.Colors.Commands.Create;

public class CreatedColorResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }

    public CreatedColorResponse()
    {
        Name = string.Empty;
    }

    public CreatedColorResponse(int id, string name)
    {
        Id = id;
        Name = name;
    }
}
