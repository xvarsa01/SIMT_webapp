namespace Simt.DAL.entities;

public record SpojEntita:IEntity
{
    public required Guid Id { get; set; }
    public required int PriemNaskok { get; set; }
    public required int PriemMeskanie { get; set; }
    public required int PocetCestujucich { get; set; }
    public required int ZarobenePeniaze { get; set; }
    public required DateTime DatumCas { get; set; }
    
    public required Guid HracId { get; set; }
    public required Guid LinkaId { get; set; }
    public required Guid VozidloId { get; set; }
    
    public required HracEntita Hrac { get; init; }
    public required LinkaEntita Linka { get; init; }
    public required VozidloEntita Vozidlo { get; init; }
}