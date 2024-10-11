namespace AutoRegister;

[AttributeUsage(Assembly)]
[Conditional("AUTO_REGISTER_USAGES")]
public sealed class AutoRegisterNamespaceAttribute(string targetNamespace) : Attribute
{
   public string TargetNamespace { get; } = targetNamespace;
}