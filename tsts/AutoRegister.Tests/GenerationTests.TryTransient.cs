namespace AutoRegister.Tests;

public partial class GenerationTests
{
   #region methods

   [Fact]
   public Task ShouldRegisterTryTransient() =>
      """
      using AutoRegister;
      namespace Tests;
      [TryRegisterTransient]
      public class Foo { }
      """.VerifyAsync();

   [Fact]
   public Task ShouldRegisterTryTransientFromInterface() =>
      """
      using AutoRegister;
      namespace Tests;
      [TryRegisterTransient]
      public class Foo : IFoo { }
      public interface IFoo { }

      """.VerifyAsync();

   #endregion
}