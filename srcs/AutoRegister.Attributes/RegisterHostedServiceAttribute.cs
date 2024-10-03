namespace AutoRegister;

[AttributeUsage(Class, Inherited = false)] [Conditional("AUTO_REGISTER_USAGES")] public sealed class RegisterHostedServiceAttribute : Attribute;