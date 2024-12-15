namespace Application.Filters;

public record SpecializationFilter(
    string? Name,
    string? Code
) : BaseFilter;