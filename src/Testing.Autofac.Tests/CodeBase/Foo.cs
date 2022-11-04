namespace Testing.Autofac.Tests.CodeBase;

public class Foo : IFoo
{
    private readonly IBar bar;

    public Foo(IBar bar)
    {
        this.bar = bar;
    }

    public int Add(int a)
    {
        return a + bar.Value();
    }
}
