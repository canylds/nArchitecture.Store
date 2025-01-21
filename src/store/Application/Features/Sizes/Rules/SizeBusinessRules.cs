using Application.Features.Sizes.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exception.Types;
using Domain.Entities;

namespace Application.Features.Sizes.Rules;

public class SizeBusinessRules : BaseBusinessRules
{
    private readonly ISizeRepository _sizeRepository;

    public SizeBusinessRules(ISizeRepository sizeRepository)
    {
        _sizeRepository = sizeRepository;
    }

    public Task SizeShouldExistWhenSelected(Size? Size)
    {
        if (Size == null)
            throw new BusinessException(SizesMessages.NotExists);

        return Task.CompletedTask;
    }

    public async Task SizeIdShouldExistWhenSelected(int id)
    {
        bool doesExist = await _sizeRepository.AnyAsync(predicate: s => s.Id == id);

        if (doesExist)
            throw new BusinessException(SizesMessages.NotExists);
    }

    public async Task SizeNameShouldNotExistWhenCreating(string name)
    {
        bool doesExist = await _sizeRepository.AnyAsync(predicate: s => s.Name == name);

        if (doesExist)
            throw new BusinessException(SizesMessages.AlreadyExists);
    }

    public async Task SizeNameShouldNotExistWhenUpdating(int id, string name)
    {
        bool doesExist = await _sizeRepository.AnyAsync(predicate: s => s.Id != id && s.Name == name);

        if (doesExist)
            throw new BusinessException(SizesMessages.AlreadyExists);
    }
}
