using System;

namespace GeoMaster.Api.Domain.Shapes;

[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public sealed class ShapeAttribute : Attribute
{
	public string TipoForma { get; }
	public ShapeAttribute(string tipoForma) => TipoForma = tipoForma.ToLowerInvariant();
}
