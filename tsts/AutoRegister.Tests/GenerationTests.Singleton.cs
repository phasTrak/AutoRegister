namespace AutoRegister.Tests;

public partial class GenerationTests
{
   #region methods

   [Fact]
   public Task ShouldRegisterSingleton() =>
      """
      using AutoRegister;
      namespace Tests;
      [RegisterSingleton]
      public class Foo { }
      """.VerifyAsync();

   [Fact]
   public Task ShouldRegisterSingletonFromInterface() =>
      """
      using AutoRegister;
      namespace Tests;
      [RegisterSingleton]
      public class Foo : IFoo { }
      public interface IFoo { }

      """.VerifyAsync();

   #endregion
}