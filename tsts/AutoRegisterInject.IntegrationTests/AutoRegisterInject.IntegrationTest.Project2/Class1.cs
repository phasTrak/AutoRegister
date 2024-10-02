using Microsoft.Extensions.DependencyInjection;
using AutoRegisterInject.IntegrationTest.Project1;

namespace AutoRegisterInject.IntegrationTest.Project2;

public static class Project2
{
   #region methods

   public static void Init()
   {
      var serviceCollection = new ServiceCollection().AutoRegister()
                                                     .AutoRegisterFromAutoRegisterInjectIntegrationTestProject1()
                                                     .AutoRegisterFromAutoRegisterInjectIntegrationTestProject2();

      serviceCollection.BuildServiceProvider();
   }

   #endregion
}

[RegisterScoped] public partial class PartialClassTest;

public partial class PartialClassTest;