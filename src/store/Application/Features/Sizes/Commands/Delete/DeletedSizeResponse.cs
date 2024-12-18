﻿using Core.Application.Responses;

namespace Application.Features.Sizes.Commands.Delete;

public class DeletedSizeResponse : IResponse
{
    public int Id { get; set; }

    public DeletedSizeResponse()
    {

    }

    public DeletedSizeResponse(int id)
    {
        Id = id;
    }
}
