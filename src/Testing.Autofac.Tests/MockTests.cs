using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Testing.Autofac.Moq;
using Testing.Autofac.Tests.CodeBase;

namespace Testing.Autofac.Tests;

[TestClass]
public sealed class MockTests
{
    [TestMethod]
    public void BuildTest()
    {
        // arrange
        new TestContainerBuilder()
            .Module<TestModule>()
            .Mock(out Mock<IBar> bar)
            .Resolve<IFoo>(out var underTest);

        bar.Setup(x => x.Value()).Returns(2);

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
            .Mock<IBar>(x => x.Setup(x => x.Value()).Returns(2))
            .Resolve(out IFoo underTest);

        // act
        var actual = underTest.Add(1);

        // assert
        Assert.AreEqual(3, actual);
    }
}
