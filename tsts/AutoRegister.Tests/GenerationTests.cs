namespace AutoRegister.Tests;

public partial class GenerationTests
{
   #region fields

   [Fact]
   public Task ShouldGenerateEmptyExtensions() => string.Empty.VerifyAsync();

   [Fact]
   public Task ShouldGenerateInAutoRegisterNamespace() =>
      """
         using AutoRegister;
         [RegisterSingleton]
         public class Foo { }
         """.VerifyAsync();

   [Fact]
   public Task ShouldGenerateInGivenNamespace() =>
      """
         using AutoRegister;
         namespace Bob;
         [RegisterSingleton]
         public class Foo { }
         """.VerifyAsync();

   [Fact]
   public Task ShouldGenerateInAttributeNamespace() =>
      """
         using AutoRegister;
         [assembly: AutoRegisterNamespace("Bar")]
         namespace Bob;
         [RegisterSingleton]
         public class Foo { }
         """.VerifyAsync();

   #endregion
}