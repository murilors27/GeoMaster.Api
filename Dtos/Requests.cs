using System.ComponentModel.DataAnnotations;

namespace GeoMaster.Api.Dtos;

public class AreaRequest : ShapeRequestDto { }
public class PerimetroRequest : ShapeRequestDto { }
public class VolumeRequest : ShapeRequestDto { }
public class AreaSuperficialRequest : ShapeRequestDto { }

public class FormaContidaRequest
{
    [Required] public ShapeRequestDto FormaExterna { get; set; } = new();
    [Required] public ShapeRequestDto FormaInterna { get; set; } = new();
}
