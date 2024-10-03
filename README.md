[![Nuget](https://img.shields.io/nuget/v/AutoRegisterInject)](https://www.nuget.org/packages/AutoRegisterInject/)
# <img src="Icon.png" width=32 /> (ActuallyUseful) AutoRegisterInject
AutoRegisterInject is a C# source generator that will automatically create Microsoft.Extensions.DependencyInjection registrations for types marked with attributes.

> [!NOTE]
> This source generator is a fork of [AutoRegisterInject by @patrickklaeren](https://github.com/patrickklaeren/AutoRegisterInject).
> This fork provides support for a variety of usages that are not supported by ARI since it is highly opinionated.
> This fork attempts to be non-opinionated in order to provide an actually useful product in most scenarios.

This is a compile time alternative to reflection/assembly scanning for your injections or manually adding to the `ServiceCollection` every time a new type needs to be registered.

For example:

```cs
namespace MyProject;

[RegisterScoped]
public class Foo { }
```

will automatically generate an extension method called `AutoRegister()` for `IServiceProvider`, that registers `Foo`, as scoped.

```cs
internal IServiceCollection AutoRegister(this IServiceCollection serviceCollection)
{
    serviceCollection.AddScoped<Foo>();
    return serviceCollection;
}
```

In larger projects, dependency injection registration becomes tedious and in team situations can lead to merge conflicts which can be easily avoided.

AutoRegisterInject moves the responsibility of service registration to the owning type rather than external service collection configuration, giving control and oversight of the type that is going to be registered with the container.

## Installation

Install the [Nuget](https://www.nuget.org/packages/AutoRegisterInject) package, and start decorating classes with ARI attributes.

Use `dotnet add package AutoRegisterInject` or add a package reference manually:

```xml
<PackageReference Include="AutoRegisterInject" />
```

## Usage

Classes should be decorated with one of four attributes:
- `[RegisterScoped]`
- `[RegisterSingleton]`
- `[RegisterTransient]`
- `[RegisterHostedService]`

Variants for keyed and the service `Try` register pattern are also available:
- `[TryRegisterScoped]`
- `[TryRegisterSingleton]`
- `[TryRegisterTransient]`
- `[RegisterKeyedScoped]`
- `[RegisterKeyedSingleton]`
- `[RegisterKeyedTransient]`

Each keyed attribute has a `Try` counterpart.

Register a class:

```cs
[RegisterScoped]
class Foo;
```

and get the following output:

```cs
serviceCollection.AddScoped<Foo>();
```

Update the service collection by invoking:

```cs
var serviceCollection = new ServiceCollection();
serviceCollection.AutoRegister();
serviceCollection.BuildServiceProvider();
```

You can now inject `Foo` as a dependency and have this resolved as scoped.

Alternatively, you can register hosted services by:

```cs
[RegisterHostedService]
class Foo;
```

and get:

```cs
serviceCollection.AddHostedService<Foo>();
```

### Register as interface

Implement one or many interfaces on your target class:

```cs
[RegisterTransient]
class Bar : IBar;
```

and get the following output:

```cs
serviceCollection.AddTransient<IBar, Bar>();
```

Implementing multiple interfaces will have the implementing type be registered for each distinct interface.


```cs
[RegisterTransient]
class Bar : IBar, IFoo, IBaz;
```

will output the following:

```cs
serviceCollection.AddTransient<IBar, Bar>();
serviceCollection.AddTransient<IFoo, Bar>();
serviceCollection.AddTransient<IBaz, Bar>();
```

> [!NOTE]
> If the target class implements an interface, it will only be registered with the implemented interfaces (`IBar`).
> If the class should be resolved as `Bar` instead of by the interface, make use of the ExcludeTypes option:
> ```cs
> [RegisterTransient(ExcludeTypes = [typeof(IBar), typeof(IFoo), typeof(IBaz)])]

### Multiple assemblies

In addition to the `AutoRegister` extension method, for every assembly that AutoRegisterInject is a part of, a `AutoRegisterFromAssemblyName` will be generated. This allows you to configure your service collection from one, main, executing assembly.

Given 3 assemblies, `MyProject.Main`, `MyProject.Services`, `MyProject.Data`, you can configure the `ServiceCollection` as such:

```cs
var serviceCollection = new ServiceCollection();
serviceCollection.AutoRegisterFromMyProjectMain();
serviceCollection.AutoRegisterFromMyProjectServices();
serviceCollection.AutoRegisterFromMyProjectData();
serviceCollection.BuildServiceProvider();
```

AutoRegisterInject will remove illegal characters from assembly names in order to generate legal C# method names. `,`, `.` and ` ` will be removed.

If the resulting extension method name conflicts with another assembly, you can supply an assembly-level attribute to override the extension method name for that assembly.
```cs
[assembly: AutoRegisterInjectAssemblyName("MyProjectDataServices")]
```
This will rename the extension with the provided assembly name override:
```cs
serviceCollection.AutoRegisterFromMyProjectDataServices();
```

### Ignoring interfaces

By default ARI will register a type with all the interfaces it implements, however this excludes `System.IDisposable` and its `IAsyncDisposable` counterpart.

You can ignore interfaces by telling ARI to *explicitly* register with only declared interfaces in the given attributes:

```cs
public interface IFoo { }
public interface IBar { }
[RegisterScoped(typeof(IBar))]
public class Foo;
```

this will result in `Foo` ONLY being registered as `IBar` and the following output:

```cs
serviceCollection.AddTransient<IBar, Foo>();
```

`IFoo` will be ignored entirely.

Where you want to register as multiple interfaces, you can pass multiple types.

```cs
[RegisterScoped(typeof(IBar), typeof(IFoo))]
public class Foo;
```

You can also set specific interfaces to exclude from being registered with the ExcludeTypes option:
```cs
[RegisterScoped(ExcludeTypes = [typeof(IFoo)])]
public class Foo;
```

This works for all applicable attributes.

## Fork Changes
 - Support `InternalsVisibleTo`
 - Allow registering as multiple types (e.g. Scoped and KeyedScoped)
 - Customized extension method naming
 - Attributes and extensions are scoped to a namespace

## License

AutoRegisterInject is MIT licensed. Do with it what you please under the terms of MIT.

[View License](LICENSE.md)
