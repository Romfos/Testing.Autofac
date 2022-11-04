using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Testing.Autofac.NSubstitute;
using Testing.Autofac.Tests.CodeBase;

namespace Testing.Autofac.Tests;

[TestClass]
public sealed class NSubstituteTests
{
    [TestMethod]
    public void BuildTest()
    {
        // arrange
        new TestContainerBuilder()
            .Module<TestModule>()
            .Mock(out IBar bar)
            .Resolve<IFoo>(out var underTest);

        bar.Value().Returns(2);

        // act
        var actual = underTest.Add(1);

        // assert
        Assert.AreEqual(3, actual);
    }

    [TestMethod]
    public void FactoryResolveTest()
    {
        // arrange
        new TestContainerBuilder()
            .Module(new TestModule())
            .Mock(out IBar bar)
            .Build()
            .Resolve(out IFoo underTest);

        bar.Value().Returns(2);

        // act
        var actual = underTest.Add(1);

        // assert
        Assert.AreEqual(3, actual);
    }
}
