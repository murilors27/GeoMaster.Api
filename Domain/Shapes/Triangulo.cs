using GeoMaster.Api.Domain.Interfaces;
using GeoMaster.Api.Domain.Shapes;

[Shape("triangulo")]
public class Triangulo : ICalculos2D
{
    public double Base { get; }
    public double Altura { get; }
    public double LadoA { get; }
    public double LadoB { get; }

    public Triangulo(double @base, double altura, double ladoa, double ladob)
    {
        if (@base <= 0 || altura <= 0 || ladoa <= 0 || ladob <= 0) throw new ArgumentOutOfRangeException();
        Base = @base; Altura = altura; LadoA = ladoa; LadoB = ladob;
    }

    public double CalcularArea() => (Base * Altura) / 2.0;
    public double CalcularPerimetro() => Base + LadoA + LadoB;
}
