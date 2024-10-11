namespace AutoRegister.Tests;

public partial class GenerationTests
{
   #region methods

   [Fact]
   public Task ShouldRegisterKeyedSingleton() =>
      """
      using AutoRegister;
      namespace Tests;
      [RegisterKeyedSingleton(serviceKey: "BazKey")]
      public class Foo { }
      """.VerifyAsync();

   [Fact]
   public Task ShouldRegisterKeyedSingletonFromInterface() =>
      """
      using AutoRegister;
      namespace Tests;
      [RegisterKeyedSingleton(serviceKey: "BazKey")]
      public class Foo : IFoo { }
      public interface IFoo { }

      """.VerifyAsync();

   #endregion
}