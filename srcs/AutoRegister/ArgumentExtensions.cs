namespace AutoRegister;

public static class ArgumentExtensions
{
   #region methods

   /*
      MIT License

      Copyright (c) 2023 BlackWhiteYoshi

      Permission is hereby granted, free of charge, to any person obtaining a copy
      of this software and associated documentation files (the "Software"), to deal
      in the Software without restriction, including without limitation the rights
      to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
      copies of the Software, and to permit persons to whom the Software is
      furnished to do so, subject to the following conditions:

      The above copyright notice and this permission notice shall be included in all
      copies or substantial portions of the Software.

      THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
      IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
      FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
      AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
      LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
      OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
      SOFTWARE.
    */

   // Extension methods from @BlackWhiteYoshi/AutoInterface
   // Original source: https://github.com/BlackWhiteYoshi/AutoInterface/blob/main/AutoInterface/Extensions.cs
   // Licensed under the MIT License

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

   #endregion
}