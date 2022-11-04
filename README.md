# Testing.Autofac

Small testing library for autofac modules

# Nuget

NSubstitute:
https://www.nuget.org/packages/Testing.Autofac.NSubstitute/

Moq:
https://www.nuget.org/packages/Testing.Autofac.Moq/

# Usage

1. Create TestContainerBuilder
2. Register autofac modules
3. Register mocks (NSubstitute or Moq)
4. Build test services

# Usage example

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
