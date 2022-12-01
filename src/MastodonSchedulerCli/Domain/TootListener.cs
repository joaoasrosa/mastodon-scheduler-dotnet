namespace MastodonSchedulerCli.Domain;

public class TootListener
{
    public TootListener(string folderWithToots)
    {
        if (string.IsNullOrWhiteSpace(folderWithToots))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(folderWithToots));

        if (!Directory.Exists(folderWithToots))
            throw new DirectoryNotFoundException($"'{folderWithToots}' does not exist");

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