namespace AutoRegister;

[AttributeUsage(Class, Inherited = false)]
[Conditional("AUTO_REGISTER_USAGES")]
public sealed class RegisterKeyedSingletonAttribute : Attribute
{
   #region constructors

   public RegisterKeyedSingletonAttribute(object? serviceKey) { }
   public RegisterKeyedSingletonAttribute(object? serviceKey, params Type[] asTypes) { }

   #endregion

   #region properties

   public Type[]? AsTypes      { get; init; }
   public Type[]? ExcludeTypes { get; init; }

   #endregion
}