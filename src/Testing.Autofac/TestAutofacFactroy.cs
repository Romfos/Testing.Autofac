using Autofac;

namespace Testing.Autofac;

public sealed class TestAutofacFactroy
{
    internal ILifetimeScope LifetimeScope { get; }

    public TestAutofacFactroy(ILifetimeScope lifetimeScope)
    {
        LifetimeScope = lifetimeScope;
    }

    public TestAutofacFactroy Resolve<T>(out T value)
        where T : notnull
    {
        value = LifetimeScope.Resolve<T>();
        return this;
    }
}