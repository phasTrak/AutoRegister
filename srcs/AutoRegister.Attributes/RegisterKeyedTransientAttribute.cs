namespace AutoRegister;

[AttributeUsage(Class, Inherited = false)]
[Conditional("AUTO_REGISTER_USAGES")]
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