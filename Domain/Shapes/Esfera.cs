using GeoMaster.Api.Domain.Interfaces;

namespace GeoMaster.Api.Domain.Shapes;

[Shape("esfera")]
public class Esfera : ICalculos3D
{
    public double Raio { get; }
    public Esfera(double raio)
    {
        if (raio <= 0) throw new ArgumentOutOfRangeException(nameof(raio));
        Raio = raio;
    }

    public double CalcularVolume() => (4.0 / 3.0) * Math.PI * Math.Pow(Raio, 3);
    public double CalcularAreaSuperficial() => 4 * Math.PI * Raio * Raio;
}
