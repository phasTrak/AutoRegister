namespace AutoRegister.Tests;

public partial class GenerationTests
{
   #region methods

   [Fact]
   public Task ShouldRegisterPartialClassesForEachRegistrationIfRegisteredMultipleTimes() =>
      """
      using AutoRegister;
      namespace Tests;
      [RegisterScoped]
      public partial class Bar { }
      [RegisterSingleton]
      public partial class Bar { }

      """.VerifyAsync();

   [Fact]
   public Task ShouldRegisterPartialClassesOnce() =>
      """
      using AutoRegister;
      namespace Tests;
      [RegisterScoped]
      public partial class Bar { }
      public partial class Bar { }

      """.VerifyAsync();

   [Fact]
   public Task ShouldRegisterPartialClassesOnceWithInterface() =>
      """
      using AutoRegister;
      namespace Tests;
      [RegisterScoped]
      public partial class Bar { }
      public partial class Bar : IBar { }
      public interface IBar { }

      """.VerifyAsync();

   #endregion
}