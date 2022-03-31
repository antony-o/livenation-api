namespace LiveNation.Api.RulesEngine.Rules;

public class RuleMultipleOf3 : BaseNumberRule
{
    public override string Output => "Live";

    public override RuleResult Match(int number)
    {
        Math.DivRem(number, 3, out int remainder);

        if (number != 0 && remainder == 0)
        {
            _numUses++;
            return new RuleResult(true, Output);
        }

        return new RuleResult(false);
    }
}
