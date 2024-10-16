namespace AutoRegister;

[Generator(CSharp)]
public class Generator : IIncrementalGenerator
{
   #region fields

   const string HOSTED_SERVICE_ATTRIBUTE_NAME  = "RegisterHostedServiceAttribute";
   const string KEYED_SCOPED_ATTRIBUTE_NAME    = "RegisterKeyedScopedAttribute";
   const string KEYED_SINGLETON_ATTRIBUTE_NAME = "RegisterKeyedSingletonAttribute";
   const string KEYED_TRANSIENT_ATTRIBUTE_NAME = "RegisterKeyedTransientAttribute";

   const string NEWLINE = """


                          """;

   const string SCOPED_ATTRIBUTE_NAME              = "RegisterScopedAttribute";
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
      var assemblyNameForMethod = compilation.GetAssemblyAttributeValue("AutoRegister.AutoRegisterAssemblyNameAttribute")
                               ?? compilation.AssemblyName?.Replace(".", Empty)
                                             .Replace(" ", Empty)
                                             .Trim()
                               ?? Empty;

      var formatted = Join(NEWLINE,
                           classes.SelectMany(c => c.GroupBy(static x => new
                                                                         {
                                                                            x.ClassName,
                                                                            x.RegistrationType,
                                                                            x.ServiceKey
                                                                         })
                                                    .Select(x => GetRegistration(x.Key.RegistrationType,
                                                                                 x.Key.ClassName,
                                                                                 [..x.SelectMany(static d => d.Interfaces)],
                                                                                 x.Key.ServiceKey))));

      var classNamespace = compilation.GetAssemblyAttributeValue("AutoRegister.AutoRegisterNamespaceAttribute") ?? GetNamespaceFromClasses(classes) ?? "AutoRegister";

      var output = IsNullOrWhiteSpace(formatted)
                      ? Empty // when there are no registrations should output an empty file
                      : SourceConstants.GenerateClassSource.Replace("{0}", classNamespace)
                                       .Replace("{1}", assemblyNameForMethod)
                                       .Replace("{2}", formatted);

      context.AddSource("AutoRegister.ServiceCollectionExtension.g.cs", SourceText.From(output, Encoding.UTF8));

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

   static IEnumerable<AutoRegisteredClass> GetAutoRegisteredClassDeclarations(GeneratorSyntaxContext context, CancellationToken cancellationToken)
   {
      var classDeclaration = (ClassDeclarationSyntax)context.Node;
      var classSymbol      = (INamedTypeSymbol?)context.SemanticModel.GetDeclaredSymbol(classDeclaration);
      var typeName         = classSymbol?.ToDisplayString(FullyQualifiedFormat);

      if (classSymbol is null || typeName is null) yield break;

      var attributes = classDeclaration.AttributeLists.SelectMany(static attributeListSyntax => attributeListSyntax.Attributes);

      foreach (var attributeSyntax in attributes)
      {
         if (context.SemanticModel.GetSymbolInfo(attributeSyntax)
                    .Symbol is not IMethodSymbol attributeSymbol)
            continue;

         var attributeName = attributeSymbol.ContainingSymbol.Name;

         if (!RegistrationTypes.TryGetValue(attributeName, out var registrationType)) continue;

         var attributeData   = classSymbol.GetFirstAutoRegisterAttribute(attributeName);
         var namespaceSymbol = classSymbol.ContainingNamespace;

         var serviceKey = GetServiceKey(attributeData);
         var registerAs = GetRegisterAs(attributeData, classSymbol);

         var classNamespace = namespaceSymbol.IsGlobalNamespace
                                 ? Empty
                                 : namespaceSymbol.ToDisplayString();

         yield return new (typeName,
                           classNamespace,
                           registrationType,
                           registerAs,
                           serviceKey);
      }
   }

   static string? GetNamespaceFromClasses(ImmutableArray<IEnumerable<AutoRegisteredClass>> classes) =>
      classes.SelectMany(static c => c)
             .Select(static c => c.ClassNamespace)
             .Where(static n => !IsNullOrWhiteSpace(n))
             .OrderBy(static n => n.Length)
             .FirstOrDefault();

   static string[] GetRegisterAs(AttributeData? attributeData, ITypeSymbol classSymbol)
   {
      string[] asTypes = attributeData switch
                         {
                            null => [],
                            _ =>
                            [
                               ..attributeData.NamedArguments.GetArgumentArray<INamedTypeSymbol>("AsTypes")
                                              .Select(static s => s.ToDisplayString(FullyQualifiedFormat))
                            ]
                         };

      string[] asTypesConstructor = attributeData switch
                                    {
                                       null => [],
                                       _ =>
                                       [
                                          ..attributeData.ConstructorArguments.Where(static arg => arg.Kind is TypedConstantKind.Array)
                                                         .SelectMany(static arg => arg.Values)
                                                         .Select(static tc => tc.Value as INamedTypeSymbol)
                                                         .Where(static type => type is not null)
                                                         .Select(static type => type?.ToDisplayString(FullyQualifiedFormat) ?? Empty)
                                       ]
                                    };

      string[] combined = [..asTypes, ..asTypesConstructor];

      if (combined.Any()) return combined;

      IEnumerable<string> excludeTypes = attributeData switch
                                         {
                                            null => [],
                                            _ =>
                                            [
                                               ..attributeData.NamedArguments.GetArgumentArray<INamedTypeSymbol>("ExcludeTypes")
                                                              .Select(static s => s.ToDisplayString(FullyQualifiedFormat))
                                            ]
                                         };

      return
      [
         ..classSymbol.Interfaces.Select(static x => x.ToDisplayString(FullyQualifiedFormat))
                      .Where(x => !IgnoredInterfaces.Contains(x) && !excludeTypes.Contains(x))
      ];
   }

   static object? GetServiceKey(AttributeData? attributeData)
   {
      if (attributeData is null || attributeData.AttributeClass?.Name.Contains("RegisterKeyed") is false) return null;

      var serviceKeyPosition = attributeData.AttributeConstructor?.Parameters.FirstOrDefault(static p => p.Name is "serviceKey")
                                           ?.Ordinal
                            ?? throw new ArgumentException("A service key was not provided for a keyed registration");

      return attributeData.ConstructorArguments[serviceKeyPosition].Value;
   }

   public void Initialize(IncrementalGeneratorInitializationContext context)
   {
      var autoRegistered = context.SyntaxProvider.CreateSyntaxProvider(static (node, _) => node is ClassDeclarationSyntax { AttributeLists.Count: > 0 }, GetAutoRegisteredClassDeclarations)
                                  .Where(static autoRegisteredClass => autoRegisteredClass is not null);

      var compilationModel = context.CompilationProvider.Combine(autoRegistered.Collect());

      context.RegisterSourceOutput(compilationModel, static (sourceContext, source) => { Execute(source.Left, source.Right, sourceContext); });
   }

   #endregion
}