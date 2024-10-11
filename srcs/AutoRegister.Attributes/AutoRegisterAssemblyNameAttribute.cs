namespace AutoRegister;

[AttributeUsage(Assembly)]
[Conditional("AUTO_REGISTER_USAGES")]
public sealed class AutoRegisterAssemblyNameAttribute(string assemblyName) : Attribute
{
   #region properties

   public string AssemblyName { get; } = assemblyName;

   #endregion
}