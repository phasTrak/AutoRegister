// ReSharper disable UnusedParameter.Local

namespace AutoRegisterInject;

[AttributeUsage(Assembly)]
[Conditional("AUTO_REGISTER_INJECT_USAGES")]
public sealed class AutoRegisterInjectAssemblyNameAttribute(string assemblyName) : Attribute
{
   #region properties

   public string AssemblyName { get; } = assemblyName;

   #endregion
}

[AttributeUsage(Class, Inherited = false)]
[Conditional("AUTO_REGISTER_INJECT_USAGES")]
public sealed class RegisterScopedAttribute : Attribute
{
   #region constructors

   public RegisterScopedAttribute() { }
   public RegisterScopedAttribute(params Type[] asTypes) { }

   #endregion

   #region properties

   public Type[]? AsTypes      { get; init; }
   public Type[]? ExcludeTypes { get; init; }

   #endregion
}

[AttributeUsage(Class, Inherited = false)]
[Conditional("AUTO_REGISTER_INJECT_USAGES")]
public sealed class RegisterKeyedScopedAttribute : Attribute
{
   #region constructors

   public RegisterKeyedScopedAttribute(object? serviceKey) { }
   public RegisterKeyedScopedAttribute(object? serviceKey, params Type[] asTypes) { }

   #endregion

   #region properties

   public Type[]? AsTypes      { get; init; }
   public Type[]? ExcludeTypes { get; init; }

   #endregion
}

[AttributeUsage(Class, Inherited = false)]
[Conditional("AUTO_REGISTER_INJECT_USAGES")]
public sealed class TryRegisterScopedAttribute : Attribute
{
   #region constructors

   public TryRegisterScopedAttribute() { }
   public TryRegisterScopedAttribute(params Type[] asTypes) { }

   #endregion

   #region properties

   public Type[]? AsTypes      { get; init; }
   public Type[]? ExcludeTypes { get; init; }

   #endregion
}

[AttributeUsage(Class, Inherited = false)]
[Conditional("AUTO_REGISTER_INJECT_USAGES")]
public sealed class TryRegisterKeyedScopedAttribute : Attribute
{
   #region constructors

   public TryRegisterKeyedScopedAttribute(object? serviceKey) { }
   public TryRegisterKeyedScopedAttribute(object? serviceKey, params Type[] asTypes) { }

   #endregion

   #region properties

   public Type[]? AsTypes      { get; init; }
   public Type[]? ExcludeTypes { get; init; }

   #endregion
}

[AttributeUsage(Class, Inherited = false)]
[Conditional("AUTO_REGISTER_INJECT_USAGES")]
public sealed class RegisterSingletonAttribute : Attribute
{
   #region constructors

   public RegisterSingletonAttribute() { }
   public RegisterSingletonAttribute(params Type[] asTypes) { }

   #endregion

   #region properties

   public Type[]? AsTypes      { get; init; }
   public Type[]? ExcludeTypes { get; init; }

   #endregion
}

[AttributeUsage(Class, Inherited = false)]
[Conditional("AUTO_REGISTER_INJECT_USAGES")]
public sealed class RegisterKeyedSingletonAttribute : Attribute
{
   #region constructors

   public RegisterKeyedSingletonAttribute(object? serviceKey) { }
   public RegisterKeyedSingletonAttribute(object? serviceKey, params Type[] asTypes) { }

   #endregion

   #region properties

   public Type[]? AsTypes      { get; init; }
   public Type[]? ExcludeTypes { get; init; }

   #endregion
}

[AttributeUsage(Class, Inherited = false)]
[Conditional("AUTO_REGISTER_INJECT_USAGES")]
public sealed class TryRegisterSingletonAttribute : Attribute
{
   #region constructors

   public TryRegisterSingletonAttribute() { }
   public TryRegisterSingletonAttribute(params Type[] asTypes) { }

   #endregion

   #region properties

   public Type[]? AsTypes      { get; init; }
   public Type[]? ExcludeTypes { get; init; }

   #endregion
}

[AttributeUsage(Class, Inherited = false)]
[Conditional("AUTO_REGISTER_INJECT_USAGES")]
public sealed class TryRegisterKeyedSingletonAttribute : Attribute
{
   #region constructors

   public TryRegisterKeyedSingletonAttribute(object? serviceKey) { }
   public TryRegisterKeyedSingletonAttribute(object? serviceKey, params Type[] asTypes) { }

   #endregion

   #region properties

   public Type[]? AsTypes      { get; init; }
   public Type[]? ExcludeTypes { get; init; }

   #endregion
}

[AttributeUsage(Class, Inherited = false)]
[Conditional("AUTO_REGISTER_INJECT_USAGES")]
public sealed class RegisterTransientAttribute : Attribute
{
   #region constructors

   public RegisterTransientAttribute() { }
   public RegisterTransientAttribute(params Type[] asTypes) { }

   #endregion

   #region properties

   public Type[]? AsTypes      { get; init; }
   public Type[]? ExcludeTypes { get; init; }

   #endregion
}

[AttributeUsage(Class, Inherited = false)]
[Conditional("AUTO_REGISTER_INJECT_USAGES")]
public sealed class RegisterKeyedTransientAttribute : Attribute
{
   #region constructors

   public RegisterKeyedTransientAttribute(object? serviceKey) { }
   public RegisterKeyedTransientAttribute(object? serviceKey, params Type[] asTypes) { }

   #endregion

   #region properties

   public Type[]? AsTypes      { get; init; }
   public Type[]? ExcludeTypes { get; init; }

   #endregion
}

[AttributeUsage(Class, Inherited = false)]
[Conditional("AUTO_REGISTER_INJECT_USAGES")]
public sealed class TryRegisterTransientAttribute : Attribute
{
   #region constructors

   public TryRegisterTransientAttribute() { }
   public TryRegisterTransientAttribute(params Type[] asTypes) { }

   #endregion

   #region properties

   public Type[]? AsTypes      { get; init; }
   public Type[]? ExcludeTypes { get; init; }

   #endregion
}

[AttributeUsage(Class, Inherited = false)]
[Conditional("AUTO_REGISTER_INJECT_USAGES")]
public sealed class TryRegisterKeyedTransientAttribute : Attribute
{
   #region constructors

   public TryRegisterKeyedTransientAttribute(object? serviceKey) { }
   public TryRegisterKeyedTransientAttribute(object? serviceKey, params Type[] asTypes) { }

   #endregion

   #region properties

   public Type[]? AsTypes      { get; init; }
   public Type[]? ExcludeTypes { get; init; }

   #endregion
}

[AttributeUsage(Class, Inherited = false)] [Conditional("AUTO_REGISTER_INJECT_USAGES")] public sealed class RegisterHostedServiceAttribute : Attribute;