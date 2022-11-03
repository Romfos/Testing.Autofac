using Autofac;

namespace Testing.Autofac;

public sealed class TestContainerScope
{
    internal ILifetimeScope LifetimeScope { get; }

    public TestContainerScope(ILifetimeScope lifetimeScope)
    {
        LifetimeScope = lifetimeScope;
    }

    public TestContainerScope Resolve<T>(out T value)
        where T : notnull
    {
        value = LifetimeScope.Resolve<T>();
        return this;
    }
}