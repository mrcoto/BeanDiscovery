# BeanDiscovery

Resolve dependency injection **at compile time** marking your classes with **bean attributes**.

Avoid doing this:

```csharp
services.AddTransient<IMagicService, MagicService>();
// More lines here...
```

If you can do this instead:

```csharp
services.UseBeanDiscovery(); // Only once
```

And, in your interface and class:

```csharp
public interface IMagicService
{
    string Magic();
}

// Default ScopeType is SCOPED
[Service(scope: ScopeType.SINGLETON)]
public class MagicService : IMagicService
{
    public string Magic() => "El Principito";
}
```

## Index

* [Support](#support)
* [Installation](#installation)
* [Bean Definition](#bean-definition)
    - [Class With Interface](#class-with-interface)
    - [Class Without Interface](#class-without-interface)
    - [Interface Implemented in two or more classes](#interface-implemented-in-two-or-more-classes)
    - [Generic Class With Interface](#generic-class-with-interface)
    - [Class with Parent Class And Interface](#class-with-parent-class-and-interface)
    - [Class with Interface Hierarchy](#class-with-interface-hierarchy)
* [Bean Discovery](#bean-discovery)
    - [Simple Usage](#simple-usage)
    - [Advanced Usage](#advanced-usage)
* [Projects](#projects)
* [License](#license)

## Support

Support for .NET Core 2.0 >=

## Installation

```bash
dotnet add package BeanDiscovery --version 1.0.2
```

## Bean Definition

A bean is defined using one of the next attributes:
- ```Bean```
- ```Command```
- ```Query```
- ```Repository```
- ```Service```

### Class With Interface

```csharp
using MrCoto.BeanDiscovery;
using MrCoto.BeanDiscovery.Attributes;

namespace MyNamespace
{
    [Repository(scope: ScopeType.TRANSIENT)]
    public class MyRepository : IRepository
    {
        // Some code...
    }
}
```

### Class Without Interface

```csharp
using MrCoto.BeanDiscovery.Attributes;

namespace MyNamespace
{
    [Service]
    public class NoInterfaceService
    {
        // Some code...
    }
}
```

### Interface Implemented in two or more classes

```csharp
using MrCoto.BeanDiscovery;
using MrCoto.BeanDiscovery.Attributes;

namespace MyNamespace
{
    // This bean is named or identified as "Spanish"
    [Query("Spanish", ScopeType.SINGLETON)]
    public class SpanishQuery : ILangQuery
    {
        // Some code...
    }

    // This bean is named or identified as "English"
    [Query("English", ScopeType.SCOPED)]
    public class EnglishQuery : ILangQuery
    {
        // Some code...
    }
}
```

### Generic Class With Interface

```csharp
using MrCoto.BeanDiscovery;
using MrCoto.BeanDiscovery.Attributes;

namespace MyNamespace
{
    // Default ScopeType is SCOPED
    [Repository]
    public class MyRepository<T> : IRepository<T> where T : class
    {
        // Some code...
    }
}
```

### Class with Parent Class And Interface

```csharp
using MrCoto.BeanDiscovery;
using MrCoto.BeanDiscovery.Attributes;

namespace MyNamespace
{
    [Repository]
    public class MyRepository<T> : IRepository<T> where T : class
    {
        // Some code...
    }

    public interface ITodoRepository : IRepository<TodoEntity>
    {
        // Some code...
    }

    [Repository]
    public class TodoRepository : MyRepository<TodoEntity>, ITodoRepository
    {
        // Some code...
    }
}
```

### Class with Interface Hierarchy

```csharp
using MrCoto.BeanDiscovery;
using MrCoto.BeanDiscovery.Attributes;

namespace MyNamespace
{

    public interface ITodoRepository : IRepository<TodoEntity>
    {
        // Some code...
    }

    public interface ICustomTodoRepository : ITodoRepository
    {
        // Some code...
    }

    [Repository]
    public class CustomTodoRepository : ICustomTodoRepository
    {
        // Some code...
    }
}
```

## Bean Discovery

### Simple Usage

The simplest usage to bean discovery is:

```csharp
using using MrCoto.BeanDiscovery;
...

services.UseBeanDiscovery(); // Only once
```

### Advanced Usage

You can pass some options throught ```UseBeanDiscovery()``` method

```csharp
using using MrCoto.BeanDiscovery;
...

services.UseBeanDiscovery(options =>
{
    // ILangQuery should use class marked with bean's name "Spanish"
    // Exception thrown if bean not found.
    options.UseBeanNameWithError<ILangQuery>("Spanish");
    // If no bean with name "PostgreSQL" found,
    // then first bean in ICatRepository is used
    options.UseBeanName<ICatRepository>("PostgreSQL");
    // Default is "Primary"
    // All interfaces not present in .UseBeanName...
    // should use bean's with "Secondary" name
    // If no bean's with "Secondary" name found
    // Then first bean in that Interface will be used
    options.UseGlobalBeanName("Secondary");
    // SomeService and SomeService2 will be ignored in service registration.
    options.IgnoreBean<SomeService>();
    options.IgnoreBean<SomeService2>();
});
```

## Projects

- **BeanDiscovery**: Library project, contains core functionalities.
- **BeanDiscoveryTest**: Tests of BeanDiscovery Project.
- **BeanDiscoveryExample**: Example of Web api using BeanDiscovery.
- **BeanDiscoveryExampleExtra**: Project referenced in ```BeanDiscoveryExample```
that uses Bean Attributes (only to show that bean attributes in other projects are discovered too).

## License

MIT License.