namespace Simt.DAL.entities;

public record HracEntita:IEntity
{
    public required Guid Id { get; set; }
    public required string Nick { get; init; }
    public required int PoslednyLogin { get; init; }
    public required int OdohrateHodiny { get; init; }
    public required int PrevezeniCestujuci { get; init; }
    public required int ZiskaneBody { get; init; }
    public required int HernePeniaze { get; init; }
    public required float Palivo { get; init; }
    public required float Cng { get; init; }
    public required float ServisVydaje { get; init; }
    public required int KmCelkove { get; init; }
    public required int KmRocne { get; init; }

    public ICollection<SpojEntita> Spoje { get; init; } = [];
}