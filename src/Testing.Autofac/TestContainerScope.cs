using Autofac;

namespace Testing.Autofac;

public sealed class TestContainerScope(ILifetimeScope lifetimeScope)
{
    internal ILifetimeScope LifetimeScope { get; } = lifetimeScope;

    public TestContainerScope Resolve<T>(out T value)
        where T : notnull
    {
        value = LifetimeScope.Resolve<T>();
        return this;
    }
}