using Mastonet;

namespace MastodonSchedulerCli.Domain;

public class TootListener
{
    private readonly MastodonClient _mastodonClient;

    public TootListener(string folderWithToots, MastodonClient mastodonClient)
    {
        if (string.IsNullOrWhiteSpace(folderWithToots))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(folderWithToots));

        if (!Directory.Exists(folderWithToots))
            throw new DirectoryNotFoundException($"'{folderWithToots}' does not exist");

        _mastodonClient = mastodonClient ?? throw new ArgumentNullException(nameof(mastodonClient));

        var watcher = new FileSystemWatcher(folderWithToots);

        watcher.NotifyFilter = NotifyFilters.Attributes
                               | NotifyFilters.CreationTime
                               | NotifyFilters.DirectoryName
                               | NotifyFilters.FileName
                               | NotifyFilters.LastAccess
                               | NotifyFilters.LastWrite
                               | NotifyFilters.Security
                               | NotifyFilters.Size;

        watcher.Changed += OnChanged;

        watcher.Filter = "*.md";
        watcher.IncludeSubdirectories = true;
        watcher.EnableRaisingEvents = true;
    }

    private void OnChanged(object sender, FileSystemEventArgs e)
    {
        if (e.ChangeType != WatcherChangeTypes.Changed)
        {
            return;
        }
    }
}