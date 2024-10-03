namespace AutoRegister;

[AttributeUsage(Class, Inherited = false)]
[Conditional("AUTO_REGISTER_USAGES")]
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