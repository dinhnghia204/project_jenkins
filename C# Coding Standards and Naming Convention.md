# C# Coding Standards and Naming Convention

## Naming Conventions

### PascalCase
Use PascalCase for:
- Class names
- Method names
- Property names
- Public fields
- Namespaces

```csharp
public class CustomerService
{
    public string FirstName { get; set; }
    
    public void ProcessOrder()
    {
        // Implementation
    }
}
```

### camelCase
Use camelCase for:
- Local variables
- Method parameters
- Private fields (with underscore prefix)

```csharp
public class OrderProcessor
{
    private readonly ILogger _logger;
    
    public void ProcessOrder(int orderId, string customerName)
    {
        var orderTotal = 0;
        // Implementation
    }
}
```

### Interface Naming
Prefix interface names with 'I':

```csharp
public interface IOrderService
{
    Task<Order> GetOrderAsync(int id);
}
```

## Code Organization

### File Structure
- One class per file
- File name should match the class name
- Organize using statements alphabetically

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace UC.SOFTIP.Api.Services
{
    public class CustomerService : ICustomerService
    {
        // Implementation
    }
}
```

## Best Practices

### 1. Use var When Type is Obvious
```csharp
var customer = new Customer();
var orders = GetOrders();
```

### 2. Use String Interpolation
```csharp
var message = $"Hello, {userName}!";
```

### 3. Use Async/Await for I/O Operations
```csharp
public async Task<List<Order>> GetOrdersAsync()
{
    return await _context.Orders.ToListAsync();
}
```

### 4. Use LINQ for Collection Operations
```csharp
var activeOrders = orders.Where(o => o.IsActive).ToList();
```

### 5. Handle Exceptions Appropriately
```csharp
try
{
    await ProcessOrderAsync(orderId);
}
catch (OrderNotFoundException ex)
{
    _logger.LogError(ex, "Order not found: {OrderId}", orderId);
    throw;
}
```

## Comments

- Use XML documentation comments for public APIs
- Avoid obvious comments
- Explain "why", not "what"

```csharp
/// <summary>
/// Processes the order and sends confirmation email
/// </summary>
/// <param name="orderId">The unique identifier of the order</param>
/// <returns>True if processing was successful</returns>
public async Task<bool> ProcessOrderAsync(int orderId)
{
    // Implementation
}
```
