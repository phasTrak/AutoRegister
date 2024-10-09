namespace AutoRegister;

[AttributeUsage(Class, Inherited = false)]
[Conditional("AUTO_REGISTER_USAGES")]
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