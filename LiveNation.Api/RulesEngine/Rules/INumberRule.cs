namespace LiveNation.Api.RulesEngine.Rules;

public interface INumberRule
{
    public RuleResult Match(int number);
    public string Output { get; }
    public int NumUses { get; }
    public void ResetCount();
}