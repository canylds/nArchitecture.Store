using Core.Application.Responses;

namespace Application.Features.Sizes.Queries.GetById;

public class GetByIdSizeResponse : IResponse
{
    public int Id { get; set; }

    public GetByIdSizeResponse()
    {

    }

    public GetByIdSizeResponse(int id)
    {
        Id = id;
    }
}
