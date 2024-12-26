using Simt.Common.enums;
using Simt.Common.Models.InterfaceBase;

namespace Simt.Common.Models;

public record ServiceListModel() : ModelBase
{
    public required int AvgAhead { get; set; }
    public required int AvgDelay { get; set; }
    public required int PassengersCarried { get; set; }
    public required int GameMoneyGained { get; set; }
    public required DateTime DateTime { get; set; }
    
    public required Guid LineId { get; set; }
    public required Guid VehicleId { get; set; }
    
    public required string LineName { get; set; }
    public required string LineDirection { get; set; }
    public required Traction LineTraction { get; set; }
    
    public required string VehicleType { get; set; }
    public required string VehicleNumber { get; set; }

    public static ServiceListModel Empty => new ()
    {
        Id = Guid.NewGuid(),
        AvgAhead = 0,
        AvgDelay = 0,
        PassengersCarried = 0,
        GameMoneyGained = 0,
        DateTime = default,
        LineId = Guid.Empty,
        VehicleId = Guid.Empty,
        LineName = String.Empty,
        LineDirection = String.Empty,
        LineTraction = Traction.Bus,
        VehicleType = String.Empty,
        VehicleNumber = String.Empty
    };
}