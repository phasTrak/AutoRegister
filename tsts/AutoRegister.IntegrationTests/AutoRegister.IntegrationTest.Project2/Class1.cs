using Microsoft.Extensions.DependencyInjection;
using AutoRegister.IntegrationTest.Project1;

namespace AutoRegister.IntegrationTest.Project2;

public static class Project2
{
   #region methods

   public static void Init()
   {
      var serviceCollection = new ServiceCollection().AutoRegister()
                                                     .AutoRegisterFromAutoRegisterIntegrationTestProject1()
                                                     .AutoRegisterFromAutoRegisterIntegrationTestProject2();

      serviceCollection.BuildServiceProvider();
   }

   #endregion
}

[RegisterScoped] public partial class PartialClassTest;

public partial class PartialClassTest;