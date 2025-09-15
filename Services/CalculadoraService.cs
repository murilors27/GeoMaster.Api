using GeoMaster.Api.Domain.Interfaces;
using GeoMaster.Api.Domain.Shapes;
using GeoMaster.Api.Dtos;

namespace GeoMaster.Api.Services;

public class CalculadoraService : ICalculadoraService
{
    private readonly IShapeFactory _factory;

    public CalculadoraService(IShapeFactory factory) => _factory = factory;

    public double CalcularArea(ShapeRequestDto dto)
    {
        var forma = _factory.CriarForma(dto);
        if (forma is ICalculos2D f2d) return f2d.CalcularArea();
        throw new InvalidOperationException("A forma não suporta cálculo de área.");
    }

    public double CalcularPerimetro(ShapeRequestDto dto)
    {
        var forma = _factory.CriarForma(dto);
        if (forma is ICalculos2D f2d) return f2d.CalcularPerimetro();
        throw new InvalidOperationException("A forma não suporta cálculo de perímetro.");
    }

    public double CalcularVolume(ShapeRequestDto dto)
    {
        var forma = _factory.CriarForma(dto);
        if (forma is ICalculos3D f3d) return f3d.CalcularVolume();
        throw new InvalidOperationException("A forma não suporta cálculo de volume.");
    }

    public double CalcularAreaSuperficial(ShapeRequestDto dto)
    {
        var forma = _factory.CriarForma(dto);
        if (forma is ICalculos3D f3d) return f3d.CalcularAreaSuperficial();
        throw new InvalidOperationException("A forma não suporta cálculo de área superficial.");
    }

    public bool EstaContida(FormaContidaRequest dto)
    {
        var externa = _factory.CriarForma(dto.FormaExterna);
        var interna = _factory.CriarForma(dto.FormaInterna);

        return (externa, interna) switch
        {
            (Retangulo R, Circulo C) => CirculoDentroDeRetangulo(C, R),
            (Retangulo R1, Retangulo R2) => RetanguloDentroDeRetangulo(R2, R1),
            (Circulo C1, Circulo C2) => CirculoDentroDeCirculo(C2, C1),
            (Circulo C, Retangulo R) => RetanguloDentroDeCirculo(R, C),

            _ => throw new InvalidOperationException("Combinação de formas ainda não suportada para verificação de contenção.")
        };
    }

    private static bool CirculoDentroDeRetangulo(Circulo c, Retangulo r)
        => (2 * c.Raio) <= r.Largura && (2 * c.Raio) <= r.Altura;

    private static bool RetanguloDentroDeRetangulo(Retangulo interno, Retangulo externo)
        => interno.Largura <= externo.Largura && interno.Altura <= externo.Altura;

    private static bool CirculoDentroDeCirculo(Circulo interno, Circulo externo)
        => interno.Raio <= externo.Raio;

    private static bool RetanguloDentroDeCirculo(Retangulo r, Circulo c)
    {
        var semiDiagonal = Math.Sqrt(Math.Pow(r.Largura, 2) + Math.Pow(r.Altura, 2)) / 2.0;
        return semiDiagonal <= c.Raio;
    }
}
