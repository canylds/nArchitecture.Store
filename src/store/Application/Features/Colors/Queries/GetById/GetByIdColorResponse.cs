using Core.Application.Responses;

namespace Application.Features.Colors.Queries.GetById;

public class GetByIdColorResponse : IResponse
{
    public int Id { get; set; }

    public GetByIdColorResponse()
    {

    }

    public GetByIdColorResponse(int id)
    {
        Id = id;
    }
}
