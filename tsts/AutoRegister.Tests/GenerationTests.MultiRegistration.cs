namespace AutoRegister.Tests;

public partial class GenerationTests
{
   #region methods

   [Fact]
   public Task ShouldRegisterAll() =>
      """
      using AutoRegister;
      namespace Tests;
      [RegisterScoped, RegisterSingleton, RegisterTransient]
      public class Foo { }

      """.VerifyAsync();

   [Fact]
   public Task ShouldRegisterAllWithInterface() =>
      """
      using AutoRegister;
      namespace Tests;
      [RegisterScoped, RegisterSingleton, RegisterTransient]
      public class Foo : IFoo { }
      public interface IFoo { }

      """.VerifyAsync();

   #endregion
}