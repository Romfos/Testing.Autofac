using Autofac;
using NSubstitute;
using System;

namespace Testing.Autofac.NSubstitute;

public static class TestContainerBuilderNSubstituteExtensions
{
    public static TestContainerBuilder Mock<T>(this TestContainerBuilder testContainerBuilder, out T substitute)
        where T : class
    {
        substitute = Substitute.For<T>();
        testContainerBuilder.ContainerBuilder.RegisterInstance(substitute).SingleInstance();
        return testContainerBuilder;
    }

    public static TestContainerBuilder Mock<T>(this TestContainerBuilder testContainerBuilder)
    where T : class
    {
        var substitute = Substitute.For<T>();
        testContainerBuilder.ContainerBuilder.RegisterInstance(substitute).SingleInstance();
        return testContainerBuilder;
    }

    public static TestContainerBuilder Mock<T>(this TestContainerBuilder testContainerBuilder, out T substitute, Action<T> configure)
        where T : class
    {
        substitute = Substitute.For<T>();
        configure(substitute);
        testContainerBuilder.ContainerBuilder.RegisterInstance(substitute).SingleInstance();
        return testContainerBuilder;
    }
}
