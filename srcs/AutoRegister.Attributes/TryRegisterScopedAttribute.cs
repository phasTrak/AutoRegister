namespace AutoRegister;

[AttributeUsage(Class, Inherited = false)]
[Conditional("AUTO_REGISTER_USAGES")]
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