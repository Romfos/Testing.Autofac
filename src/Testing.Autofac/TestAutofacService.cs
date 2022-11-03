using Autofac;

namespace Testing.Autofac;

public sealed class TestAutofacService
{
    internal ContainerBuilder ContainerBuilder { get; } = new ContainerBuilder();

    public TestAutofacService Module<T>()
        where T : Module, new()
    {
        ContainerBuilder.RegisterModule<T>();
        return this;
    }

    public T Build<T>()
        where T : notnull
    {
        var container = ContainerBuilder.Build();
        var scope = container.BeginLifetimeScope();
        return scope.Resolve<T>();
    }
}
