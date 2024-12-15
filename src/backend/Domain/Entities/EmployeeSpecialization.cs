using Domain.Common;

namespace Domain.Entities;

public class EmployeeSpecialization : BaseEntity
{
    public Guid EmployeeId { get; set; }
    public Guid SpecializationId { get; set; }

    public Employee? Employee { get; set; }
    public Specialization? Specialization { get; set; }
}