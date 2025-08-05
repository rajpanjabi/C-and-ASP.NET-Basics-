# C# Quick Reference Guide

## Getting Started

### Essential Shortcuts
- **Compile:** `Ctrl + Shift + B`
- **Run:** `Ctrl + F5`
- **Debug:** `F5`
- **Breakpoint:** `F9`

### How C# Works
C# code gets converted to IML (Intermediate Language) - just like Java converts to bytecode first, then to native machine code. This is different from C/C++ and allows your code to run on any machine using CLR (Common Language Runtime).

---

## Code Organization Hierarchy

**Class** → **Namespace** → **Assembly**

- **Class:** Contains data (attributes) and methods
- **Namespace:** Groups related classes together (useful when you have thousands of classes)
- **Assembly:** Groups namespaces together when they grow too large

---

## Variables and Data Types

### Variable Basics
```csharp
int number;        // Declaration
int Number = 2;    // Declaration + Assignment
```
**Remember:** C# is case-sensitive! `number` and `Number` are different variables.

**Important:** Variables can only be used after they're assigned a value.

### Constants
```csharp
const float Pi = 3.14f;  // Immutable value that never changes
```

### Primitive Types
| C# Type | .NET Type | Example |
|---------|-----------|---------|
| `byte` | `Byte` | `byte num = 255;` |
| `short` | `Int16` | `short num = 1234;` |
| `int` | `Int32` | `int number = 42;` |
| `long` | `Int64` | `long big = 123456789L;` |
| `float` | `Single` | `float fnum = 3.14f;` |
| `double` | `Double` | `double dnum = 2.312;` (default) |
| `decimal` | `Decimal` | `decimal money = 1.2m;` |
| `char` | `Char` | `char letter = 'A';` |
| `bool` | `Boolean` | `bool check = false;` |

### Non-Primitive Types
- `String`
- `Enum`
- `Array`
- `Class`

### Variable Declaration Shortcut
```csharp
var num = 42;  // Compiler automatically determines the type
```

---

## Type Conversions

### 1. Implicit Conversion (Smaller → Bigger)
No data loss, system adds zeros in front.
```csharp
byte num = 2;      // 00000001
int num2 = num;    // 00000000000000000001
```

### 2. Explicit Conversion (Bigger → Smaller)
Risk of data loss, requires casting.
```csharp
float f = 1.0f;
int i = (int)f;
```

### 3. Non-Compatible Type Conversions
```csharp
string num = "1234";
// int num2 = (int)num;  // ❌ This won't work

int num2 = Convert.ToInt32(num);  // ✅ Use Convert class
```

### Exception Handling
```csharp
try 
{
    int result = Convert.ToInt32(userInput);
}
catch (Exception ex)
{
    Console.WriteLine("Invalid input!");
}
```

---

## Overflow Handling

Byte can store 0-255 (2^8 = 256 values). Overflow example:
```csharp
byte num = 255;
num += 1;  // Causes overflow

// Prevent with checked block:
checked 
{
    byte num = 255;
    num += 1;  // Throws exception instead of overflowing
}
```

---

## Scope Rules

```csharp
{
    byte a = 1;          // Accessible here and below
    {
        byte b = 2;      // Accessible here and below
        {
            byte c = 3;  // Only accessible in this block
        }
    }
}
```

---

## Operators

- **Arithmetic:** `+`, `-`, `*`, `/`, `++`, `--`
- **Comparison:** `==`, `!=`, `<`, `>`, `<=`, `>=`
- **Assignment:** `=`, `+=`, `-=`, `*=`, `/=`
- **Logical:** `&&`, `||`, `!`
- **Bitwise:** `&`, `|`

---

## Classes and Objects

### Class Definition
```csharp
public class Person
{
    public string Name;  // Field/Attribute

    public void Introduce()  // Method/Behavior
    {
        Console.WriteLine("Hi my name is " + Name);
    }
}
```

### Creating and Using Objects
```csharp
// Creating objects
Person person = new Person();
var person = new Person();  // Alternative syntax

// Using objects
var person = new Person();
person.Name = "Raj";
person.Introduce();
```

### Object Initialization Syntax
```csharp
var person = new Person { FirstName = "Mosh", LastName = "Hamedani" };
```

---

## Class Members

### 1. Instance Members
Specific to each object instance.
```csharp
var person = new Person();
person.Introduce();  // Called on specific instance
```

### 2. Static Members
Belong to the class itself, not instances.
```csharp
public static int peopleCount = 1;

// Usage
Console.WriteLine();  // Console is static
```

**Why use static?** For singleton concepts where you only need one instance (like DateTime, Console).

---

## Constructors

Same name as class, no return type.

```csharp
public class Customer
{
    public string Name;

    // Default constructor
    public Customer()
    {
    }

    // Parameterized constructor
    public Customer(string name)
    {
        this.Name = name;  // 'this' refers to current instance
    }
}
```

### Constructor Overloading
Multiple constructors with different signatures (parameters).

```csharp
public Customer() { }

public Customer(string name) { }

public Customer(int id, string name) { }
```

---

## Fields

### Readonly Fields
```csharp
public class Customer
{
    readonly List<Order> Orders = new List<Order>();
    // Can only be set during declaration or in constructor
}
```

---

## Methods

### Method Signature
Consists of: name + number and type of parameters

### Method Overloading
Same method name, different signatures.

```csharp
public void Calculate() { }
public void Calculate(int number) { }
public void Calculate(int number, string type) { }
```

---

## Access Modifiers

Controls who can access classes and their members. Part of **Encapsulation** (OOP principle).

| Modifier | Access Level |
|----------|-------------|
| `public` | Everywhere |
| `private` | Only inside the same class |
| `protected` | Inside class + subclasses |
| `internal` | Inside the same project |
| `protected internal` | Subclasses + same project |
| `private protected` | Subclasses in same project only |

### Encapsulation Best Practice
- Make fields `private`
- Create `public` getters and setters
- Private fields use camelCase with underscore: `_firstName`

**Key Principle:** Objects should hide their implementation details - show what they can do, not how they do it.

---

## Interfaces

Similar to classes but fundamentally different.

```csharp
public interface ITaxCalculator  // Name starts with 'I'
{
    int Calculate();  // No access modifiers, no implementation
}
```

**Purpose:** Build loosely coupled applications. All classes should be loosely coupled.

**Key Points:**
- No access modifiers
- No implementation, just declarations
- Promotes loose coupling between classes

---

## Quick Tips

- **Naming Convention:** C# uses PascalCase (first character capitalized)
- **Case Sensitivity:** Remember that C# is case-sensitive
- **OOP Principles:** Encapsulation, Inheritance, Polymorphism
- **Loose Coupling:** Use interfaces to reduce dependencies between classes

---

*This reference covers the fundamentals - keep it handy for quick refreshers!*
