namespace DaprProjB;

public static class DaprConst
{
    /// <summary>
    /// Dapr Store Component Name
    /// </summary>
    public const string StoreName = "statestore";

    public class AppId
    {
        public const string ProjectA = "DaprProjA";
    }

    public class PubSub
    {
        /// <summary>
        /// Dapr PubSub Component Name
        /// </summary>
        public const string Name = "rabbitmq-pubsub";

        /// <summary>
        /// Override CloudEvent Metadata
        /// </summary>
        public static Dictionary<string, string> MetadataToPublishEventWithRouteKey(string routeKey) => new() { { "cloudevent.type", routeKey } };

        public class DaprTestedEvent
        {
            public const string TopicName = "test-topic";
            private const string RouteKey1 = "route1";
            public const string MatchRouteKey1 = $"event.type == \"{RouteKey1}\"";
            private const string RouteKey2 = "route2";
            public const string MatchRouteKey2 = $"event.type == \"{RouteKey2}\"";
        }
    }
}
