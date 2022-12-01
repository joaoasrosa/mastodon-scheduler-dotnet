using MastodonSchedulerCli.Domain;
using NFluent;

namespace MastodonSchedulerCli.UnitTests;

public class TootListenerShould
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void ThrowArgumentException_WhenConfiguredPathIsNullEmptyOrWhiteSpace(string folderWithToots)
    {
        Check.ThatCode(() => new TootListener(folderWithToots, Given.A.MastodonClient))
            .Throws<ArgumentException>();
    }

    [Fact]
    public void ThrowDirectoryNotFoundException_WhenConfiguredPathDoesNotExists()
    {
        Check.ThatCode(() => new TootListener(new Guid().ToString(), Given.A.MastodonClient))
            .Throws<DirectoryNotFoundException>();
    }

    [Fact]
    public void PublishToot_WhenNoMediaIsAttached()
    {
        var folderWithToot = Given.A.Toot.WithoutAttachedMedia;

        var tootListener = new TootListener(folderWithToot, Given.A.MastodonClient);

        Check.That(true).IsFalse();
    }
}