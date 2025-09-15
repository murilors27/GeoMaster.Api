using GeoMaster.Api.Dtos;

namespace GeoMaster.Api.Services;

public interface IShapeFactory
{
    object CriarForma(ShapeRequestDto dto); // retorna instância que implementa ICalculos2D ou ICalculos3D
    object CriarForma(string tipoForma, Dictionary<string, double> props);
}
