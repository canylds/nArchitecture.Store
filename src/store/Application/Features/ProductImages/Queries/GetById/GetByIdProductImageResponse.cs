using Core.Application.Responses;

namespace Application.Features.ProductImages.Queries.GetById;

public class GetByIdProductImageResponse : IResponse
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string Url { get; set; }
    public string ProductName { get; set; }

    public GetByIdProductImageResponse()
    {
        Url = string.Empty;
        ProductName = string.Empty;
    }

    public GetByIdProductImageResponse(int id, int productId, string url, string productName)
    {
        Id = id;
        ProductId = productId;
        Url = url;
        ProductName = productName;
    }
}
