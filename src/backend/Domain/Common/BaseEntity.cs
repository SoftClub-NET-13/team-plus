namespace Domain.Common;

public abstract class BaseEntity
{
    public Guid Id { get; set; } = default!;
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.MinValue;
    public DateTimeOffset DeletedAt { get; set; } = DateTimeOffset.MinValue;
    public bool IsDeleted { get; set; }
    public long Version { get; set; } = 1;
    public bool IsActive { get; set; } = true;
}