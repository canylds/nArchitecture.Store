using Core.Application.Responses;

namespace Application.Features.Sizes.Commands.Create;

public class CreatedSizeResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }

    public CreatedSizeResponse()
    {
        Name = string.Empty;
    }

    public CreatedSizeResponse(int id, string name)
    {
        Id = id;
        Name = name;
    }
}
