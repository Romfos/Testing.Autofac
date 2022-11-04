using Autofac;

namespace Testing.Autofac.Tests.CodeBase;

public class TestModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<Foo>().As<IFoo>().InstancePerLifetimeScope();
    }
}