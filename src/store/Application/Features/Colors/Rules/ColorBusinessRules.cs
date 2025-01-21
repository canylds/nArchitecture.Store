using Application.Features.Colors.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exception.Types;
using Domain.Entities;

namespace Application.Features.Colors.Rules;

public class ColorBusinessRules : BaseBusinessRules
{
    private readonly IColorRepository _colorRepository;

    public ColorBusinessRules(IColorRepository colorRepository)
    {
        _colorRepository = colorRepository;
    }

    public Task ColorShouldExistWhenSelected(Color? color)
    {
        if (color == null)
            throw new BusinessException(ColorsMessages.NotExists);

        return Task.CompletedTask;
    }

    public async Task ColorIdShouldExistWhenSelected(int id)
    {
        bool doesExist = await _colorRepository.AnyAsync(predicate: c => c.Id == id);

        if (doesExist)
            throw new BusinessException(ColorsMessages.NotExists);
    }

    public async Task ColorNameShouldNotExistWhenCreating(string name)
    {
        bool doesExist = await _colorRepository.AnyAsync(predicate: c => c.Name == name);

        if (doesExist)
            throw new BusinessException(ColorsMessages.AlreadyExists);
    }

    public async Task ColorNameShouldNotExistWhenUpdating(int id, string name)
    {
        bool doesExist = await _colorRepository.AnyAsync(predicate: c => c.Id != id && c.Name == name);

        if (doesExist)
            throw new BusinessException(ColorsMessages.AlreadyExists);
    }
}
