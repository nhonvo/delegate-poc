# Proof of Concept: Dynamic Distance Calculation with Delegates

Welcome to the Proof of Concept (PoC) repository for dynamic distance calculation using delegates. This project demonstrates the usage of delegates to dynamically resolve distance calculation services in a web API.

## Purpose

This PoC showcases the following:

- Dynamic resolution of distance calculation providers using delegates.
- Integration of Google and PCMiler distance calculation services.
- Basic web API for fetching calculated distances.

## Key Features

- **Dynamic Resolution with Delegates:**
  The project leverages delegates for dynamic resolution of distance calculation services. The `DistanceCalculator` class uses a delegate (`DistanceProviderResolver`) to dynamically choose the service based on the selected distance provider.

```csharp
var distanceCalculator = new DistanceCalculator();
var distanceService = distanceCalculator.ResolveDistanceProvider(DistanceProvider.Google);
double distance = distanceService.CalculateDistance("Origin", "Destination");
```
