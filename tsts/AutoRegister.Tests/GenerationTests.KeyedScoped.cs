namespace AutoRegister.Tests;

public partial class GenerationTests
{
   #region methods

   [Fact]
   public Task ShouldRegisterKeyedScoped() =>
      """
      using AutoRegister;
      [RegisterKeyedScoped(serviceKey: "BazKey")]
      public class Foo { }
      """.VerifyAsync();

   [Fact]
   public Task ShouldRegisterKeyedScopedFromInterface() =>
      """
      using AutoRegister;
      [RegisterKeyedScoped(serviceKey: "BazKey")]
      public class Foo : IFoo { }
      public interface IFoo { }

      """.VerifyAsync();

   #endregion
}