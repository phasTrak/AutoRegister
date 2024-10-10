namespace AutoRegister.Tests;

public partial class GenerationTests
{
   #region methods

   [Fact]
   public Task ShouldRegisterTrySingleton() =>
      """
      using AutoRegister;
      [TryRegisterSingleton]
      public class Foo { }
      """.VerifyAsync();

   [Fact]
   public Task ShouldRegisterTrySingletonFromInterface() =>
      """
      using AutoRegister;
      [TryRegisterSingleton]
      public class Foo : IFoo { }
      public interface IFoo { }

      """.VerifyAsync();

   #endregion
}