using Core.Application.Dtos;
using Core.Application.Responses;

namespace Application.Features.ProductImages.Commands.CreateBulk;

public class CreatedBulkProductImageResponse : IResponse
{
    public int ProductId { get; set; }
    public List<CbpirProductImageDto> ProductImages { get; set; }

    public CreatedBulkProductImageResponse()
    {
        ProductImages = null!;
    }

    public CreatedBulkProductImageResponse(int productId, List<CbpirProductImageDto> productImages)
    {
        ProductId = productId;
        ProductImages = productImages;
    }
}

public class CbpirProductImageDto : IDto
{
    public int Id { get; set; }
    public string Url { get; set; }

    public CbpirProductImageDto()
    {
        Url = string.Empty;
    }

    public CbpirProductImageDto(int id, string url)
    {
        Id = id;
        Url = url;
    }
}
