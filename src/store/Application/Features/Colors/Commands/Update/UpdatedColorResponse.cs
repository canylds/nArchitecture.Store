using Core.Application.Responses;

namespace Application.Features.Colors.Commands.Update;

public class UpdatedColorResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }

    public UpdatedColorResponse()
    {
        Name = string.Empty;
    }

    public UpdatedColorResponse(int id, string name)
    {
        Id = id;
        Name = name;
    }
}
