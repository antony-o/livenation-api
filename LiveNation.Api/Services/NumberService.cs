namespace LiveNation.Api.Services;

using LiveNation.Api.RulesEngine;
using LiveNation.Core;
using System.Linq;

public class NumberService : INumberService
{
    private readonly IRulesEngine _rulesEngine;
    private readonly ICacheService _cacheService;

    public NumberService(
        IRulesEngine rulesEngine,
        ICacheService cacheService
        )
    {
        _rulesEngine = rulesEngine;
        _cacheService = cacheService;
    }

    public ProcessRangeResponse ProcessRange(NumberRange range)
    {
        var cacheKey = $"range:{range.Start}-{range.End}";

        var response = _cacheService.Get<ProcessRangeResponse>(cacheKey);

        if (response == null)
        {
            response = new ProcessRangeResponse();
            response.Result = _rulesEngine.ProcessRange(range);
            response.Summary = _rulesEngine.Rules.ToDictionary(rule => rule.Output, rule => $"{rule.NumUses}");

            _cacheService.Set(cacheKey, response);
        }

        return response;
    }
}
