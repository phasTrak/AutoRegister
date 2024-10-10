namespace AutoRegister.Tests;

public partial class GenerationTests
{
   #region methods

   [Fact]
   public Task ShouldRegisterTryScoped() =>
      """
      using AutoRegister;
      [TryRegisterScoped]
      public class Foo { }
      """.VerifyAsync();

   [Fact]
   public Task ShouldRegisterTryScopedFromInterface() =>
      """
      using AutoRegister;
      [TryRegisterScoped]
      public class Foo : IFoo { }
      public interface IFoo { }

      """.VerifyAsync();

   #endregion
}