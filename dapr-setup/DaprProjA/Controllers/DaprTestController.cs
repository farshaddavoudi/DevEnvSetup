using Dapr.Client;
using Microsoft.AspNetCore.Mvc;

namespace DaprProjA.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class DaprTestController(DaprClient daprClient) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> InvokeHttp(CancellationToken cancellationToken)
    {
        var person = await daprClient.InvokeMethodAsync<Person>(
            HttpMethod.Get,
            DaprConst.AppId.ProjectB,
            "Person/Friend",
            cancellationToken);

        return Ok(person);
    }

    [HttpPost]
    public async Task<IActionResult> SetState(CancellationToken cancellationToken)
    {
        // Fixed
        await daprClient.SaveStateAsync<string>(DaprConst.StoreName, "Name", "Farshad", cancellationToken: cancellationToken);

        // With TTL
        await daprClient.SaveStateAsync<string>(
            DaprConst.StoreName,
            "Name",
            "Farshad",
            new StateOptions(),
            DaprConst.MetadataToSetStateTtl(TimeSpan.FromDays(1)),
            cancellationToken);

        return Ok("Done");
    }

    [HttpGet]
    public async Task<IActionResult> GetState()
    {
        var value = await daprClient.GetStateAsync<string>(DaprConst.StoreName, "Name");

        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> PublishMessage(CancellationToken cancellationToken)
    {
        var data = new Person { FullName = "Feri" };

        await daprClient.PublishEventAsync(DaprConst.PubSub.Name, DaprConst.PubSub.DaprTestedEvent.TopicName, data, cancellationToken);

        return Ok("Published");
    }

    [HttpPost]
    public async Task<IActionResult> PublishMessageWithRouteKey(string routeKey, CancellationToken cancellationToken)
    {
        var data = new Person() { FullName = "Feri" };

        var metadata = DaprConst.PubSub.MetadataToPublishEventWithRouteKey(DaprConst.PubSub.DaprTestedEvent.UserDismissedRouteKey);

        await daprClient.PublishEventAsync(DaprConst.PubSub.Name, DaprConst.PubSub.DaprTestedEvent.TopicName, data, metadata, cancellationToken);

        return Ok("Published");
    }

    public class Person
    {
        public string? FullName { get; set; }
    }
}