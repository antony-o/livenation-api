namespace LiveNation.Api.RulesEngine;

using LiveNation.Api.RulesEngine.Rules;
using LiveNation.Core;

public class RulesEngine : IRulesEngine
{
    public INumberRule[] Rules { get; private set; }

    public RulesEngine()
    {
        Rules = new INumberRule[]
            {
                new RuleMultipleOf3and5(),
                new RuleMultipleOf3(),
                new RuleMultipleOf5(),
                new RuleNoMatch()
            };
    }

    public string ProcessRange(NumberRange range)
    {
        if (range.End < range.Start)
        {
            throw new ArgumentOutOfRangeException("End", "Must be grater than Start");
        }

        string engineResult = "";
        ResetRuleCounts();

        foreach (var num in Enumerable.Range(range.Start, range.End - range.Start + 1))
        {
            string? output = string.Empty;

            foreach(var rule in Rules)
            {
                var ruleResult = rule.Match(num);
                if (ruleResult.IsMatch)
                {
                    output = ruleResult.RuleOutput;
                    break;
                }
            }

            output = string.IsNullOrEmpty(output) ? $" {num}" : $" {output}";
            if (string.IsNullOrEmpty(engineResult))
            {
                output = output.Trim();
            }

            engineResult += output;
        }

        return engineResult;
    }

    private void ResetRuleCounts()
    {
        foreach (var rule in Rules)
        {
            rule.ResetCount();
        }
    }
}
