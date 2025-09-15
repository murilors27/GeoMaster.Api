using System.ComponentModel.DataAnnotations;

namespace GeoMaster.Api.Dtos;

public class ShapeRequestDto
{
    [Required]
    public string TipoForma { get; set; } = string.Empty;

    [Required]
    public Dictionary<string, double> Propriedades { get; set; } = new();
}
