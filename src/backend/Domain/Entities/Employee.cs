using Domain.Common;
using Domain.Constants;
using Domain.Enums;

namespace Domain.Entities;

public sealed class Employee : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public Gender Gender { get; set; }
    public DateTime DateOfBirth { get; set; }
    public EmployeeStatus Status { get; set; } = EmployeeStatus.Active;
    public DateTime HireDate { get; set; }
    public DateTime LeftDate { get; set; }
    public string ProfilePictureUrl { get; set; } = FileData.DefaultEmployee;
    
    public Guid LocationId { get; set; }
    public Location? Location { get; set; }
    
    public ICollection<Journal> Journals { get; set; } = [];
    public ICollection<EmployeeSpecialization> EmployeeSpecializations { get; set; } = [];
}