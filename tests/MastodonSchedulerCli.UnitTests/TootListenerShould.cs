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
}