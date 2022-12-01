using Mastonet;

namespace MastodonSchedulerCli.UnitTests;

public static class Given
{
    public static class A
    {
        public static class Toot
        {
            public static string WithoutAttachedMedia
            {
                get { return string.Empty; }
            }
        }

        public static MastodonClient MastodonClient => new MastodonClient(Guid.NewGuid().ToString(), Guid.NewGuid().ToString());
    }
}