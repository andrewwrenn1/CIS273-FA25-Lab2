namespace PrayerScheduler
{
    public class PrayerScheduler
    {
        public int NumDailyPrayers => DailyPrayers.Count;
        public int NumNonDailyPrayers => nonDailyPrayers.Count;

        public List<Prayer> DailyPrayers { get; } = new();

        private Queue<Prayer> nonDailyPrayers = new();

        public List<Prayer> NonDailyPrayers
        {
            get { return nonDailyPrayers.ToList(); }
        }

        public List<Prayer> AnsweredPrayers { get; } = new();

        public PrayerScheduler()
        {
        }

    public void AddPrayer(Prayer prayer)
    {
        // if answered
        // add it to answered

        //if unanswered
        // if daily, add to dailys


    }

    public void AnswerPrayer(int id)
    {

    
    }

    public List<Prayer> GetPrayers(int numPrayers)
    {
        List<Prayer> prayers = new List<Prayer>();


        return prayers;
    }

}


