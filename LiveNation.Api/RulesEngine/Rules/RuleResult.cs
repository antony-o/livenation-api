namespace LiveNation.Api.RulesEngine.Rules;

public class RuleResult
{
    public bool IsMatch { get; }
    public string? RuleOutput { get; }

    public RuleResult(bool isMatch, string? ruleOutput = null)
    {
        IsMatch = isMatch;
        RuleOutput = ruleOutput;
    }
}
