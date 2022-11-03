# Autofac.Testing

Small testing library for autofac modules

# Nuget

https://www.nuget.org/packages/Testing.Autofac.NSubstitute/

# Usage

1. Create TestAutofacService
2. Register autofac modules
3. Register mocks (+ configure them)
4. Build target service

# Usage example

```csharp
[TestMethod]
public void ExampleTest()
{
    // arrange
    var underTest = new TestAutofacBuilder()
        .Module<TestModule>()
        .Mock(out IBar bar)
        .Resolve<IFoo>();

    bar.Value().Returns(2);

    // act
    var actual = underTest.Add(1);

    // assert
    Assert.AreEqual(3, actual);
}
```
