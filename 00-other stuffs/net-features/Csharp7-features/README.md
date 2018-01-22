### C# 7 Features

In folder Features are some examples of C#7 features. 
Fix the await,Task and async feature.

## TUTORIAL
!important topics and definitions of the language

### Types 
#### Built-in Types
C# provides a standard set of built-in types: int, string, object, bool, double, float

#### Custom Types
You use tuples, struct, class, interface, and enum constructs to create your own custom types.
It is important to understand two fundamental points about the type system:
It supports the principle of inheritance. Types can derive from other types, called base types.
Each type in the Common Type System (CTS) is defined as either a value type or a reference type:
value type: Types that you define by using the struct, & all the built-in numeric types
reference type:Types that you define by using the class keyword
##### Value Types
Value type variables directly contain their values, which means
that the memory is allocated inline in whatever context the variable is declared. There is no separate heap
allocation or garbage collection overhead for value-type variables.
Value types are sealed, which means, for example, that you cannot derive a type from System.Int32, and you cannot
define a struct to inherit from any user-defined class or struct because a struct can only inherit from
System.ValueType. However, a struct can implement one or more interfaces. You can cast a struct type to an
interface type; this causes a boxing operation to wrap the struct inside a reference type object on the managed
heap.
##### Reference Types
A type that is defined as a class, delegate, array, or interface is a reference type.
When the object is created, the memory is allocated on the managed heap, and the variable holds only a reference
to the location of the object. Types on the managed heap require overhead both when they are allocated and when
they are reclaimed by the automatic memory management functionality of the CLR, which is known as garbage
collection. However, garbage collection is also highly optimized, and in most scenarios it does not create a
performance issue.
Reference types fully support inheritance. When you create a class, you can inherit from any other interface or class
that is not defined as sealed, and other classes can inherit from your class and override your virtual methods.
#### Generic Types
A type can be declared with one or more type parameters that serve as a placeholder for the actual type (the
concrete type) that client code will provide when it creates an instance of the type. Such types are called generic
types.
#### Implicit Types, Anonymous Types, and Nullable Types
As stated previously, you can implicitly type a local variable (but not class members) by using the var keyword. The
variable still receives a type at compile time, but the type is provided by the compiler.
In some cases, it is inconvenient to create a named type for simple sets of related values that you do not intend to
store or pass outside method boundaries. You can create anonymous types for this purpose.
Ordinary value types cannot have a value of null. However, you can create nullable value types by affixing a ?
after the type. For example, int? is an int type that can also have the value null

