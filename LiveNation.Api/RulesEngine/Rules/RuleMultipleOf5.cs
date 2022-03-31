namespace LiveNation.Api.RulesEngine.Rules;

public class RuleMultipleOf5 : BaseNumberRule
{
    public override string Output => "Nation";

    public override RuleResult Match(int number)
    {
        Math.DivRem(number, 5, out int remainder);

        if (number != 0 && remainder == 0)
        {
            _numUses++;
            return new RuleResult(true, Output);
        }

        return new RuleResult(false);
    }
}
