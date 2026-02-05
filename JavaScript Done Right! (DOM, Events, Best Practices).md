# JavaScript Done Right! (DOM, Events, Best Practices)

## DOM Manipulation

### Query Selectors
Use modern query selectors instead of old methods:

```javascript
// Good
const element = document.querySelector('.my-class');
const elements = document.querySelectorAll('.my-class');

// Avoid
const element = document.getElementById('myId');
const elements = document.getElementsByClassName('my-class');
```

### Creating Elements
```javascript
const div = document.createElement('div');
div.className = 'container';
div.textContent = 'Hello World';
div.setAttribute('data-id', '123');

document.body.appendChild(div);
```

### Modifying DOM
```javascript
// Add/remove classes
element.classList.add('active');
element.classList.remove('inactive');
element.classList.toggle('visible');

// Modify attributes
element.setAttribute('data-value', '123');
element.removeAttribute('disabled');

// Modify styles
element.style.display = 'none';
element.style.backgroundColor = '#f0f0f0';
```

## Event Handling

### Modern Event Listeners
Always use `addEventListener`:

```javascript
// Good
button.addEventListener('click', handleClick);

// Avoid
button.onclick = handleClick;
```

### Event Delegation
Use event delegation for dynamic elements:

```javascript
document.querySelector('.container').addEventListener('click', (e) => {
    if (e.target.matches('.delete-btn')) {
        deleteItem(e.target.dataset.id);
    }
});
```

### Preventing Default Behavior
```javascript
form.addEventListener('submit', (e) => {
    e.preventDefault();
    // Handle form submission
    submitForm();
});
```

### Removing Event Listeners
```javascript
function handleClick() {
    console.log('Clicked!');
}

button.addEventListener('click', handleClick);
// Later...
button.removeEventListener('click', handleClick);
```

## Async Operations

### Fetch API
```javascript
async function fetchData(url) {
    try {
        const response = await fetch(url, {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${token}`
            }
        });
        
        if (!response.ok) {
            throw new Error(`HTTP error! status: ${response.status}`);
        }
        
        const data = await response.json();
        return data;
    } catch (error) {
        console.error('Fetch error:', error);
        throw error;
    }
}
```

### POST Request
```javascript
async function postData(url, data) {
    const response = await fetch(url, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    });
    
    return await response.json();
}
```

## Best Practices

### 1. Avoid Global Variables
```javascript
// Bad
var globalVar = 'test';

// Good - use IIFE or modules
(function() {
    const localVar = 'test';
    // Use localVar
})();
```

### 2. Use Modules
```javascript
// module.js
export const API_URL = 'https://api.example.com';
export function fetchUsers() { }

// main.js
import { API_URL, fetchUsers } from './module.js';
```

### 3. Handle Errors Gracefully
```javascript
async function loadUserData() {
    try {
        const data = await fetchUserData();
        displayData(data);
    } catch (error) {
        showErrorMessage('Failed to load user data');
        logError(error);
    }
}
```

### 4. Debounce Expensive Operations
```javascript
function debounce(func, wait) {
    let timeout;
    return function executedFunction(...args) {
        const later = () => {
            clearTimeout(timeout);
            func(...args);
        };
        clearTimeout(timeout);
        timeout = setTimeout(later, wait);
    };
}

const searchInput = document.querySelector('#search');
searchInput.addEventListener('input', debounce((e) => {
    performSearch(e.target.value);
}, 300));
```

### 5. Use Data Attributes
```javascript
// HTML: <button data-id="123" data-action="delete">Delete</button>

button.addEventListener('click', (e) => {
    const id = e.target.dataset.id;
    const action = e.target.dataset.action;
    
    if (action === 'delete') {
        deleteItem(id);
    }
});
```

### 6. Optimize Performance
```javascript
// Cache DOM queries
const container = document.querySelector('.container');

// Use DocumentFragment for multiple inserts
const fragment = document.createDocumentFragment();
items.forEach(item => {
    const li = document.createElement('li');
    li.textContent = item;
    fragment.appendChild(li);
});
container.appendChild(fragment);
```

## Common Patterns

### Singleton Pattern
```javascript
const AppConfig = (function() {
    let instance;
    
    function createInstance() {
        return {
            apiUrl: 'https://api.example.com',
            timeout: 5000
        };
    }
    
    return {
        getInstance: function() {
            if (!instance) {
                instance = createInstance();
            }
            return instance;
        }
    };
})();
```

### Observer Pattern
```javascript
class EventEmitter {
    constructor() {
        this.events = {};
    }
    
    on(event, listener) {
        if (!this.events[event]) {
            this.events[event] = [];
        }
        this.events[event].push(listener);
    }
    
    emit(event, data) {
        if (this.events[event]) {
            this.events[event].forEach(listener => listener(data));
        }
    }
}
```
