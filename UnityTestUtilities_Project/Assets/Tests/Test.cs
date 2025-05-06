using EditorTestUtilities;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;

public class Test
{
    [Test]
    public void TestAssertVectors()
    {
        AssertVectors.WithinTolerance(new Vector3(0,0,0.00000000001f), Vector3.zero);
    }

    public interface ISomeInterface
    {
        Vector3 DoSomething();
    }

    [Test]
    public void TestNSubsitute()
    {
        var fakeImplementation = Substitute.For<ISomeInterface>();
        fakeImplementation.DoSomething().Returns(Vector3.one * 7);
        Vector3 result = fakeImplementation.DoSomething();
        AssertVectors.WithinTolerance( new Vector3(7,7,7), result);
    }
}
