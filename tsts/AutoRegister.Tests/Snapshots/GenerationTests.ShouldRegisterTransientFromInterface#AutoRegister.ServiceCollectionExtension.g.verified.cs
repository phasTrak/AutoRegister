﻿//HintName: AutoRegister.ServiceCollectionExtension.g.cs
// <auto-generated>
//     Automatically generated by phasTrak.AutoRegister.
//     Changes made to this file may be lost and may cause undesirable behaviour.
// </auto-generated>
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Tests;

#pragma warning disable CS1591 // Disable missing XML comment warning
public static class AutoRegisterServiceCollectionExtensions
{
    public static Microsoft.Extensions.DependencyInjection.IServiceCollection AutoRegisterFromTests(this Microsoft.Extensions.DependencyInjection.IServiceCollection serviceCollection) => AutoRegister(serviceCollection);

    internal static Microsoft.Extensions.DependencyInjection.IServiceCollection AutoRegister(this Microsoft.Extensions.DependencyInjection.IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<global::Tests.IFoo, global::Tests.Foo>();
        
        return serviceCollection;
    }
}
#pragma warning restore CS1591 // Re-enable missing XML comment warning