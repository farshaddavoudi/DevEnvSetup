namespace DaprProjA;

public static class DaprConst
{
    /// <summary>
    /// Dapr Store Component Name
    /// </summary>
    public const string StoreName = "statestore";

    public class AppId
    {
        public const string ProjectB = "DaprProjB";
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
            public const string UserDismissedRouteKey = "route1";
            public const string SubscribeUserDismissedRouteKey = $"event.type == \"{UserDismissedRouteKey}\"";
            public const string UserPostChangedRouteKey = "route2";
            public const string SubscribeUserPostChangedRouteKey = $"event.type == \"{UserPostChangedRouteKey}\"";
        }
    }
}
