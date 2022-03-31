namespace LiveNation.Tests.RulesTests;

using LiveNation.Api.RulesEngine.Rules;
using NUnit.Framework;

public class RuleMultipleOf5Tests
{
    private INumberRule _rule;

    [SetUp]
    public void Setup()
    {
        //Arrange 
        _rule = new RuleMultipleOf5();
    }

    [TestCase(5)]
    [TestCase(10)]
    [TestCase(-5)]
    [TestCase(-10)]
    public void RuleMultipleOf5Matched(int testInput)
    {
        // Act
        var result = _rule.Match(testInput);

        // Assert
        Assert.That(result.IsMatch, Is.True);
        Assert.That(result.RuleOutput, Is.EqualTo("Nation"));
        Assert.That(_rule.NumUses, Is.EqualTo(1));

    }

    [TestCase(0)]
    [TestCase(3)]
    public void RuleMultipleOf5NoMatch(int testInput)
    {
        // Act
        var result = _rule.Match(testInput);

        // Assert
        Assert.That(result.IsMatch, Is.False);
        Assert.That(result.RuleOutput, Is.Null);
        Assert.That(_rule.NumUses, Is.EqualTo(0));
    }
}