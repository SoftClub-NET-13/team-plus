using Domain.Common;

namespace Domain.Entities;

public class Specialization : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public ICollection<EmployeeSpecialization> EmployeeSpecializations { get; set; } = [];
}