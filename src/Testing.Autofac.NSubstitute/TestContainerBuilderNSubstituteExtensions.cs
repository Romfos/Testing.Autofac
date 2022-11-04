using Autofac;
using NSubstitute;
using System;

namespace Testing.Autofac.NSubstitute;

public static class TestContainerBuilderNSubstituteExtensions
{
    public static TestContainerBuilder Mock<T>(this TestContainerBuilder testAutofacService, out T substitute)
        where T : class
    {
        substitute = Substitute.For<T>();
        testAutofacService.ContainerBuilder.RegisterInstance(substitute).SingleInstance();
        return testAutofacService;
    }

    public static TestContainerBuilder Mock<T>(this TestContainerBuilder testAutofacService)
    where T : class
    {
        var substitute = Substitute.For<T>();
        testAutofacService.ContainerBuilder.RegisterInstance(substitute).SingleInstance();
        return testAutofacService;
    }

    public static TestContainerBuilder Mock<T>(this TestContainerBuilder testAutofacService, out T substitute, Action<T> configure)
        where T : class
    {
        substitute = Substitute.For<T>();
        configure(substitute);
        testAutofacService.ContainerBuilder.RegisterInstance(substitute).SingleInstance();
        return testAutofacService;
    }
}
