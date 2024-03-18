namespace Ordering.Application.Extensions;

public class OrderNotFoundException(string name, object key) : Exception($"Entity \"{name}\" ({key}) was not found.");