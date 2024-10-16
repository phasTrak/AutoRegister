namespace AutoRegister;

public static class AttributeExtensions
{
   #region methods

   public static string? GetAssemblyAttributeValue(this Compilation compilation, string fullyQualifiedMetadataName)
   {
      var attributeSymbol = compilation.GetTypeByMetadataName(fullyQualifiedMetadataName);

      return attributeSymbol is null
                ? null
                : compilation.Assembly.GetAttributes()
                             .Where(attribute => attribute.AttributeClass?.Equals(attributeSymbol, SymbolEqualityComparer.Default) is true)
                             .Select(static attribute => attribute.ConstructorArguments.FirstOrDefault()
                                                                  .Value as string)
                             .FirstOrDefault();
   }

   public static AttributeData? GetFirstAutoRegisterAttribute(this ISymbol symbol, string attributeName) =>
      symbol.GetAttributes()
            .FirstOrDefault(ad => ad.AttributeClass?.Name == attributeName);

   #endregion
}