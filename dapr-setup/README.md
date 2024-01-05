## Initialize Dapr Runtime

**Fetch the Dapr sidecar binaries and install them locally using:**

`dapr init --slim` 

- It initializes Dapr without dependency on Docker, which means it doesn't pull and run default containers as well as doesn't create any default statestore or pubsub components.

> Check Dapr CLI and Runtime versions:
`dapr --version`

## Setup Dapr SDK

- **Install Dapr Nuget Package:**

`dotnet add package Dapr.AspNetCore`

- **Do Changes in `program.cs` file**
```csharp
// AddDapr(): Registers the Dapr integration with controllers. This also registers the DaprClient service with the dependency injection container (using the sepcified DaprClientBuilder for settings options). This service can be used to interact with the dapr runtime (e.g. invoke services, publish messages, interact with a state-store, ...).
builder.Services.AddControllers().AddDapr(daprClientBuilder =>
    daprClientBuilder.UseJsonSerializationOptions(
        new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = true
        }));
```
```csharp
app.UseHttpsRedirection(); // Remove this middleware

app.UseCloudEvents(); // Unwraps requests with Content-Type application/cloudevents+json so that model binding can access the event payload in the request body directly. Recommended when using pub/sub

app.UseAuthorization();
```
```csharp
app.MapSubscribeHandler(); // Registers an endpoint that will be called by the Dapr runtime to register for pub/sub topics. This is is not needed unless using pub/sub.

app.MapControllers();
```

## Interact with Dapr in .NET Core app

Check out the *DaprProjA* and *DaprProjB* projects in this repo.