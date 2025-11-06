namespace MusicPlaylist;

public class MusicPlayer
{
    private Queue<Song> upNext;
    //private Queue<Song> history;
    private Stack<Song> history;

    public int Count => upNext.Count + history.Count;
    public int HistoryCount => history.Count;
    public Song NextSong => upNext.Peek();

    public MusicPlayer()
    {
        upNext = new Queue<Song>();
        history = new Stack<Song>();
    }

    public void Add(Song song) => upNext.Enqueue(song);

    public Song Play()
    {
        Song currentSong = upNext.Dequeue();
        history.Push(currentSong);
        return currentSong;
    }

    public Song Next()
    {
        return Play();
    }

    public Song Prev()
    {
        var previousSong = history.Pop();
        // add to front of upNext queue
        upNext.Enqueue(previousSong);
        Rotate(n);

        return previousSong;
    }
    
    private void Rotate(int n)
    {
        if (upNext.Count <= 1)
        {
            return;
        }
        
        for(int i=0; i < n; i++)
        {
            upNext.Enqueue(upNext.Dequeue());
        }
    }


}