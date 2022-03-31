namespace LiveNation.Api.RulesEngine.Rules;

public class RuleNoMatch : BaseNumberRule
{
    public override string Output => "Integer";

    public override RuleResult Match(int number)
    {
        _numUses++;
        return new RuleResult(true, $"{number}");
    }
}
