using Core.Application.Responses;

namespace Application.Features.ProductImages.Commands.Delete;

public class DeletedProductImageResponse : IResponse
{
    public int Id { get; set; }

    public DeletedProductImageResponse()
    {

    }

    public DeletedProductImageResponse(int id)
    {
        Id = id;
    }
}
