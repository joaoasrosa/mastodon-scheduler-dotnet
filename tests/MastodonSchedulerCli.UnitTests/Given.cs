using Mastonet;

namespace MastodonSchedulerCli.UnitTests;

public static class Given
{
    public static class A
    {
        public static class Toot
        {
            public static string WithoutAttachedMedia => string.Empty;
        }

        public static MastodonClient MastodonClient => new(Guid.NewGuid().ToString(), Guid.NewGuid().ToString());

        public static MastodonClient MastodonClientWithHttpClient(HttpClient httpClient)
        {
            return new MastodonClient(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), httpClient);
        }
    }
}