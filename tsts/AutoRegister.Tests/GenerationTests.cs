namespace AutoRegister.Tests;

public partial class GenerationTests
{
   #region fields

   [Fact]
   public Task ShouldGenerateEmptyExtensions() => string.Empty.VerifyAsync();

   #endregion
}