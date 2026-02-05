# JavaScript Name and Coding Conventions

## Naming Conventions

### Variables and Functions
Use camelCase for variables and function names:

```javascript
let userName = 'John Doe';
let orderTotal = 0;

function calculateTotal(items) {
    return items.reduce((sum, item) => sum + item.price, 0);
}
```

### Constants
Use UPPER_SNAKE_CASE for constants:

```javascript
const MAX_RETRY_ATTEMPTS = 3;
const API_BASE_URL = 'https://api.example.com';
```

### Classes
Use PascalCase for class names:

```javascript
class CustomerService {
    constructor(apiClient) {
        this.apiClient = apiClient;
    }
    
    async getCustomer(id) {
        return await this.apiClient.get(`/customers/${id}`);
    }
}
```

### Private Properties
Use underscore prefix for private properties:

```javascript
class OrderProcessor {
    constructor() {
        this._orders = [];
    }
    
    _validateOrder(order) {
        // Private method
    }
}
```

## Code Style

### Use Modern ES6+ Syntax

#### Arrow Functions
```javascript
const numbers = [1, 2, 3, 4, 5];
const doubled = numbers.map(n => n * 2);
```

#### Destructuring
```javascript
const { firstName, lastName } = user;
const [first, second, ...rest] = items;
```

#### Template Literals
```javascript
const greeting = `Hello, ${userName}!`;
```

#### Async/Await
```javascript
async function fetchUserData(userId) {
    try {
        const response = await fetch(`/api/users/${userId}`);
        const data = await response.json();
        return data;
    } catch (error) {
        console.error('Error fetching user:', error);
        throw error;
    }
}
```

### Use const and let
Avoid using `var`. Use `const` by default, `let` only when reassignment is needed:

```javascript
const MAX_ITEMS = 100;
let currentCount = 0;
```

### Function Declaration vs Expression
Prefer arrow functions for callbacks, regular functions for methods:

```javascript
// Good for callbacks
items.forEach(item => console.log(item));

// Good for methods
function processOrder(order) {
    // Implementation
}
```

## Best Practices

### 1. Always Use Semicolons
```javascript
const name = 'John';
const age = 30;
```

### 2. Use Strict Equality
```javascript
if (value === null) { }  // Good
if (value == null) { }   // Avoid
```

### 3. Handle Promises Properly
```javascript
getData()
    .then(data => processData(data))
    .catch(error => handleError(error))
    .finally(() => cleanup());
```

### 4. Use Meaningful Variable Names
```javascript
// Bad
const x = getUserData();

// Good
const userData = getUserData();
```

### 5. Comment Wisely
```javascript
// Calculate total with tax and discount
function calculateFinalPrice(basePrice, taxRate, discount) {
    const taxAmount = basePrice * taxRate;
    const discountAmount = basePrice * discount;
    return basePrice + taxAmount - discountAmount;
}
```
