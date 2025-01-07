using System.Text;
using Newtonsoft.Json;
using Simt.Common.enums;
using Simt.Common.Models;

namespace Simt.Api.App.EndToEndTests;

[Collection("SequentialTests")]
public class VehicleControllerTests : IAsyncDisposable
{
    private readonly SimtApiApplicationFactory _application;
    private readonly Lazy<HttpClient> _client;
    
    public VehicleControllerTests()
    {
        _application = new SimtApiApplicationFactory();
        _client = new Lazy<HttpClient>(_application.CreateClient());
    }
    
    private readonly VehicleDetailModel _newVehicle = new()
    {
        Id = Guid.Parse("1ebf3777-a66e-40a0-ac8b-537ad9630385"),
        Manufacturer = "TestManufacturer",
        Type = "TestType",
        Operator = "TestOperator",
        ManufacturerShort = "TestManufacturerShort",
        TypeShort = "TestTypeShort",
        OperatorShort = "TestOperatorShort",
        VehicleNumber = "TestVehicleNumber",
        SCIN = "TestSCIN",
        SizeB = "0",
        Line = null,
        Author = null,
        GameVersion = null,
        AlternativeDrive = false,
        TwoWay = false,
        DieselDrive = false,
        CngDrive = false,
        BatteryDrive = false,
        AirConditioning = false,
        GoldVersion = false,
        Status = Status.InPreparation,
        Traction = Traction.Bus,
        LowFloor = LowFloor.HighFloor
    };
    
    [Fact]
    public async Task CreateNewVehicle_Returns_SuccessStatusCode()
    {
        // Arrange
        var content = new StringContent(JsonConvert.SerializeObject(_newVehicle), Encoding.UTF8, "application/json");

        // Act
        var response = await _client.Value.PostAsync("/vehicle", content);

        // Assert
        var returnedVehicle = await response.Content.ReadFromJsonAsync<VehicleDetailModel>();
        response.EnsureSuccessStatusCode();
        Assert.NotNull(returnedVehicle);
        Assert.Equal(_newVehicle.Id, returnedVehicle.Id);
        Assert.NotEqual(Guid.Empty, returnedVehicle.Id);
    }
    
    [Fact]
    public async Task GetAllVehicles_Returns_At_Least_One_Vehicle()
    {
        var response = await _client.Value.GetAsync("/vehicle/all");

        response.EnsureSuccessStatusCode();

        var vehicles = await response.Content.ReadFromJsonAsync<ICollection<VehicleListModel>>();
        Assert.NotNull(vehicles);
        Assert.NotEmpty(vehicles);
    }
    
    public async ValueTask DisposeAsync()
    {
        await _application.DisposeAsync();
    }
}