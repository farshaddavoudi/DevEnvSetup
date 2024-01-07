using Dapr.Client;
using Microsoft.AspNetCore.Mvc;

namespace DaprProjA.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class DaprTestController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> InvokeHttp(CancellationToken cancellationToken)
    {
        var client = new DaprClientBuilder().Build();

        var person = await client.InvokeMethodAsync<Person>(HttpMethod.Get, DaprConst.AppId.ProjectB, "Person/Friend", cancellationToken);

        return Ok(person);
    }

    [HttpPost]
    public async Task<IActionResult> SetState()
    {
        var client = new DaprClientBuilder().Build();

        await client.SaveStateAsync<string>(DaprConst.StoreName, "Name", "Farshad");

        return Ok("Done");
    }

    [HttpGet]
    public async Task<IActionResult> GetState()
    {
        var client = new DaprClientBuilder().Build();

        var value = await client.GetStateAsync<string>(DaprConst.StoreName, "Name");

        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> PublishMessage(CancellationToken cancellationToken)
    {
        var client = new DaprClientBuilder().Build();

        var data = new Person() { FullName = "Feri" };

        await client.PublishEventAsync(DaprConst.PubSub.Name, DaprConst.PubSub.DaprTestedEvent.TopicName, data, cancellationToken);

        return Ok("Published");
    }

    [HttpPost]
    public async Task<IActionResult> PublishMessageWithRouteKey(string routeKey, CancellationToken cancellationToken)
    {
        var client = new DaprClientBuilder().Build();

        var data = new Person() { FullName = "Feri" };

        var metadata = DaprConst.PubSub.MetadataToPublishEventWithRouteKey(DaprConst.PubSub.DaprTestedEvent.RouteKey1);

        await client.PublishEventAsync(DaprConst.PubSub.Name, DaprConst.PubSub.DaprTestedEvent.TopicName, data, metadata, cancellationToken);

        return Ok("Published");
    }

    public class Person
    {
        public string? FullName { get; set; }
    }
}