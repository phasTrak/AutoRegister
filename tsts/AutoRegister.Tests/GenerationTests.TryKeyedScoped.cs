namespace AutoRegister.Tests;

public partial class GenerationTests
{
   #region methods

   [Fact]
   public Task ShouldTryRegisterKeyedScoped() =>
      """
      using AutoRegister;
      namespace Tests;
      [TryRegisterKeyedScoped(serviceKey: "BazKey")]
      public class Foo { }
      """.VerifyAsync();

   [Fact]
   public Task ShouldTryRegisterKeyedScopedFromInterface() =>
      """
      using AutoRegister;
      namespace Tests;
      [TryRegisterKeyedScoped(serviceKey: "BazKey")]
      public class Foo : IFoo { }
      public interface IFoo { }

      """.VerifyAsync();

   #endregion
}