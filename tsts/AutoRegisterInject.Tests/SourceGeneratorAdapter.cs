namespace AutoRegisterInject.Tests;

// Courtesy of https://github.com/jmarolf/generator-start/blob/main/tests/Adapter.cs

public class SourceGeneratorAdapter<TIncrementalGenerator> : ISourceGenerator,
                                                             IIncrementalGenerator where TIncrementalGenerator : IIncrementalGenerator, new()
{
   #region fields

   readonly TIncrementalGenerator _internalGenerator = new ();

   #endregion

   #region methods

   public void Execute(GeneratorExecutionContext context) => throw new NotImplementedException();
   public void Initialize(GeneratorInitializationContext context) => throw new NotImplementedException();
   public void Initialize(IncrementalGeneratorInitializationContext context) => _internalGenerator.Initialize(context);

   #endregion
}