namespace LiveNation.Tests;

using LiveNation.Api.RulesEngine;
using LiveNation.Api.RulesEngine.Rules;
using LiveNation.Api.Services;
using LiveNation.Core;
using Moq;
using NUnit.Framework;

public class NumberServiceTests
{
    private INumberService _numberService;
    private ICacheService _mockCacheService;
    private IRulesEngine _mockRulesEngine;

    [SetUp]
    public void Setup()
    {
        _mockCacheService = Mock.Of<ICacheService>();
        Mock.Get(_mockCacheService).Setup(cs => cs.Get<ProcessRangeResponse>(("range:7-8"))).Returns(new ProcessRangeResponse { Result = "7 8" });

        _mockRulesEngine = Mock.Of<IRulesEngine>();
        var mockRules = new INumberRule[]
        {
            CreateMockRule("Rule1"),
            CreateMockRule("Rule2")
        };

        Mock.Get(_mockRulesEngine).Setup(re => re.ProcessRange(It.IsAny<NumberRange>())).Returns("1 2 3 4");
        Mock.Get(_mockRulesEngine).Setup(re => re.Rules).Returns(mockRules);
        _numberService = new NumberService(_mockRulesEngine, _mockCacheService);
    }

    [Test]
    public void ValidResponseIsReturnedAndCached()
    {
        //Arrange 
        var range = new NumberRange { Start = 1, End = 20 };

        // Act
        var response = _numberService.ProcessRange(range);

        // Assert
        Assert.That(response.Result, Is.EqualTo("1 2 3 4"));
        Assert.That(response.Summary.Count, Is.EqualTo(2));
        Assert.That(string.Concat(response.Summary.Keys), Is.EqualTo("Rule1Rule2"));
        Assert.That(string.Concat(response.Summary.Values), Is.EqualTo("22"));
        Mock.Get(_mockCacheService).Verify(cs => cs.Set(It.IsAny<string>(), It.IsAny<object>()), Times.Once);
    }

    [Test]
    public void CachedResponseIsReturnedIfAvailable()
    {
        //Arrange 
        var range = new NumberRange { Start = 7, End = 8 };

        // Act
        var response = _numberService.ProcessRange(range);

        // Assert
        Assert.That(response.Result, Is.EqualTo("7 8"));
        Mock.Get(_mockRulesEngine).Verify(re => re.ProcessRange(It.IsAny<NumberRange>()), Times.Never);
        Mock.Get(_mockCacheService).Verify(cs => cs.Set(It.IsAny<string>(), It.IsAny<object>()), Times.Never);
    }

    private INumberRule CreateMockRule(string ruleOutput)
    {
        var mockRule = new Mock<INumberRule>();
        mockRule.Setup(r => r.Output).Returns(ruleOutput);
        mockRule.Setup(r => r.NumUses).Returns(2);

        return mockRule.Object;
    }
}