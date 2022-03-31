namespace LiveNation.Tests.RulesTests;

using LiveNation.Api.RulesEngine.Rules;
using NUnit.Framework;

public class RuleMultipleOf3and5Tests
{
    private INumberRule _rule;

    [SetUp]
    public void Setup()
    {
        //Arrange 
        _rule = new RuleMultipleOf3and5();
    }

    [TestCase(15)]
    [TestCase(30)]
    [TestCase(-15)]
    [TestCase(-30)]
    public void RuleMultipleOf3and5Matched(int testInput)
    {
        // Act
        var result = _rule.Match(testInput);

        // Assert
        Assert.That(result.IsMatch, Is.True);
        Assert.That(result.RuleOutput, Is.EqualTo("LiveNation"));
        Assert.That(_rule.NumUses, Is.EqualTo(1));

    }

    [TestCase(0)]
    [TestCase(3)]
    [TestCase(5)]
    public void RuleMultipleOf3and5NoMatch(int testInput)
    {
        // Act
        var result = _rule.Match(testInput);

        // Assert
        Assert.That(result.IsMatch, Is.False);
        Assert.That(result.RuleOutput, Is.Null);
        Assert.That(_rule.NumUses, Is.EqualTo(0));
    }
}