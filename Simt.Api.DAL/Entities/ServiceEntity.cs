﻿namespace Simt.Api.DAL.entities;

public record ServiceEntity:IEntity
{
    public required Guid Id { get; set; }
    public required int AvgAhead { get; set; }
    public required int AvgDelay { get; set; }
    public required int PassengersCarried { get; set; }
    public required int GameMoneyGained { get; set; }
    public required DateTime DateTime { get; set; }
    public required bool Finished { get; set; }
    
    public required Guid PlayerId { get; set; }
    public required Guid? RouteId { get; set; }
    public required Guid? VehicleId { get; set; }
    
    public required PlayerEntity Player { get; init; }
    public required RouteEntity Route { get; init; }
    public required VehicleEntity Vehicle { get; init; }
}