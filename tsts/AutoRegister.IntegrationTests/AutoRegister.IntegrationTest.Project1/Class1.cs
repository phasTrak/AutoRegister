using Microsoft.Extensions.DependencyInjection;

namespace AutoRegister.IntegrationTest.Project1;

public static class Project1
{
   #region methods

   public static void Init()
   {
      var serviceCollection = new ServiceCollection().AutoRegister()
                                                     .AutoRegisterFromAutoRegisterIntegrationTestProject1();

      serviceCollection.BuildServiceProvider();
   }

   #endregion
}

[RegisterScoped] public partial class PartialClassTest;

public partial class PartialClassTest;

[RegisterTransient]
[RegisterSingleton]
[RegisterScoped]
[TryRegisterScoped]
[TryRegisterSingleton]
[TryRegisterTransient]
[TryRegisterKeyedScoped("TryRegisterKeyedScoped")]
[TryRegisterKeyedSingleton("TryRegisterKeyedSingleton")]
[TryRegisterKeyedTransient("TryRegisterKeyedScoped")]
[RegisterKeyedScoped("RegisterKeyedScoped")]
[RegisterKeyedSingleton("RegisterKeyedSingleton")]
[RegisterKeyedTransient("RegisterKeyedTransient")]
public class MultipleRegisterTest;

[RegisterScoped] public class ScopedTest;

[RegisterSingleton] public class SingletonTest;

[RegisterTransient] public class TransientTest;

[TryRegisterScoped] public class TryScopedTest;

[TryRegisterSingleton] public class TrySingletonTest;

[TryRegisterTransient] public class TryTransientTest;

[TryRegisterKeyedScoped("TryRegisterKeyedScoped")] public class TryKeyedScopedTest;

[TryRegisterKeyedSingleton("TryRegisterKeyedSingleton")] public class TryKeyedSingletonTest;

[TryRegisterKeyedTransient("TryRegisterKeyedScoped")] public class TryKeyedTransientTest;

[RegisterKeyedScoped("RegisterKeyedScoped")] public class KeyedScopedTest;

[RegisterKeyedSingleton("RegisterKeyedSingleton")] public class KeyedSingletonTest;

[RegisterKeyedTransient("RegisterKeyedTransient")] public class KeyedTransientTest;

public interface IInterfaceTest;

[RegisterScoped] public class RegisterScopedInterfaceTest : IInterfaceTest;

[TryRegisterScoped] public class TryRegisterScopedInterfaceTest : IInterfaceTest;

[TryRegisterKeyedScoped("TryRegisterKeyedScopedInterface")] public class TryRegisterKeyedScopedInterfaceTest : IInterfaceTest;

[RegisterKeyedScoped("RegisterKeyedScopedInterface")] public class RegisterKeyedScopedInterfaceTest : IInterfaceTest;

public interface IMultiInterfaceTest;

[RegisterScoped]
public class RegisterMultiInterfaceTest : IInterfaceTest,
                                          IMultiInterfaceTest,
                                          IDisposable,
                                          IAsyncDisposable
{
   #region methods

   public void Dispose()
   {
      // TODO release managed resources here
   }

   public ValueTask DisposeAsync() => new ();

   #endregion
}

[TryRegisterScoped]
public class TryRegisterMultiInterfaceTest : IInterfaceTest,
                                             IMultiInterfaceTest,
                                             IDisposable,
                                             IAsyncDisposable
{
   #region methods

   public void Dispose()
   {
      // TODO release managed resources here
   }

   public ValueTask DisposeAsync() => new ();

   #endregion
}

[TryRegisterKeyedScoped("TryRegisterKeyedScopedMultipleInterface")]
public class TryRegisterKeyedMultiInterfaceTest : IInterfaceTest,
                                                  IMultiInterfaceTest,
                                                  IDisposable,
                                                  IAsyncDisposable
{
   #region methods

   public void Dispose()
   {
      // TODO release managed resources here
   }

   public ValueTask DisposeAsync() => new ();

   #endregion
}

[RegisterKeyedScoped("RegisterKeyedScopedMultipleInterface")]
public class RegisterKeyedMultiInterfaceTest : IInterfaceTest,
                                               IMultiInterfaceTest,
                                               IDisposable,
                                               IAsyncDisposable
{
   #region methods

   public void Dispose()
   {
      // TODO release managed resources here
   }

   public ValueTask DisposeAsync() => new ();

   #endregion
}

public interface IIgnore;

// Multiple Interface Single Ignorance
[RegisterScoped(AsTypes = [typeof(IIgnore)])]
public class RegisterScopedMultiInterfaceIgnoranceTest : IInterfaceTest,
                                                         IMultiInterfaceTest,
                                                         IDisposable,
                                                         IAsyncDisposable,
                                                         IIgnore
{
   #region methods

   public void Dispose()
   {
      // TODO release managed resources here
   }

   public ValueTask DisposeAsync() => new ();

   #endregion
}

[TryRegisterScoped(typeof(IIgnore))]
public class TryRegisterScopedMultiInterfaceIgnoranceTest : IInterfaceTest,
                                                            IMultiInterfaceTest,
                                                            IDisposable,
                                                            IAsyncDisposable,
                                                            IIgnore
{
   #region methods

   public void Dispose()
   {
      // TODO release managed resources here
   }

   public ValueTask DisposeAsync() => new ();

   #endregion
}

[TryRegisterKeyedScoped("TryRegisterKeyedScopedMultipleInterfaceSingleIgnore", typeof(IIgnore))]
public class TryRegisterKeyedScopedMultiInterfaceIgnoranceTest : IInterfaceTest,
                                                                 IMultiInterfaceTest,
                                                                 IDisposable,
                                                                 IAsyncDisposable,
                                                                 IIgnore
{
   #region methods

   public void Dispose()
   {
      // TODO release managed resources here
   }

   public ValueTask DisposeAsync() => new ();

   #endregion
}

[RegisterKeyedScoped("RegisterKeyedScopedMultipleInterfaceSingleIgnore", typeof(IIgnore))]
public class RegisterKeyedScopedMultiInterfaceIgnoranceTest : IInterfaceTest,
                                                              IMultiInterfaceTest,
                                                              IDisposable,
                                                              IAsyncDisposable,
                                                              IIgnore
{
   #region methods

   public void Dispose()
   {
      // TODO release managed resources here
   }

   public ValueTask DisposeAsync() => new ();

   #endregion
}

// Multiple Interface Multiple Ignorance
[RegisterScoped(typeof(IIgnore), typeof(IInterfaceTest))]
public class RegisterScopedMultiInterfaceMultiIgnoranceTest : IInterfaceTest,
                                                              IMultiInterfaceTest,
                                                              IDisposable,
                                                              IAsyncDisposable,
                                                              IIgnore
{
   #region methods

   public void Dispose()
   {
      // TODO release managed resources here
   }

   public ValueTask DisposeAsync() => new ();

   #endregion
}

[TryRegisterScoped(typeof(IIgnore), typeof(IInterfaceTest))]
public class TryRegisterScopedMultiInterfaceMultiIgnoranceTest : IInterfaceTest,
                                                                 IMultiInterfaceTest,
                                                                 IDisposable,
                                                                 IAsyncDisposable,
                                                                 IIgnore
{
   #region methods

   public void Dispose()
   {
      // TODO release managed resources here
   }

   public ValueTask DisposeAsync() => new ();

   #endregion
}

[TryRegisterKeyedScoped("TryRegisterKeyedScopedMultipleInterfaceMultipleIgnore", ExcludeTypes = [typeof(IMultiInterfaceTest)])]
public class TryRegisterKeyedScopedMultiInterfaceMultiIgnoranceTest : IInterfaceTest,
                                                                      IMultiInterfaceTest,
                                                                      IDisposable,
                                                                      IAsyncDisposable,
                                                                      IIgnore
{
   #region methods

   public void Dispose()
   {
      // TODO release managed resources here
   }

   public ValueTask DisposeAsync() => new ();

   #endregion
}

[RegisterKeyedScoped("RegisterKeyedScopedMultipleInterfaceMultipleIgnore", ExcludeTypes = [typeof(IMultiInterfaceTest)])]
public class RegisterKeyedScopedMultiInterfaceMultiIgnoranceTest : IInterfaceTest,
                                                                   IMultiInterfaceTest,
                                                                   IDisposable,
                                                                   IAsyncDisposable,
                                                                   IIgnore
{
   #region methods

   public void Dispose()
   {
      // TODO release managed resources here
   }

   public ValueTask DisposeAsync() => new ();

   #endregion
}