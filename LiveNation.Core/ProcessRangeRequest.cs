namespace LiveNation.Core;

using System.ComponentModel.DataAnnotations;

public class ProcessRangeRequest
{
    [Required]
    public int? Start { get; set; }

    [Required]
    public int? End { get; set; }
}
