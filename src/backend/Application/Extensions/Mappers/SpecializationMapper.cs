namespace Application.Extensions.Mappers;

public static class SpecializationMapper
{
    public static SpecializationReadInfo ToRead(this Specialization specialization)
    {
        return new SpecializationReadInfo(
            specialization.Name,
            specialization.Code,
            specialization.Id);
    }

    public static Specialization ToEntity(this SpecializationCreateInfo createInfo)
    {
        return new Specialization
        {
            Name = createInfo.Name,
            Code = createInfo.Code,
        };
    }

    public static Specialization ToEntity(this Specialization entity, SpecializationUpdateInfo updateInfo)
    {
        entity.Code = updateInfo.Code;
        entity.Name = updateInfo.Name;
        entity.Version++;
        entity.UpdatedAt = DateTimeOffset.UtcNow;
        entity.IsActive = updateInfo.IsActive;
        return entity;
    }

    public static Specialization ToDelete(this Specialization entity)
    {
        entity.Version++;
        entity.UpdatedAt = DateTimeOffset.UtcNow;
        entity.IsDeleted = true;
        entity.DeletedAt = DateTimeOffset.UtcNow;
        return entity;
    }
}