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

        /// <summary>
        /// Adds a prayer to the appropriate collection depending on its properties.
        /// </summary>
        public void AddPrayer(Prayer prayer)
        {
            if (prayer == null) return;

            if (prayer.IsAnswered)
            {
                AnsweredPrayers.Add(prayer);
            }
            else if (prayer.IsDaily)
            {
                DailyPrayers.Add(prayer);
            }
            else
            {
                nonDailyPrayers.Enqueue(prayer);
            }
        }

        /// <summary>
        /// Marks a prayer as answered and moves it to the AnsweredPrayers list.
        /// </summary>
        public void AnswerPrayer(int id)
        {
            // Check Daily prayers first
            var prayerToRemove = DailyPrayers.Find(p => p.ID == id);
            if (prayerToRemove != null)
            {
                prayerToRemove.IsAnswered = true;
                DailyPrayers.Remove(prayerToRemove);
                AnsweredPrayers.Add(prayerToRemove);
                return;
            }

            // Then check Non-daily prayers
            int count = nonDailyPrayers.Count;
            for (int i = 0; i < count; i++)
            {
                var p = nonDailyPrayers.Dequeue();
                if (p.ID == id)
                {
                    p.IsAnswered = true;
                    AnsweredPrayers.Add(p);
                }
                else
                {
                    nonDailyPrayers.Enqueue(p);
                }
            }
        }

        /// <summary>
        /// Moves a prayer to the DailyPrayers list.
        /// </summary>
        public void MoveToDaily(int id)
        {
            // Check in non-daily queue
            int count = nonDailyPrayers.Count;
            for (int i = 0; i < count; i++)
            {
                var p = nonDailyPrayers.Dequeue();
                if (p.ID == id && !p.IsAnswered)
                {
                    p.IsDaily = true;
                    DailyPrayers.Add(p);
                }
                else
                {
                    nonDailyPrayers.Enqueue(p);
                }
            }
        }

        /// <summary>
        /// Moves a prayer to the Non-daily queue.
        /// </summary>
        public void MoveToNonDaily(int id)
        {
            // Check in daily list
            var prayer = DailyPrayers.Find(p => p.ID == id);
            if (prayer != null && !prayer.IsAnswered)
            {
                prayer.IsDaily = false;
                DailyPrayers.Remove(prayer);
                nonDailyPrayers.Enqueue(prayer);
            }
        }

        /// <summary>
        /// Selects numPrayers unanswered prayers according to the rules:
        /// - All daily prayers first
        /// - Then least recently prayed non-daily prayers (up to numPrayers)
        /// - Moves used non-daily prayers to the back of the queue
        /// - Updates LastPrayed
        /// </summary>
        public List<Prayer> GetPrayers(int numPrayers)
        {
            List<Prayer> prayersForToday = new List<Prayer>();
            DateTime now = DateTime.Now;

            // 1. Select all daily prayers (unanswered)
            var daily = DailyPrayers.Where(p => !p.IsAnswered).ToList();
            prayersForToday.AddRange(daily);

            // If we already reached/exceeded numPrayers, just return those
            if (prayersForToday.Count >= numPrayers)
            {
                foreach (var p in prayersForToday)
                    p.LastPrayed = now;
                return prayersForToday;
            }

            // 2. Calculate how many more we need
            int remaining = numPrayers - prayersForToday.Count;

            // 3. Select least recently prayed non-daily prayers
            var nonDailyList = nonDailyPrayers.Where(p => !p.IsAnswered)
                                              .OrderBy(p => p.LastPrayed)
                                              .Take(remaining)
                                              .ToList();

            prayersForToday.AddRange(nonDailyList);

            // 4. Update LastPrayed and move non-dailies to back of queue
            foreach (var p in prayersForToday)
            {
                p.LastPrayed = now;
            }

            // Rebuild queue to move the selected non-daily prayers to back
            var queueList = nonDailyPrayers.ToList();
            nonDailyPrayers.Clear();

            // Enqueue unselected prayers first
            foreach (var p in queueList)
            {
                if (!nonDailyList.Contains(p))
                    nonDailyPrayers.Enqueue(p);
            }

            // Then enqueue selected ones (rotating to back)
            foreach (var p in nonDailyList)
            {
                nonDailyPrayers.Enqueue(p);
            }

            return prayersForToday;
        }
    }
}
