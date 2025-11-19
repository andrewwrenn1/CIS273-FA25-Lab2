namespace MusicPlaylist;

public class MusicPlayer
{
    private Queue<Song> upNext;
    //private Queue<Song> history;
    private Stack<Song> history;

    private Random random = new Random();

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
        Rotate(upNext.Count-1);

        return previousSong;
    }

    private void Rotate(int n)
    {
        if (upNext.Count <= 1)
        {
            return;
        }

        if (n < 0)
        {
            for (int i = 0; i < n; i++)
            {
                Prev();
            }
        }

        int r = n % upNext.Count;

        for (int i = 0; i < r; i++)
        {
            upNext.Enqueue(upNext.Dequeue());
        }
    }

    public Song Shuffle()
    {
        // get random int in range
        int randomIndex = random.Next(upNext.Count);

        // remove the randomIndex-th item from the upNext queue
        Rotate(randomIndex);
        var song = upNext.Dequeue();
        history.Push(song);

        Rotate(upNext.Count - randomIndex);

        return song;
    }
    
}
