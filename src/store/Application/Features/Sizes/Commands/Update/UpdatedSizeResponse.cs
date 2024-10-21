using Core.Application.Responses;

namespace Application.Features.Sizes.Commands.Update;

public class UpdatedSizeResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }

    public UpdatedSizeResponse()
    {
        Name = string.Empty;
    }

    public UpdatedSizeResponse(int id, string name)
    {
        Id = id;
        Name = name;
    }
}
