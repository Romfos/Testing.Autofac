namespace Testing.Autofac.Tests.CodeBase;

public class Foo(IBar bar) : IFoo
{
    public int Add(int a)
    {
        return a + bar.Value();
    }
}
