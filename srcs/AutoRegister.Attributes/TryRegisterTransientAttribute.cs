namespace AutoRegister;

[AttributeUsage(Class, Inherited = false)]
[Conditional("AUTO_REGISTER_USAGES")]
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