namespace AutoRegister.Tests;

public partial class GenerationTests
{
   #region methods

   [Fact]
   public Task TestCase1() =>
      """
      using AutoRegister;
      using Microsoft.Extensions.Hosting;
      using System.Threading;
      using System.Threading.Tasks;
      namespace Tests;
      [RegisterHostedService]
      public class Foo : IHostedService 
      {
          public Task StartAsync(CancellationToken stoppingToken) => throw new System.NotImplementedException();
          public Task StopAsync(CancellationToken stoppingToken) => throw new System.NotImplementedException();
      }

      [RegisterScoped]
      public class Bar { }

      [RegisterTransient]
      public class Baz { }

      [RegisterSingleton]
      public class Bang : IBaz { }

      [TryRegisterScoped]
      public class Far { }

      [RegisterKeyedTransient("MyFazKey")]
      public class Faz { }

      [TryRegisterKeyedSingleton("MyFangKey")]
      public class Fang : IBaz { }

      public interface IBaz { }

     """.VerifyAsync();

   #endregion
}