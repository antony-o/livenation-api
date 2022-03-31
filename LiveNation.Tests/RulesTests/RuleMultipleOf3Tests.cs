namespace LiveNation.Tests.RulesTests;

using LiveNation.Api.RulesEngine.Rules;
using NUnit.Framework;

public class RuleMultipleOf3Tests
{
    private INumberRule _rule;

    [SetUp]
    public void Setup()
    {
        //Arrange 
        _rule = new RuleMultipleOf3();
    }

    [TestCase(3)]
    [TestCase(6)]
    [TestCase(-3)]
    [TestCase(-6)]
    public void RuleMultipleOf3Matched(int testInput)
    {
        // Act
        var result = _rule.Match(testInput);

        // Assert
        Assert.That(result.IsMatch, Is.True);
        Assert.That(result.RuleOutput, Is.EqualTo("Live"));
        Assert.That(_rule.NumUses, Is.EqualTo(1));

    }

    [TestCase(0)]
    [TestCase(5)]
    public void RuleMultipleOf3NoMatch(int testInput)
    {
        // Act
        var result = _rule.Match(testInput);

        // Assert
        Assert.That(result.IsMatch, Is.False);
        Assert.That(result.RuleOutput, Is.Null);
        Assert.That(_rule.NumUses, Is.EqualTo(0));
    }
}