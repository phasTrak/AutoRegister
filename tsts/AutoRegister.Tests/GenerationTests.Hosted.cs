namespace AutoRegister.Tests;

public partial class GenerationTests
{
   #region methods

   [Fact]
   public Task ShouldRegisterHosted() =>
      """
      using AutoRegister;
      using Microsoft.Extensions.Hosting;
      using System.Threading;
      using System.Threading.Tasks;
      [RegisterHostedService]
      public class Foo : IHostedService 
      {
          public Task StartAsync(CancellationToken stoppingToken) => throw new System.NotImplementedException();
          public Task StopAsync(CancellationToken stoppingToken) => throw new System.NotImplementedException();
      }
      """.VerifyAsync();

   [Fact]
   public Task ShouldRegisterHostedWithBaseClass() =>
      """
      using AutoRegister;
      using Microsoft.Extensions.Hosting;
      using System.Threading;
      using System.Threading.Tasks;
      [RegisterHostedService]
      public class Foo : BackgroundService
      {
          protected override async Task ExecuteAsync(CancellationToken stoppingToken) => throw new System.NotImplementedException();
      }

      """.VerifyAsync();

   [Fact]
   public Task ShouldRegisterHostedWithInterfaceAndIgnoreIt() =>
      """
      using AutoRegister;
      using Microsoft.Extensions.Hosting;
      using System.Threading;
      using System.Threading.Tasks;
      [RegisterHostedService]
      public class Foo : IHostedService, IFoo
      {
            public Task StartAsync(CancellationToken stoppingToken) => throw new System.NotImplementedException();
            public Task StopAsync(CancellationToken stoppingToken) => throw new System.NotImplementedException();
      }
      public interface IFoo { }

      """.VerifyAsync();

   #endregion
}