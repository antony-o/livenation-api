namespace LiveNation.Tests;

using LiveNation.Api.RulesEngine;
using LiveNation.Core;
using NUnit.Framework;
using System;

public class RulesEngineTests
{
    private IRulesEngine _rulesEngine;

    [SetUp]
    public void Setup()
    {
        _rulesEngine = new RulesEngine();
    }

    [TestCase(1,5, "1 2 Live 4 Nation")]
    [TestCase(3,3, "Live")]
    public void ReturnsCorrectOutputForValidRange(int testStart, int testEnd, string expectedResult)
    {
        //Arrange 
        var range = new NumberRange { Start = testStart, End = testEnd };

        // Act
        var result = _rulesEngine.ProcessRange(range);

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [Test]
    public void ReturnsExceptionForInvalidRanges()
    {
        //Arrange 
        var range = new NumberRange { Start = 5, End = 1 };

        // Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => _rulesEngine.ProcessRange(range));
    }
}