namespace AutoRegister;

[AttributeUsage(Class, Inherited = false)]
[Conditional("AUTO_REGISTER_USAGES")]
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