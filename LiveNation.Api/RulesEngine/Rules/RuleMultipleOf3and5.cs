namespace LiveNation.Api.RulesEngine.Rules;

public class RuleMultipleOf3and5 : BaseNumberRule
{
    public override string Output => "LiveNation";

    public override RuleResult Match(int number)
    {
        Math.DivRem(number, 3, out int remainderDivisor3);
        Math.DivRem(number, 5, out int remainderDivisor5);

        if (number != 0 && remainderDivisor3 == 0 && remainderDivisor5 == 0)
        {
            _numUses++;
            return new RuleResult(true, Output);
        }

        return new RuleResult(false);
    }
}
