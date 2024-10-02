namespace AutoRegisterInject;

public static class Extensions
{
   #region methods

   public static AttributeData GetFirstAutoRegisterAttribute(this ISymbol symbol, string attributeName) =>
      symbol.GetAttributes()
            .First(ad => ad.AttributeClass?.Name == attributeName);

   public static string[] GetIgnoredTypeNames(this AttributeData attributeData, string parameterName)
   {
      if (attributeData.AttributeConstructor is null) return [];

      var parameterIndex = attributeData.AttributeConstructor.Parameters.ToList()
                                        .FindIndex(c => c.Name == parameterName);

      if (parameterIndex < 0) return [];

      var values = attributeData.ConstructorArguments[parameterIndex]
                                .Values.Select(static x => x.Value?.ToString() ?? Empty)
                                .ToArray();

      return values;
   }

   #endregion
}