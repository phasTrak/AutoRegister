namespace AutoRegister.Tests;

public static class TestHelper
{
   #region methods

   public static Task VerifyAsync(this string source)
   {
      var syntaxTree = CSharpSyntaxTree.ParseText(source);

      PortableExecutableReference[] generatorReferences =
      [
         MetadataReference.CreateFromFile(typeof(Generator).Assembly.Location),
         MetadataReference.CreateFromFile(typeof(AutoRegisterAssemblyNameAttribute).Assembly.Location)
      ];

      var references = AppDomain.CurrentDomain.GetAssemblies()
                                .Where(static a => !a.IsDynamic && !string.IsNullOrWhiteSpace(a.Location))
                                .Select(static p => MetadataReference.CreateFromFile(p.Location))
                                .Concat(generatorReferences);

      var compilation = CSharpCompilation.Create("Tests", [syntaxTree], references);

      var generator = new Generator();

      GeneratorDriver driver = CSharpGeneratorDriver.Create(generator);

      driver = driver.RunGenerators(compilation);

      return Verify(driver)
        .UseDirectory("Snapshots");
   }

   #endregion

   #region nested types

   public static class ModuleInitializer
   {
      #region methods

      [ModuleInitializer] public static void Init() => VerifySourceGenerators.Initialize();

      #endregion
   }

   #endregion
}