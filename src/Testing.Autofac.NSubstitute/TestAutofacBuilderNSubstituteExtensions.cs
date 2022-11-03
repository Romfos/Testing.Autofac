using Autofac;
using NSubstitute;
using System;

namespace Testing.Autofac.NSubstitute;

public static class TestAutofacBuilderNSubstituteExtensions
{
    public static TestAutofacBuilder Mock<T>(this TestAutofacBuilder testAutofacService, out T target)
        where T : class
    {
        target = Substitute.For<T>();
        testAutofacService.ContainerBuilder.RegisterInstance(target).SingleInstance();
        return testAutofacService;
    }

    public static TestAutofacBuilder Mock<T>(this TestAutofacBuilder testAutofacService, out T target, Action<T> configure)
        where T : class
    {
        target = Substitute.For<T>();
        configure(target);
        testAutofacService.ContainerBuilder.RegisterInstance(target).SingleInstance();
        return testAutofacService;
    }
}
