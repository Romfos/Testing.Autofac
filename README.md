# Autofac.Testing

Small testing library for autofac modules

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
```
