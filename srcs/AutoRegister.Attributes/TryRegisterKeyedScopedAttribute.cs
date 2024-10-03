namespace AutoRegister;

[AttributeUsage(Class, Inherited = false)]
[Conditional("AUTO_REGISTER_USAGES")]
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