# Testing.Autofac

Small testing library for autofac modules

# Nuget

https://www.nuget.org/packages/Testing.Autofac.NSubstitute/

# Usage

1. Create TestContainerBuilder
2. Register autofac modules
3. Register mocks (NSubstitute or Moq)
4. Resolve test services

# Usage example (NSubstitute)

```csharp
[TestMethod]
public void ExampleTest()
{
    // arrange
    new TestContainerBuilder()
        .Module<TestModule>()
        .Mock(out IBar bar)
        .Resolve(out IFoo underTest);

    bar.Value().Returns(2);

    // act
    var actual = underTest.Add(1);

    // assert
    Assert.AreEqual(3, actual);
}
```
