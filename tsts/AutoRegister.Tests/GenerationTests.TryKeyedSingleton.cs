namespace AutoRegister.Tests;

public partial class GenerationTests
{
   #region methods

   [Fact]
   public Task ShouldTryRegisterKeyedSingleton() =>
      """
      using AutoRegister;
      namespace Tests;
      [TryRegisterKeyedSingleton(serviceKey: "BazKey")]
      public class Foo { }
      """.VerifyAsync();

   [Fact]
   public Task ShouldTryRegisterKeyedSingletonFromInterface() =>
      """
      using AutoRegister;
      namespace Tests;
      [TryRegisterKeyedSingleton(serviceKey: "BazKey")]
      public class Foo : IFoo { }
      public interface IFoo { }

      """.VerifyAsync();

   #endregion
}