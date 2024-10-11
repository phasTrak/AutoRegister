namespace AutoRegister.Tests;

public partial class GenerationTests
{
   #region methods

   [Fact]
   public Task ShouldRegisterTransient() =>
      """
      using AutoRegister;
      namespace Tests;
      [RegisterTransient]
      public class Foo { }
      """.VerifyAsync();

   [Fact]
   public Task ShouldRegisterTransientFromInterface() =>
      """
      using AutoRegister;
      namespace Tests;
      [RegisterTransient]
      public class Foo : IFoo { }
      public interface IFoo { }

      """.VerifyAsync();

   #endregion
}