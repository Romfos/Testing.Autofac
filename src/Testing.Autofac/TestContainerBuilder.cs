using Autofac;

namespace Testing.Autofac;

public sealed class TestContainerBuilder
{
    internal ContainerBuilder ContainerBuilder { get; } = new ContainerBuilder();

    public TestContainerBuilder Module<T>()
        where T : Module, new()
    {
        ContainerBuilder.RegisterModule<T>();
        return this;
    }

    public TestContainerBuilder Module(Module module)
    {
        ContainerBuilder.RegisterModule(module);
        return this;
    }

    public TestContainerBuilder Register<T>(T target)
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

    public void Resolve<T>(out T target)
        where T : notnull
    {
        target = Resolve<T>();
    }

    public TestContainerScope Build()
    {
        var container = ContainerBuilder.Build();
        var scope = container.BeginLifetimeScope();
        return new TestContainerScope(scope);
    }
}
