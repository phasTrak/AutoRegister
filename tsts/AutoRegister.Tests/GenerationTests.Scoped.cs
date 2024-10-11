namespace AutoRegister.Tests;

public partial class GenerationTests
{
   #region methods

   [Fact]
   public Task ShouldRegisterScoped() =>
      """
      using AutoRegister;
      namespace Tests;
      [RegisterScoped]
      public class Foo { }
      """.VerifyAsync();

   [Fact]
   public Task ShouldRegisterScopedFromInterface() =>
      """
      using AutoRegister;
      namespace Tests;
      [RegisterScoped]
      public class Foo : IFoo { }
      public interface IFoo { }

      """.VerifyAsync();

   #endregion
}