using Dapr;
using Microsoft.AspNetCore.Mvc;

namespace DaprProjB.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class EventSubscriberController : ControllerBase
{
    [Topic(DaprConst.PubSub.Name,
        DaprConst.PubSub.DaprTestedEvent.TopicName,
        DaprConst.PubSub.DaprTestedEvent.SubscribeBoxIdEditedUser,
        1)]
    [HttpPost]
    public async Task<IActionResult> TestEvent1(Person person)
    {
        Console.WriteLine("Subscriber received - RouteKey1 : " + person.FullName);
        return Ok();
    }

    [Topic(DaprConst.PubSub.Name,
        DaprConst.PubSub.DaprTestedEvent.TopicName,
        DaprConst.PubSub.DaprTestedEvent.SubscribeUserPostChangedRouteKey,
        2)]
    [HttpPost]
    public async Task<IActionResult> TestEvent2(Person person)
    {
        Console.WriteLine("Subscriber received - RouteKey2 : " + person.FullName);
        return Ok();
    }

    [Topic(DaprConst.PubSub.Name, DaprConst.PubSub.DaprTestedEvent.TopicName)]
    [HttpPost]
    public async Task<IActionResult> TestEventDefault(Person person)
    {
        Console.WriteLine("Subscriber received - RouteKey3 : " + person.FullName);
        return Ok();
    }

    public class Person
    {
        public string? FullName { get; set; }
    }
}