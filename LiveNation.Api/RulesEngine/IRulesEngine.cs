namespace LiveNation.Api.RulesEngine;

using LiveNation.Api.RulesEngine.Rules;
using LiveNation.Core;

public interface IRulesEngine
{
    public INumberRule[] Rules { get; }

    public string ProcessRange(NumberRange range);
}
