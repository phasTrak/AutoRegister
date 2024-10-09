namespace AutoRegister;

[AttributeUsage(Class, Inherited = false)]
[Conditional("AUTO_REGISTER_USAGES")]
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