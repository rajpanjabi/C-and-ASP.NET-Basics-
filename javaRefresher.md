# Java Fundamentals - Complete Study Notes

## 1. Java Environment Basics

### JRE (Java Runtime Environment)
- Includes everything you need to run Java programs
- Contains Java Standard Library (Object, Lang, Math classes, java.io, SQL, input, output)

### JVM (Java Virtual Machine)
- Handles garbage collection and multithreading
- Runs code on any platform
- Java garbage collector (maybe uses a heap)

### JDK (Java Development Kit)
- Includes everything needed to create, debug, and compile Java code

### How Java Code Works
1. **Compilation Stage**: Our source code (.java) is compiled and converted to bytecode (.class) through compiler in JDK
2. **Execution Stage**: This bytecode is converted to native code using JVM

---

## 2. Data Types

### Primitive Data Types (8 in total)
- **byte**: 1 byte = 8 bits
- **short**: 2 bytes
- **int**: 4 bytes  
- **long**: 8 bytes
- **float**: 4 bytes
- **double**: 8 bytes
- **char**: 2 bytes
- **boolean**: 1 byte

### Non-Primitive Data Types
- String, Class, Object, Array, Interface

---

## 3. String Operations

### Important String Methods
```java
// To compare strings
string1.compareTo(string2)

// To get character at specific index
string.charAt(index)

// To get substring (start inclusive, end non-inclusive)
string.substring(startIdx, endIdx)
```

### String Immutability
- Strings are immutable
- When we change a string, a new memory location is created
- There's a **String Pool** - if multiple variables have same value like "Raj", they point to same location
- This saves memory and helps with security, storage savings, etc.

---

## 4. Memory Storage in Java

### Two Types of Memory Storage:
1. **Stack**: Variable names are stored here
2. **Heap**: Values are stored here

**How it works**: Variable name is stored in stack and it points to a memory address in heap where the actual value is stored.

---

## 5. Classes and Objects

### What is a Class?
- A class is a blueprint
- Contains attributes/properties of class and actions/methods/functions
- **Important**: A class is just a template. You need to create objects (instances) from it to actually use it.

### Access Modifiers
- **public**: Can be accessed anywhere  
- **default**: Can be used in the same package
- **protected**: Can be accessed in the class, subclass, packages
- **private**: Cannot be accessed outside of the class. It can be used using getters and setters

### Methods Types

#### Non-Static Methods
- Needs an object to be called
```java
void start() {
    System.out.println("Car is starting...");
}

void accelerate() {
    speed += 10;
    System.out.println("Speed is now: " + speed);
}
```

#### Static Methods  
- Can be called without creating an object
- **Static means**: "this belongs to the class itself, not to any specific object"
```java
static void statmethod() {
    System.out.println("This is a static method which doesn't require to be called with an object");
}
```

### Creating and Using Objects
```java
// This is how an object is created
JavaFundamentals object = new JavaFundamentals();

// To access properties: object.attribute
// To run methods: object.method()
// To set color or attribute
object.color = "Red";
System.out.println(object.color);

// Static method call
JavaFundamentals.statmethod();

object.start();
```

---

## 6. Inheritance - Extends vs Implements

### WTF is the difference between extends and implements?

#### Extends
- Means "This class is a specialized version of other class"
- **Extends = Is-A-Relationship** (i.e., Dog is an Animal)
- Child class gets all the public/protected attributes, properties, methods of parent class
- Can override any method or attribute, and add new methods or attributes too

**Example:**
```java
// Parent class (superclass)
class Animal {
    String name;
    
    void eat() {
        System.out.println(name + " is eating");
    }
    
    void sleep() {
        System.out.println(name + " is sleeping");
    }
}

// Child class (subclass) - Dog IS-A Animal
class Dog extends Animal {
    // Dog inherits name, eat(), sleep() from Animal
    
    // Dog adds its own specific behavior
    void bark() {
        System.out.println(name + " is barking: Woof!");
    }
    
    // Dog can override inherited behavior
    @Override
    void eat() {
        System.out.println(name + " is eating dog food");
    }
}

// Usage
Dog myDog = new Dog();
myDog.name = "Buddy";
myDog.eat();    // Calls Dog's version: "Buddy is eating dog food"
myDog.sleep();  // Calls inherited Animal version: "Buddy is sleeping"
myDog.bark();   // Dog's own method: "Buddy is barking: Woof!"
```

#### Implements
- Means "this class promises to provide all the methods defined in this interface"

---

## 7. Method Types

### Two Types of Methods:
1. **Abstract methods**: No body
2. **Concrete methods**: Has body

---

## 8. Abstract Classes

### What are Abstract Classes?
- **You cannot create objects of abstract classes**
- Has both abstract and concrete methods

**Example:**
```java
// Abstract class - cannot be instantiated
abstract class Shape {
    String color;
    
    // Regular method - all shapes can have this
    void setColor(String color) {
        this.color = color;
    }
    
    // Abstract method - each shape must implement this differently
    abstract double getArea();
    abstract void draw();
}

// Concrete class - completes the abstract class
class Circle extends Shape {
    double radius;
    
    Circle(double radius) {
        this.radius = radius;
    }
    
    // MUST implement all abstract methods
    @Override
    double getArea() {
        return Math.PI * radius * radius;
    }
    
    @Override
    void draw() {
        System.out.println("Drawing a circle with radius " + radius);
    }
}

// Usage
// Shape shape = new Shape();  // ERROR! Cannot instantiate abstract class
Circle circle = new Circle(5);  // OK! Circle is concrete
circle.setColor("red");         // Inherited from Shape
circle.draw();                  // Circle's implementation
```

### Key Points:
- A simple class can extend another abstract class
- However, in case of interfaces, the regular class implements the interface

---

## 9. Interfaces

### What's the difference between Abstract Class and Interface?

#### Key Differences:
- **Class can only extend ONE abstract class**, however can implement **MULTIPLE interfaces**
- **Any attribute in interface is static**, so its value needs to be instantiated and cannot be left uninitialized

### What are Interfaces?
- **Interfaces are pure contracts** - they only define what methods a class must have, not how they work
- Interface can have:
  - Abstract methods (no body)
  - Default methods
  - Static methods  
  - Public static final variables (constants)
- **They don't have constructors**

**Example:**
```java
// Interface - pure contract
interface Drawable {
    // All methods are automatically public and abstract
    void draw();
    double getArea();
    
    // In newer Java, you can have default methods
    default void printInfo() {
        System.out.println("This is a drawable shape");
    }
}

interface Colorable {
    void setColor(String color);
    String getColor();
}

// A class can implement multiple interfaces
class Rectangle implements Drawable, Colorable {
    double width, height;
    String color;
    
    Rectangle(double width, double height) {
        this.width = width;
        this.height = height;
    }
    
    // Must implement ALL interface methods
    @Override
    public void draw() {
        System.out.println("Drawing rectangle: " + width + "x" + height);
    }
    
    @Override
    public double getArea() {
        return width * height;
    }
    
    @Override
    public void setColor(String color) {
        this.color = color;
    }
    
    @Override
    public String getColor() {
        return color;
    }
}
```

### When to Use Which?

#### ✅ Use Abstract Class when:
- You want to share common code (fields/methods)
- You are building a base class for closely related classes
- You need constructors or non-static variables

#### ✅ Use Interface when:
- You are defining a contract for behavior
- You want multiple classes (even unrelated ones) to have shared abilities
- You need multiple inheritance of behavior

---

## 10. Arrays

### 1D Arrays
```java
int[] numbers;
numbers = new int[6];
numbers[0] = 1;
numbers[1] = 6;
numbers[5] = 6;

// Another way to initialize
int[] numbers2 = new int[5];

// Direct initialization  
int[] numbers3 = {1,2,3,4,5,6,7};

// Traversing array
for(int i = 0; i < numbers3.length; i++) {
    System.out.println(numbers3[i]);
}
```

### 2D Arrays
```java
int[][] matrix = {{1,2,3},{4,5,6},{7,8,9}};

// Traversing through 2D matrix
for(int i = 0; i < matrix.length; i++) {
    for(int j = 0; j < matrix[0].length; j++) {
        System.out.println(matrix[i][j]);
    }
}
```

---

## 11. Inner Classes

### Some Notes About Inner Classes:

#### Non-Static Inner Class:
- **Inner class cannot have static variables** because static means "belong to the class" and the inner class here is a member of outer class
- **How to use inner class**: If we have an outer class that has a normal (non-static) inner class, then to use or access any fields/methods of inner class:
  1. First we need an outer class object or instance
  2. Then we need to create an inner class object specific to that instance
  
**Example:**
```java
// First create outer class object
OuterClass outer = new OuterClass();

// Then create inner class object  
OuterClass.InnerClass inner = outer.new InnerClass();
```

#### Static Inner Class:
- **What if we don't want to use an outer class object** and directly create an inner class object?
- In that case we can declare the inner class as a **static inner class**
- So we don't have to create an instance of outer class every time we need to use inner class

**Example:**
```java
OuterClass.InnerClass inner = new OuterClass.InnerClass();
```

#### Local Inner Class:
- **Local Inner Class** can be declared inside a method in an outer class
- This can only be accessed inside that method and nowhere else
- Just like a regular method, you do your logic and then declare a class just like a regular class
- Now you can access the members, methods of this local class inside the method

---

## 12. Optional in Java

### Why are Optionals used in Java?
- In many real-world cases, we fetch/look for data from database
- Sometimes we're not sure if that data exists in DB, or maybe there's some error and we get null object
- This could lead to **NullPointerException error** because we were looking for a specific object, and if we don't get it, this is an error
- **To fix this issue, there is Optional**

### How to use Optional:
```java
// Declare as Optional
Optional<TypeOfObject> obj = db.find("fred");
// This means we may or may not get the value and we are safe

// When returning, we need to send this as Optional type
return Optional.ofNullable(object);

// When checking or accessing:
// Method 1: Check if present
if(optionalObject.isPresent()) {
    TypeOfObject actualObject = optionalObject.get();
}

// Method 2: Provide default value
TypeOfObject result = optionalObject.orElse("default value");
// This gives us the object if present, else returns default value
```

---

## 13. Enums in Java

### When to use Enums:
- When we have something that has a **fixed set of values** and doesn't change, we use enums
- For instance, daysOfWeek are fixed like Sunday, Monday, ..., Friday, Saturday

### How to create Enums:
- Mostly enums are written in **CAPITAL CASE**
- Create new enum (just like a class)

**Basic Enum:**
```java
public enum DaysOfWeek {
    SUNDAY;
    MONDAY;
    TUESDAY;
    // ... continue for all days
}
```

**Enum with Associated Values:**
- If we want to initialize some value associated with these values
- We declare one variable (e.g., dayNos with dayOfWeek)
- Write that value with enums in () and also need a constructor that initializes all enums with the specific value

```java
public enum DaysOfWeek {
    SUNDAY(0);
    MONDAY(1);
    TUESDAY(2);
    // ...
    SATURDAY(6);
    
    final int dayNos;
    
    DaysOfWeek(int dayNos) {
        this.dayNos = dayNos;
    }
}
```

---

## 14. Java Generics

### Why use Generics?
- Let's say I have a class that has logic to add 2 integer numbers
- Now what if I have 2 double numbers, or 2 float numbers?
- Do I create separate logic for all these data types? **No!**
- Instead we make our class to be **generic**
- Instead of declaring the type of our base class as `int`, we declare it as `T` (which is generic)
- Now we can pass any number types

### Generic Classes:
```java
class Calculator<T> {
    // Logic here using T instead of specific type
}
```

### Bounded Generics:
- Let's say we have a class `Animal` and `Dog` and `Cat` extends this class
- Now if we have a `PetShop` class that has methods like `buyPetFood()`
- We can declare the type as `T extends Animal`
- So any animal type object (Dog or Cat) can use the class and its methods

```java
class PetShop<T extends Animal> {
    public void buyPetFood(T pet) {
        // Logic here
    }
}
```

### Generic Methods:
- We can also have generic methods just like the class
- To declare generic methods we use the following signature:

**Single Generic Type:**
```java
public static <T> void shout(T shoutThing) {
    System.out.println(shoutThing + " !!!");
}
```

**Multiple Generic Types:**
```java
public static <T, V> void shout(T shoutThing, V anotherThing) {
    System.out.println(shoutThing + " " + anotherThing + " !!!");
}
```

---

## 15. Scope and Variable Access

### Scope Test Example:
```java
int numberTest = 10;

public void scopeTest() {
    numberTest += 5;
    System.out.println("numberTest is now: " + numberTest);
}
```

### Inner Class Scope:
```java
public class InnerClass {
    // Let's try to access the variable from outer class
    public static void main(String[] args) {
        System.out.println("Hello from inner class");
    }
}
```

---

## Complete Working Example Code

```java
package basics;

public class JavaFundamentals {
    // Class is a blueprint - contains attributes/properties and actions/methods/functions
    String color;
    int speed;
    
    // Non-static method - needs an object to be called
    void start() {
        System.out.println("Car is starting...");
    }
    
    // Non-static method - needs an object to be called  
    void accelerate() {
        speed += 10;
        System.out.println("Speed is now: " + speed);
    }
    
    // Static method - can be called without creating an object
    static void statMethod() {
        System.out.println("This is a static method which doesn't require to be called with an object");
    }
    
    int numberTest = 10;
    
    public void scopeTest() {
        numberTest += 5;
        System.out.println("numberTest is now: " + numberTest);
    }
    
    // Inner class to understand scope in Java
    public class InnerClass {
        public static void main(String[] args) {
            System.out.println("Hello from inner class");
        }
    }
    
    public static void main(String[] args) {
        JavaFundamentals object = new JavaFundamentals();
        
        // Setting attributes
        object.color = "Red";
        System.out.println(object.color);
        
        // Calling static method
        JavaFundamentals.statMethod();
        
        // Calling non-static method
        object.start();
        
        // Array examples
        int[] numbers = new int[6];
        numbers[0] = 1;
        numbers[1] = 6;
        numbers[5] = 6;
        
        int[] numbers2 = new int[5];
        int[] numbers3 = {1,2,3,4,5,6,7};
        
        for(int i = 0; i < numbers3.length; i++) {
            System.out.println(numbers3[i]);
        }
        
        // 2D arrays
        int[][] matrix = {{1,2,3},{4,5,6},{7,8,9}};
        
        // Traversing through 2D matrix
        for(int i = 0; i < matrix.length; i++) {
            for(int j = 0; j < matrix[0].length; j++) {
                System.out.println(matrix[i][j]);
            }
        }
    }
}
