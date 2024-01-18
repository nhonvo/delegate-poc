using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controller;


// Interface for distance calculation service
public interface IDistanceCalculationService
{
    double CalculateDistance();
}

// Implementation for Google distance calculation service
public class GoogleDistanceService : IDistanceCalculationService
{
    public double CalculateDistance()
    {
        // Simulate Google distance calculation logic
        Console.WriteLine("Calculating distance using Google service...");
        return 100.0; // Just a dummy value for the demo
    }
}

// Implementation for PCMiler distance calculation service
public class PCMilerDistanceService : IDistanceCalculationService
{
    public double CalculateDistance()
    {
        // Simulate PCMiler distance calculation logic
        Console.WriteLine("Calculating distance using PCMiler service...");
        return 150.0; // Just a dummy value for the demo
    }
}

public delegate IDistanceCalculationService DistanceProviderResolver(DistanceProvider? engine);
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum DistanceProvider
{
    Google,
    PCMiler
}
[ApiController]
[Route("api/[controller]")]
public class DistanceController(DistanceProviderResolver resolver) : ControllerBase
{
    private readonly DistanceProviderResolver _resolver = resolver;

    [HttpGet]
    public IActionResult GetDistance(DistanceProvider distanceProvider)
    {

        var distanceService = _resolver(distanceProvider);
        double distance = distanceService.CalculateDistance();
        return Ok($"Calculated distance: {distance} miles");
    }
}
