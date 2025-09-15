using System.Reflection;
using GeoMaster.Api.Domain.Interfaces;
using GeoMaster.Api.Domain.Shapes;
using GeoMaster.Api.Dtos;

namespace GeoMaster.Api.Services;

public class ShapeFactory : IShapeFactory
{
    private readonly Dictionary<string, Type> _map;

    public ShapeFactory()
    {
        _map = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.GetCustomAttribute<ShapeAttribute>() is not null)
            .ToDictionary(
                t => t.GetCustomAttribute<ShapeAttribute>()!.TipoForma,
                t => t
            );
    }

    public object CriarForma(ShapeRequestDto dto) => CriarForma(dto.TipoForma, dto.Propriedades);

    public object CriarForma(string tipoForma, Dictionary<string, double> props)
    {
        if (!_map.TryGetValue(tipoForma.ToLowerInvariant(), out var type))
            throw new ArgumentException($"Forma desconhecida: {tipoForma}");

        var ctor = type.GetConstructors().OrderBy(c => c.GetParameters().Length).First();

        var args = ctor.GetParameters().Select(p =>
        {
            if (!props.TryGetValue(p.Name!.ToLowerInvariant(), out var val))
                throw new ArgumentException($"Propriedade obrigatória ausente: '{p.Name}' para '{tipoForma}'");
            return (object)val;
        }).ToArray();

        return Activator.CreateInstance(type, args)!;
    }
}
