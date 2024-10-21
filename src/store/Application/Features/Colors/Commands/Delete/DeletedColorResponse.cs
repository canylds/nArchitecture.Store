using Core.Application.Responses;

namespace Application.Features.Colors.Commands.Delete;

public class DeletedColorResponse : IResponse
{
    public int Id { get; set; }

    public DeletedColorResponse()
    {

    }

    public DeletedColorResponse(int id)
    {
        Id = id;
    }
}
