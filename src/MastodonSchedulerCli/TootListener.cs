namespace MastodonSchedulerCli;

public class TootListener
{
    public TootListener(string folderWithToots)
    {
        var watcher = new FileSystemWatcher(folderWithToots);

        watcher.Changed += OnChanged;
    }

    private void OnChanged(object sender, FileSystemEventArgs e)
    {
        if (e.ChangeType != WatcherChangeTypes.Changed)
        {
            return;
        }
    }
}