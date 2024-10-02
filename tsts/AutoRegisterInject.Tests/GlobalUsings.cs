// Global using directives

global using Microsoft.CodeAnalysis;
global using Microsoft.CodeAnalysis.Testing;
global using System.Collections.Immutable;
global using Xunit;
global using GeneratorTest = Microsoft.CodeAnalysis.CSharp.Testing.CSharpSourceGeneratorTest<AutoRegisterInject.Tests.SourceGeneratorAdapter<AutoRegisterInject.Generator>, Microsoft.CodeAnalysis.Testing.Verifiers.XUnitVerifier>;