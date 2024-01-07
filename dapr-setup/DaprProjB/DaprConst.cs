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
            private const string SubscribeUserDismissedRouteKey = "route1";
            public const string SubscribeBoxIdEditedUser = $"event.type == \"{SubscribeUserDismissedRouteKey}\"";
            private const string UserPostChangedRouteKey = "route2";
            public const string SubscribeUserPostChangedRouteKey = $"event.type == \"{UserPostChangedRouteKey}\"";
        }
    }
}
