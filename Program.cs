// See https://aka.ms/new-console-template for more information

using System.Diagnostics;

while (true)
{
    var processes = Process.GetProcessesByName("vlc");
    if (processes != null && processes.Length > 0)
    {
        string songName = processes.First().MainWindowTitle;
        songName = songName.Replace(" - VLC media player", "");

        string[] splits = songName.Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries);
        if (splits.Length == 2)
        {
            File.WriteAllText("Artist.txt", splits[0]);
            File.WriteAllText("Song.txt", splits[1]);
        }
    }

    await Task.Delay(1000);
}