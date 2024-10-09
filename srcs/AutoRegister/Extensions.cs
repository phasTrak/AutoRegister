namespace AutoRegister;

public static class Extensions
{
   #region methods

   // argument extensions courtesy of @BlackWhiteYoshi's AutoInterface

   /// <summary>
   ///    <para>Finds the argument with the given name and returns it's value.</para>
   ///    <para>If not found, it returns null.</para>
   /// </summary>
   public static TypedConstant? GetArgument(this ImmutableArray<KeyValuePair<string, TypedConstant>> arguments, string name) =>
      arguments.FirstOrDefault(t => t.Key == name)
               .Value;

   /// <summary>
   ///    <para>Finds the argument with the given name and returns it's value as array.</para>
   ///    <para>If not found or any value is not cast-able, it returns an empty array.</para>
   /// </summary>
   public static T[] GetArgumentArray<T>(this ImmutableArray<KeyValuePair<string, TypedConstant>> arguments, string name)
   {
      if (arguments.GetArgument(name) is not { Kind: TypedConstantKind.Array } typeArray) return [];

      var result = new T[typeArray.Values.Length];

      for (var i = 0; i < result.Length; i++)
      {
         if (typeArray.Values[i].Value is not T value) return [];

         result[i] = value;
      }

      return result;
   }

   public static string? GetAssemblyNameFromAttribute(this Compilation compilation)
   {
      var attributeSymbol = compilation.GetTypeByMetadataName("AutoRegister.AutoRegisterAssemblyNameAttribute");

      return attributeSymbol is null
                ? null
                : compilation.Assembly.GetAttributes()
                             .Where(attribute => attribute.AttributeClass?.Equals(attributeSymbol, SymbolEqualityComparer.Default) is true)
                             .Select(static attribute => attribute.ConstructorArguments.FirstOrDefault()
                                                                  .Value as string)
                             .FirstOrDefault();
   }

   public static AttributeData GetFirstAutoRegisterAttribute(this ISymbol symbol, string attributeName) =>
      symbol.GetAttributes()
            .First(ad => ad.AttributeClass?.Name == attributeName);

   #endregion
}