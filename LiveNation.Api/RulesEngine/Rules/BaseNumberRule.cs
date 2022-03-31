namespace LiveNation.Api.RulesEngine.Rules;

public abstract class BaseNumberRule : INumberRule
{
    protected int _numUses = 0;
    public int NumUses => _numUses;
    public abstract string Output { get; }
    public abstract RuleResult Match(int number);
    public void ResetCount() => _numUses = 0;
}
