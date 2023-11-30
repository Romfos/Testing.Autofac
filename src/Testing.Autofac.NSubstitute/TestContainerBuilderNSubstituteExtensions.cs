using Autofac;
using NSubstitute;

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
        Mock<T>(testContainerBuilder, out _);
        return testContainerBuilder;
    }

    public static TestContainerBuilder Mock<T>(this TestContainerBuilder testContainerBuilder, params Action<T>[] configures)
        where T : class
    {
        Mock(testContainerBuilder, out _, configures);
        return testContainerBuilder;
    }

    public static TestContainerBuilder Mock<T>(this TestContainerBuilder testContainerBuilder, out T substitute, params Action<T>[] configures)
        where T : class
    {
        substitute = Substitute.For<T>();
        foreach (var configure in configures)
        {
            configure(substitute);
        }
        testContainerBuilder.ContainerBuilder.RegisterInstance(substitute).SingleInstance();
        return testContainerBuilder;
    }
}
