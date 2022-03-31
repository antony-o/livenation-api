namespace LiveNation.Tests.RulesTests;

using LiveNation.Api.RulesEngine.Rules;
using NUnit.Framework;

public class RuleNoMatchTests
{
    private string _output;
    private INumberRule _rule;

    [SetUp]
    public void Setup()
    {
        //Arrange 
        _output = string.Empty;
        _rule = new RuleNoMatch();
    }

    [TestCase(0, "0")]
    [TestCase(1, "1")]
    [TestCase(2, "2")]
    public void RuleNoMatchReturnsMatchForAnyValidInput(int testInput, string expectedResult)
    {
        // Act
        var result = _rule.Match(testInput);

        // Assert
        Assert.That(result.IsMatch, Is.True);
        Assert.That(result.RuleOutput, Is.EqualTo(expectedResult));
        Assert.That(_rule.NumUses, Is.EqualTo(1));
    }
}