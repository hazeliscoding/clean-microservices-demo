using FluentValidation.Results;

namespace Ordering.Application.Exceptions;

public class ValidationException() : ApplicationException("One or more validation error(s) occurred.")
{
    public IDictionary<string, string[]> Errors { get; } = new Dictionary<string, string[]>();

    public ValidationException(IEnumerable<ValidationFailure> failures) : this()
    {
        var failureGroups = failures
            .GroupBy(e => e.PropertyName, e => e.ErrorMessage);

        foreach (var failureGroup in failureGroups)
        {
            var propertyName = failureGroup.Key;
            var propertyFailures = failureGroup.ToArray();
            
            Errors.Add(propertyName, propertyFailures);
        }
    }
}