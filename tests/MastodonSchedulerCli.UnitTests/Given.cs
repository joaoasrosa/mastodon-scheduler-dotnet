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

        public static MastodonClient MastodonClientWithCustomHttpClient(HttpMessageHandler httpMessageHandler)
        {
            return new MastodonClient(
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString(),
                new HttpClient(httpMessageHandler)
            );
        }
    }
}