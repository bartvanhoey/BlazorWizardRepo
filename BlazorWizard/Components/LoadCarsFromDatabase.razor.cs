using Microsoft.AspNetCore.Components;

namespace BlazorWizard.Components;

public partial class LoadCarsFromDatabase : ComponentBase
{
    [Parameter] public EventCallback<CarFromDatabaseLoadedResult> OnCarFromDatabaseLoaded { get; set; }
    
    private DummyCar? _selectedCar;

    private async Task StartSounding()
    {
        await Task.CompletedTask;
    }

    private string? SearchText { get; set; }
    public bool IsSearchButtonDisabled { get; set; }

    private async Task HandleOnKeyup()
    {
        await Task.CompletedTask;
    }

    private async Task HandleOnInput()
    {
        
        await Task.CompletedTask;
        
    }

    private async Task SearchCar()
    {
        await Task.CompletedTask;
    }

    private async Task LoadCar()
    {
        await OnCarFromDatabaseLoaded.InvokeAsync(new CarFromDatabaseLoadedResult {IsValidResult = true});
    }

    private List<DummyCar?> Cars { get; set; } =
    [
        new(21029358, 404.41, new DateTime(2021, 12, 12, 12, 0, 0)),
        new(21029357, 404.51, new DateTime(2021, 12, 12, 12, 0, 0)),
        new(21029356, 404.61, new DateTime(2021, 12, 12, 12, 0, 0)),
        new(21029355, 404.41, new DateTime(2021, 12, 12, 12, 0, 0)),
        new(21029354, 404.81, new DateTime(2021, 12, 12, 12, 0, 0)),
        new(21029353, 404.31, new DateTime(2021, 12, 12, 12, 0, 0)),
        new(21029351, 404.91, new DateTime(2021, 12, 12, 12, 0, 0)),
        new(21029350, 404.21, new DateTime(2021, 12, 12, 12, 0, 0))
    ];
}

public class CarFromDatabaseLoadedResult
{
    public bool IsValidResult { get; set; }
}

public class DummyCar
{
    public DummyCar(long serialNumber, double channel, DateTime date)
    {
        SerialNumber = serialNumber;
        Channel = channel;
        Date = date;
    }

    public long SerialNumber { get; set; }
    public double Channel { get; set; }
    public DateTime Date { get; set; }
}