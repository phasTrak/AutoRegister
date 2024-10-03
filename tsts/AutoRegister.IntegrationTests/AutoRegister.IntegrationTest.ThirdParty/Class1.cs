using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace AutoRegister.IntegrationTest.ThirdParty;

public static class Project3
{
   #region methods

   public static void Init()
   {
      var serviceCollection = new ServiceCollection().AutoRegister();

      serviceCollection.BuildServiceProvider();
   }

   #endregion
}

[RegisterScoped] public class Baseline;

[RegisterScoped] public class FluentValidator : AbstractValidator<Baseline>;

[RegisterScoped(typeof(IValidator<Baseline>))] public class FluentValidator2 : AbstractValidator<Baseline>;