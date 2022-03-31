namespace LiveNation.Api.Services;

using LiveNation.Core;

public interface INumberService
{
    public ProcessRangeResponse ProcessRange(NumberRange inputs);
}