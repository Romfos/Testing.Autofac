using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Testing.Autofac.NSubstitute;

namespace Testing.Autofac.Tests;

[TestClass]
public sealed class NSubstituteTests
{
    public interface IFoo
    {
        int Add(int a);
    }

    public interface IBar
    {
        int Value();
    }

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

    public class TestModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Foo>().As<IFoo>().InstancePerLifetimeScope();
        }
    }


    [TestMethod]
    public void NSubstituteTest()
    {
        // arrange
        var underTest = new TestAutofacService()
            .Module<TestModule>()
            .Mock<IBar>(out var bar)
            .Build<IFoo>();

        bar.Value().Returns(2);

        // act
        var actual = underTest.Add(1);

        // assert
        Assert.AreEqual(3, actual);
    }
}