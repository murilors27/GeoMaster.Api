using GeoMaster.Api.Dtos;

namespace GeoMaster.Api.Services;

public interface ICalculadoraService
{
    double CalcularArea(ShapeRequestDto dto);
    double CalcularPerimetro(ShapeRequestDto dto);
    double CalcularVolume(ShapeRequestDto dto);
    double CalcularAreaSuperficial(ShapeRequestDto dto);

    bool EstaContida(FormaContidaRequest dto);
}
