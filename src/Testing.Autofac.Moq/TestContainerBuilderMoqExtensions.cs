using Autofac;
using Moq;
using System;

namespace Testing.Autofac.Moq;

public static class TestContainerBuilderMoqExtensions
{
    public static TestContainerBuilder Mock<T>(this TestContainerBuilder testContainerBuilder, out Mock<T> mock)
        where T : class
    {
        mock = new Mock<T>();
        testContainerBuilder.ContainerBuilder.RegisterInstance(mock.Object).SingleInstance();
        return testContainerBuilder;
    }

    public static TestContainerBuilder Mock<T>(this TestContainerBuilder testContainerBuilder)
        where T : class
    {
        Mock<T>(testContainerBuilder, out _);
        return testContainerBuilder;
    }

    public static TestContainerBuilder Mock<T>(this TestContainerBuilder testContainerBuilder, params Action<Mock<T>>[] configures)
        where T : class
    {
        var mock = new Mock<T>();
        foreach (var configure in configures)
        {
            configure(mock);
        }
        testContainerBuilder.ContainerBuilder.RegisterInstance(mock.Object).SingleInstance();
        return testContainerBuilder;
    }
}
