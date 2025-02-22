using Microsoft.AspNetCore.Components;
using Simt.Common.Models;
using Simt.Web.BL.Facades;

namespace Simt.Web.App.Pages.Admin;

public partial class VehicleEditor : ComponentBase
{
    [Inject]
    public VehicleFacade VehicleFacade { get; set; } = null!;

    private List<VehicleListModel> VehicleListActual { get; set; } = new();
    private List<VehicleListModel> VehicleListFirstLoad { get; set; } = new();
    private List<string> AllManufacturers { get; set; } = new();
    private List<string> AllTypes { get; set; } = new();
    private List<string> AllOperators { get; set; } = new();
    
    private string _selectedManufacturer = "";
    private string _selectedType = "";
    private string _selectedOperator = "";
    private string _selectedVehicleNumber = "";
    
    protected override async Task OnInitializedAsync()
    {
        VehicleListFirstLoad = VehicleListActual = (await VehicleFacade.GetAllAsync())
            .OrderBy(x => x.Status)
            .ThenBy(x => x.VehicleNumber)
            .ToList();
        AllManufacturers = VehicleListFirstLoad.Select(x => x.Manufacturer).Distinct().ToList();
        AllTypes = VehicleListFirstLoad.Select(x => x.Type).Distinct().ToList();
        AllOperators = VehicleListFirstLoad.Select(x => x.Operator).Distinct().ToList();
    }
    
    private void OnSearchVehicleByManufacturer(string value)
    {
        if (!string.IsNullOrEmpty(value))
        {
            _selectedManufacturer = value;
            RecalculateList();
        }
        else
        {
            _selectedManufacturer = "";
            RecalculateList();
            AllManufacturers = VehicleListFirstLoad.Select(x => x.Manufacturer).Distinct().ToList();
        }
        if (_selectedType == "")
        {
            AllTypes = VehicleListActual.Select(x => x.Type).Distinct().ToList();
        }
        if (_selectedOperator == "")
        {
            AllOperators = VehicleListActual.Select(x => x.Operator).Distinct().ToList();
        }
    }
    private void OnSearchVehicleByType(string value)
    {
        if (!string.IsNullOrEmpty(value))
        {
            _selectedType = value;
            RecalculateList();
        }
        else
        {
            _selectedType = "";
            RecalculateList();
            AllTypes = VehicleListActual.Select(x => x.Type).Distinct().ToList();
        }

        if (_selectedManufacturer == "")
        {
            AllManufacturers = VehicleListActual.Select(x => x.Manufacturer).Distinct().ToList();
        }
        if (_selectedOperator == "")
        {
            AllOperators = VehicleListActual.Select(x => x.Operator).Distinct().ToList();
        }
    }
    private void OnSearchVehicleByOperator(string value)
    {
        if (!string.IsNullOrEmpty(value))
        {
            _selectedOperator = value;
            RecalculateList();
        }
        else
        {
            _selectedOperator = "";
            RecalculateList();
            AllOperators = VehicleListActual.Select(x => x.Operator).Distinct().ToList();
        }
        if (_selectedManufacturer == "")
        {
            AllManufacturers = VehicleListActual.Select(x => x.Manufacturer).Distinct().ToList();
        }
        if (_selectedType == "")
        {
            AllTypes = VehicleListActual.Select(x => x.Type).Distinct().ToList();
        }
    }
    private void OnSearchVehicleNumberChange(ChangeEventArgs args)
    {
        var value = args.Value?.ToString();
        if (!string.IsNullOrEmpty(value))
        {
            _selectedVehicleNumber = value;
        }
        else
        {
            _selectedVehicleNumber = "";
        }
        RecalculateList();
        if (_selectedManufacturer == "")
        {
            AllManufacturers = VehicleListActual.Select(x => x.Manufacturer).Distinct().ToList();
        }
        if (_selectedType == "")
        {
            AllTypes = VehicleListActual.Select(x => x.Type).Distinct().ToList();
        }
        if (_selectedOperator == "")
        {
            AllOperators = VehicleListActual.Select(x => x.Operator).Distinct().ToList();
        }
    }

    private void RecalculateList()
    {
        VehicleListActual = VehicleListFirstLoad;

            Console.WriteLine(_selectedManufacturer + " " + _selectedType + " " + _selectedOperator + " " + _selectedVehicleNumber);
        if (!string.IsNullOrEmpty(_selectedManufacturer))
        {
            VehicleListActual = VehicleListActual.Where(v => v.Manufacturer == _selectedManufacturer).ToList();
        }
        if (!string.IsNullOrEmpty(_selectedType))
        {
            VehicleListActual = VehicleListActual.Where(v => v.Type == _selectedType).ToList();
        }
        if (!string.IsNullOrEmpty(_selectedOperator))
        {
            VehicleListActual = VehicleListActual.Where(v => v.Operator == _selectedOperator).ToList();
        }
        if (!string.IsNullOrEmpty(_selectedVehicleNumber))
        {
            VehicleListActual = VehicleListActual.Where(v =>
                v.VehicleNumber.Contains(_selectedVehicleNumber, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
    
    private void CreateNewVehicle()
    {
        
    }

    private void EditVehicle(Guid vehicleId)
    {
        
    }

    private void DeleteVehicle(Guid vehicleId)
    {
        
    }
}