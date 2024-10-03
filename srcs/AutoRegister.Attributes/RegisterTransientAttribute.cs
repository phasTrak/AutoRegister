namespace AutoRegister;

[AttributeUsage(Class, Inherited = false)]
[Conditional("AUTO_REGISTER_USAGES")]
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