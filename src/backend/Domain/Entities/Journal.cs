namespace Domain.Entities;

public class Journal : BaseEntity
{
    public DateTimeOffset Date { get; set; }
    public decimal Price { get; set; }
    public string? Comment { get; set; }
    public int Late { get; set; }
    public bool IsPaid { get; set; }

    public DateTimeOffset? DueDate { get; set; }

    //for minute
    public decimal LatePenalty { get; set; }

    public Guid EmployeeId { get; set; }
    public Employee Employee { get; set; } = null!;
}