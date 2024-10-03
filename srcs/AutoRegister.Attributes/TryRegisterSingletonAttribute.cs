namespace AutoRegister;

[AttributeUsage(Class, Inherited = false)]
[Conditional("AUTO_REGISTER_USAGES")]
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