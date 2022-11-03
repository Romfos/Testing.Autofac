using Autofac;

namespace Testing.Autofac;

public sealed class TestAutofacBuilder
{
    internal ContainerBuilder ContainerBuilder { get; } = new ContainerBuilder();

    public TestAutofacBuilder Module<T>()
        where T : Module, new()
    {
        ContainerBuilder.RegisterModule<T>();
        return this;
    }

    public TestAutofacBuilder Register<T>(T target)
        where T : class
    {
        ContainerBuilder.RegisterInstance(target).SingleInstance();
        return this;
    }

    public T Resolve<T>()
        where T : notnull
    {
        var container = ContainerBuilder.Build();
        var scope = container.BeginLifetimeScope();
        return scope.Resolve<T>();
    }

    public void Resolve<T>(out T value)
        where T : notnull
    {
        value = Resolve<T>();
    }

    public TestAutofacFactroy Build()
    {
        var container = ContainerBuilder.Build();
        var scope = container.BeginLifetimeScope();
        return new TestAutofacFactroy(scope);
    }
}
