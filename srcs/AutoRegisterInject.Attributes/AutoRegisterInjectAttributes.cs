namespace AutoRegisterInject;

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
[Conditional("AUTO_REGISTER_INJECT_USAGES")]
public sealed class RegisterScopedAttribute : Attribute
{
   #region constructors

   public RegisterScopedAttribute(params Type[] onlyRegisterAs) { }

   #endregion
}

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
[Conditional("AUTO_REGISTER_INJECT_USAGES")]
public sealed class RegisterKeyedScopedAttribute : Attribute
{
   #region constructors

   public RegisterKeyedScopedAttribute(string serviceKey, params Type[] onlyRegisterAs) { }

   #endregion
}

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
[Conditional("AUTO_REGISTER_INJECT_USAGES")]
public sealed class TryRegisterScopedAttribute : Attribute
{
   #region constructors

   public TryRegisterScopedAttribute(params Type[] onlyRegisterAs) { }

   #endregion
}

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
[Conditional("AUTO_REGISTER_INJECT_USAGES")]
public sealed class TryRegisterKeyedScopedAttribute : Attribute
{
   #region constructors

   public TryRegisterKeyedScopedAttribute(string serviceKey, params Type[] onlyRegisterAs) { }

   #endregion
}

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
[Conditional("AUTO_REGISTER_INJECT_USAGES")]
public sealed class RegisterSingletonAttribute : Attribute
{
   #region constructors

   public RegisterSingletonAttribute(params Type[] onlyRegisterAs) { }

   #endregion
}

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
[Conditional("AUTO_REGISTER_INJECT_USAGES")]
public sealed class RegisterKeyedSingletonAttribute : Attribute
{
   #region constructors

   public RegisterKeyedSingletonAttribute(string serviceKey, params Type[] onlyRegisterAs) { }

   #endregion
}

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
[Conditional("AUTO_REGISTER_INJECT_USAGES")]
public sealed class TryRegisterSingletonAttribute : Attribute
{
   #region constructors

   public TryRegisterSingletonAttribute(params Type[] onlyRegisterAs) { }

   #endregion
}

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
[Conditional("AUTO_REGISTER_INJECT_USAGES")]
public sealed class TryRegisterKeyedSingletonAttribute : Attribute
{
   #region constructors

   public TryRegisterKeyedSingletonAttribute(string serviceKey, params Type[] onlyRegisterAs) { }

   #endregion
}

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
[Conditional("AUTO_REGISTER_INJECT_USAGES")]
public sealed class RegisterTransientAttribute : Attribute
{
   #region constructors

   public RegisterTransientAttribute(params Type[] onlyRegisterAs) { }

   #endregion
}

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
[Conditional("AUTO_REGISTER_INJECT_USAGES")]
public sealed class RegisterKeyedTransientAttribute : Attribute
{
   #region constructors

   public RegisterKeyedTransientAttribute(string serviceKey, params Type[] onlyRegisterAs) { }

   #endregion
}

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
[Conditional("AUTO_REGISTER_INJECT_USAGES")]
public sealed class TryRegisterTransientAttribute : Attribute
{
   #region constructors

   public TryRegisterTransientAttribute(params Type[] onlyRegisterAs) { }

   #endregion
}

[AttributeUsage(AttributeTargets.Class, Inherited = false)]
[Conditional("AUTO_REGISTER_INJECT_USAGES")]
public sealed class TryRegisterKeyedTransientAttribute : Attribute
{
   #region constructors

   public TryRegisterKeyedTransientAttribute(string serviceKey, params Type[] onlyRegisterAs) { }

   #endregion
}

[AttributeUsage(AttributeTargets.Class, Inherited = false)] [Conditional("AUTO_REGISTER_INJECT_USAGES")] public sealed class RegisterHostedServiceAttribute : Attribute;