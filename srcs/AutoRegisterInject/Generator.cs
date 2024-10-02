namespace AutoRegisterInject;

[Generator]
public class Generator : IIncrementalGenerator
{
   #region fields

   const string HOSTED_SERVICE_ATTRIBUTE_NAME  = "RegisterHostedServiceAttribute";
   const string KEYED_SCOPED_ATTRIBUTE_NAME    = "RegisterKeyedScopedAttribute";
   const string KEYED_SINGLETON_ATTRIBUTE_NAME = "RegisterKeyedSingletonAttribute";
   const string KEYED_TRANSIENT_ATTRIBUTE_NAME = "RegisterKeyedTransientAttribute";

   const string NEWLINE = """


                          """;

   const string ONLY_REGISTER_AS                   = "onlyRegisterAs";
   const string SCOPED_ATTRIBUTE_NAME              = "RegisterScopedAttribute";
   const string SERVICE_KEY                        = "serviceKey";
   const string SINGLETON_ATTRIBUTE_NAME           = "RegisterSingletonAttribute";
   const string TRANSIENT_ATTRIBUTE_NAME           = "RegisterTransientAttribute";
   const string TRY_KEYED_SCOPED_ATTRIBUTE_NAME    = "TryRegisterKeyedScopedAttribute";
   const string TRY_KEYED_SINGLETON_ATTRIBUTE_NAME = "TryRegisterKeyedSingletonAttribute";
   const string TRY_KEYED_TRANSIENT_ATTRIBUTE_NAME = "TryRegisterKeyedTransientAttribute";
   const string TRY_SCOPED_ATTRIBUTE_NAME          = "TryRegisterScopedAttribute";
   const string TRY_SINGLETON_ATTRIBUTE_NAME       = "TryRegisterSingletonAttribute";
   const string TRY_TRANSIENT_ATTRIBUTE_NAME       = "TryRegisterTransientAttribute";

   static readonly Dictionary<string, AutoRegistrationType> RegistrationTypes = new ()
                                                                                {
                                                                                   [SCOPED_ATTRIBUTE_NAME] =
                                                                                      AutoRegistrationType.Scoped,
                                                                                   [SINGLETON_ATTRIBUTE_NAME]           = AutoRegistrationType.Singleton,
                                                                                   [TRANSIENT_ATTRIBUTE_NAME]           = AutoRegistrationType.Transient,
                                                                                   [HOSTED_SERVICE_ATTRIBUTE_NAME]      = AutoRegistrationType.Hosted,
                                                                                   [KEYED_SCOPED_ATTRIBUTE_NAME]        = AutoRegistrationType.KeyedScoped,
                                                                                   [KEYED_SINGLETON_ATTRIBUTE_NAME]     = AutoRegistrationType.KeyedSingleton,
                                                                                   [KEYED_TRANSIENT_ATTRIBUTE_NAME]     = AutoRegistrationType.KeyedTransient,
                                                                                   [TRY_SCOPED_ATTRIBUTE_NAME]          = AutoRegistrationType.TryScoped,
                                                                                   [TRY_SINGLETON_ATTRIBUTE_NAME]       = AutoRegistrationType.TrySingleton,
                                                                                   [TRY_TRANSIENT_ATTRIBUTE_NAME]       = AutoRegistrationType.TryTransient,
                                                                                   [TRY_KEYED_SCOPED_ATTRIBUTE_NAME]    = AutoRegistrationType.TryKeyedScoped,
                                                                                   [TRY_KEYED_SINGLETON_ATTRIBUTE_NAME] = AutoRegistrationType.TryKeyedSingleton,
                                                                                   [TRY_KEYED_TRANSIENT_ATTRIBUTE_NAME] = AutoRegistrationType.TryKeyedTransient
                                                                                };

   static readonly string[] IgnoredInterfaces =
   [
      "System.IDisposable",
      "System.IAsyncDisposable"
   ];

   #endregion

   #region methods

   static void Execute(Compilation compilation, ImmutableArray<IEnumerable<AutoRegisteredClass>> classes, SourceProductionContext context)
   {
      var assemblyNameForMethod = compilation.AssemblyName!.Replace(".", Empty)
                                             .Replace(" ", Empty)
                                             .Trim();

      var formatted = Join(NEWLINE,
                           classes.SelectMany(c => c.GroupBy(static x => new
                                                                         {
                                                                            x.ClassName,
                                                                            x.RegistrationType,
                                                                            x.ServiceKey
                                                                         })
                                                    .Select(x => GetRegistration(x.Key.RegistrationType,
                                                                                 x.Key.ClassName,
                                                                                 x.SelectMany(static d => d.Interfaces)
                                                                                  .ToArray(),
                                                                                 x.Key.ServiceKey))));

      var output = SourceConstants.GenerateClassSource
                                  .Replace("{0}", compilation.AssemblyName ?? "AutoRegisterInject")
                                  .Replace("{1}", assemblyNameForMethod)
                                  .Replace("{2}", formatted);

      context.AddSource("AutoRegisterInject.ServiceCollectionExtension.g.cs", SourceText.From(output, Encoding.UTF8));

      return;

      string GetRegistration(AutoRegistrationType type,
                             string className,
                             string[] interfaces,
                             object? serviceKey)
      {
         var hasInterfaces = interfaces.Any();

         return type switch
                {
                   AutoRegistrationType.Scoped when !hasInterfaces => Format(SourceConstants.GenerateScopedSource, className),
                   AutoRegistrationType.Scoped                     => Join(NEWLINE, interfaces.Select(d => Format(SourceConstants.GenerateScopedInterfaceSource, d, className))),

                   AutoRegistrationType.Singleton when !hasInterfaces => Format(SourceConstants.GenerateSingletonSource, className),
                   AutoRegistrationType.Singleton                     => Join(NEWLINE, interfaces.Select(d => Format(SourceConstants.GenerateSingletonInterfaceSource, d, className))),

                   AutoRegistrationType.Transient when !hasInterfaces => Format(SourceConstants.GenerateTransientSource, className),
                   AutoRegistrationType.Transient                     => Join(NEWLINE, interfaces.Select(d => Format(SourceConstants.GenerateTransientInterfaceSource, d, className))),

                   AutoRegistrationType.TryTransient when !hasInterfaces => Format(SourceConstants.GenerateTryTransientSource, className),
                   AutoRegistrationType.TryTransient                     => Join(NEWLINE, interfaces.Select(d => Format(SourceConstants.GenerateTryTransientInterfaceSource, d, className))),

                   AutoRegistrationType.TryScoped when !hasInterfaces => Format(SourceConstants.GenerateTryScopedSource, className),
                   AutoRegistrationType.TryScoped                     => Join(NEWLINE, interfaces.Select(d => Format(SourceConstants.GenerateTryScopedInterfaceSource, d, className))),

                   AutoRegistrationType.TrySingleton when !hasInterfaces => Format(SourceConstants.GenerateTrySingletonSource, className),
                   AutoRegistrationType.TrySingleton                     => Join(NEWLINE, interfaces.Select(d => Format(SourceConstants.GenerateTrySingletonInterfaceSource, d, className))),

                   AutoRegistrationType.KeyedScoped when !hasInterfaces => Format(SourceConstants.GenerateKeyedScopedSource, className, serviceKey),
                   AutoRegistrationType.KeyedScoped => Join(NEWLINE,
                                                            interfaces.Select(d => Format(SourceConstants.GenerateKeyedScopedInterfaceSource,
                                                                                          d,
                                                                                          className,
                                                                                          serviceKey))),

                   AutoRegistrationType.KeyedSingleton when !hasInterfaces => Format(SourceConstants.GenerateKeyedSingletonSource, className, serviceKey),
                   AutoRegistrationType.KeyedSingleton => Join(NEWLINE,
                                                               interfaces.Select(d => Format(SourceConstants.GenerateKeyedSingletonInterfaceSource,
                                                                                             d,
                                                                                             className,
                                                                                             serviceKey))),

                   AutoRegistrationType.KeyedTransient when !hasInterfaces => Format(SourceConstants.GenerateKeyedTransientSource, className, serviceKey),
                   AutoRegistrationType.KeyedTransient => Join(NEWLINE,
                                                               interfaces.Select(d => Format(SourceConstants.GenerateKeyedTransientInterfaceSource,
                                                                                             d,
                                                                                             className,
                                                                                             serviceKey))),

                   AutoRegistrationType.TryKeyedScoped when !hasInterfaces => Format(SourceConstants.GenerateTryKeyedScopedSource, className, serviceKey),
                   AutoRegistrationType.TryKeyedScoped => Join(NEWLINE,
                                                               interfaces.Select(d => Format(SourceConstants.GenerateTryKeyedScopedInterfaceSource,
                                                                                             d,
                                                                                             className,
                                                                                             serviceKey))),

                   AutoRegistrationType.TryKeyedSingleton when !hasInterfaces => Format(SourceConstants.GenerateTryKeyedSingletonSource, className, serviceKey),
                   AutoRegistrationType.TryKeyedSingleton => Join(NEWLINE,
                                                                  interfaces.Select(d => Format(SourceConstants.GenerateTryKeyedSingletonInterfaceSource,
                                                                                                d,
                                                                                                className,
                                                                                                serviceKey))),

                   AutoRegistrationType.TryKeyedTransient when !hasInterfaces => Format(SourceConstants.GenerateTryKeyedTransientSource, className, serviceKey),
                   AutoRegistrationType.TryKeyedTransient => Join(NEWLINE,
                                                                  interfaces.Select(d => Format(SourceConstants.GenerateTryKeyedTransientInterfaceSource,
                                                                                                d,
                                                                                                className,
                                                                                                serviceKey))),

                   AutoRegistrationType.Hosted // Hosted services do not support interfaces at this time
                      => Format(SourceConstants.GenerateHostedServiceSource, className),

                   _ => throw new NotImplementedException("Auto registration type not set up to output")
                };
      }
   }

   static IEnumerable<AutoRegisteredClass> GetAutoRegisteredClassDeclarations(GeneratorSyntaxContext context)
   {
      var classDeclaration = (ClassDeclarationSyntax)context.Node;

      foreach (var attributeSyntax in classDeclaration.AttributeLists.SelectMany(static attributeListSyntax => attributeListSyntax.Attributes))
      {
         if (context.SemanticModel.GetSymbolInfo(attributeSyntax)
                    .Symbol is not IMethodSymbol attributeSymbol)
            continue;

         var fullyQualifiedAttributeName = attributeSymbol.ContainingSymbol.Name;

         if (!RegistrationTypes.TryGetValue(fullyQualifiedAttributeName, out var registrationType)) continue;

         var symbol   = (INamedTypeSymbol?)context.SemanticModel.GetDeclaredSymbol(classDeclaration);
         var typeName = symbol?.ToDisplayString();

         if (symbol is null || typeName is null) continue;

         var attributeData = symbol.GetFirstAutoRegisterAttribute(fullyQualifiedAttributeName);

         string[] registerAs;
         var      serviceKey = Empty;

         if (attributeData.AttributeConstructor?.Parameters.Length > 0 && attributeData.AttributeConstructor?.Parameters.Any(static a => a.Name == SERVICE_KEY) is true)
         {
            serviceKey = attributeData.ConstructorArguments.First()
                                      .Value?.ToString();
         }

         if (attributeData.AttributeConstructor?.Parameters.Length > 0 && attributeData.GetIgnoredTypeNames(ONLY_REGISTER_AS) is { Length: > 0 } onlyRegisterAs)
         {
            registerAs = symbol.AllInterfaces.Select(static x => x.ToDisplayString())
                               .Where(x => onlyRegisterAs.Contains(x))
                               .ToArray();
         }
         else
         {
            registerAs = symbol.Interfaces.Select(static x => x.ToDisplayString())
                               .Where(static x => !IgnoredInterfaces.Contains(x))
                               .ToArray();
         }

         yield return new (typeName,
                           registrationType,
                           registerAs,
                           serviceKey);
      }
   }

   public void Initialize(IncrementalGeneratorInitializationContext context)
   {
      var autoRegistered = context.SyntaxProvider.CreateSyntaxProvider(static (node, _) => node is ClassDeclarationSyntax { AttributeLists.Count: > 0 }, static (ctx, _) => GetAutoRegisteredClassDeclarations(ctx))
                                  .Where(static autoRegisteredClass => autoRegisteredClass is not null);

      var compilationModel = context.CompilationProvider.Combine(autoRegistered.Collect());

      context.RegisterSourceOutput(compilationModel, static (sourceContext, source) => { Execute(source.Left, source.Right, sourceContext); });
   }

   #endregion
}