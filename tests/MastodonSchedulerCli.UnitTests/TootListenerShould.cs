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
        Check.ThatCode(() => new TootListener(folderWithToots)).Throws<ArgumentException>();
    }

    [Fact]
    public void ThrowDirectoryNotFoundException_WhenConfiguredPathDoesNotExists()
    {
        Check.ThatCode(() => new TootListener(new Guid().ToString())).Throws<DirectoryNotFoundException>();
    }

    [Fact]
    public void PublishToot_WhenNoMediaIsAttached()
    {
        var folderWithToot = Given.A.Toot.WithoutAttachedMedia;

        var tootListener = new TootListener(folderWithToot);

        Check.That(true).IsFalse();
    }
}