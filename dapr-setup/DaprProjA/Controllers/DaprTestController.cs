using Dapr.Client;
using Microsoft.AspNetCore.Mvc;

namespace _Dapr1.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class DaprTestController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> InvokeHttp(CancellationToken cancellationToken)
    {
        var client = new DaprClientBuilder().Build();

        var person = await client.InvokeMethodAsync<Person>(HttpMethod.Get, "_Dapr2", "Person/Friend", cancellationToken);

        return Ok(person);
    }

    [HttpPost]
    public async Task<IActionResult> SetState()
    {
        string DAPR_STORE_NAME = "statestore";

        var client = new DaprClientBuilder().Build();

        await client.SaveStateAsync<string>(DAPR_STORE_NAME, "Name", "Farshad");

        return Ok("Done");
    }

    [HttpGet]
    public async Task<IActionResult> GetState()
    {
        string DAPR_STORE_NAME = "statestore";

        var client = new DaprClientBuilder().Build();

        var value = await client.GetStateAsync<string>(DAPR_STORE_NAME, "Name");

        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> PublishMessage(CancellationToken cancellationToken)
    {
        var client = new DaprClientBuilder().Build();

        var data = new Person() { FullName = "Feri" };

        await client.PublishEventAsync("rabbitmq-pubsub", "test-topic", data, cancellationToken);

        return Ok("Published");
    }

    [HttpPost]
    public async Task<IActionResult> PublishMessageWithRouteKey(string routeKey, CancellationToken cancellationToken)
    {
        var client = new DaprClientBuilder().Build();

        var data = new Person() { FullName = "Feri" };

        // Override cloudevent metadata
        var metadata = new Dictionary<string, string> { { "cloudevent.type", routeKey } };

        await client.PublishEventAsync("rabbitmq-pubsub", "test-topic", data, metadata, cancellationToken);

        return Ok("Published");
    }

    public class Person
    {
        public string? FullName { get; set; }
    }
}