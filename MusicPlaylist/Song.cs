namespace MusicPlaylist;

public class Song
{
    public string Title { get; set; }
    public string Artist { get; set; }
    public int DurationSec { get; set; }
    public DateTime ReleaseDate { get; set; }

    public override string ToString()
    {
        return $"{Title} - {Artist} ({DurationSec}) | {ReleaseDate.Year}";
    }
}