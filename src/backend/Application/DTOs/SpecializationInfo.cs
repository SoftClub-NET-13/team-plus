namespace Application.DTOs;

public interface IBaseSpecializationInfo
{
    public string Name { get; init; }
    public string Code { get; init; }
}

public readonly record struct SpecializationReadInfo(
    string Name,
    string Code,
    Guid Id) : IBaseSpecializationInfo;

public readonly record struct SpecializationUpdateInfo(
    string Name,
    string Code,
    bool IsActive) : IBaseSpecializationInfo;

public readonly record struct SpecializationCreateInfo(
    string Name,
    string Code) : IBaseSpecializationInfo;