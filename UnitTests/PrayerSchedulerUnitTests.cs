using PrayerScheduler;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;

namespace UnitTests
{
    [TestClass]
    public class PrayerSchedulerUnitTests
	{

        [TestMethod]
        public void TestGetAndLastPrayed()
        {
            PrayerScheduler.PrayerScheduler prayerScheduler = new();

            prayerScheduler.AddPrayer(new Prayer() { ID = 1, Text = "test1", IsDaily = true, IsAnswered = false, Category = "Names of God", Scripture = "John 3:16" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 6, Text = "test2", IsDaily = false, IsAnswered = false, Category = "Names of God", Scripture = "1 John 3:1", LastPrayed = new DateTime(10 / 10 / 2021) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 29, Text = "test3", IsDaily = true, IsAnswered = false, Category = "Biblical Prayers", Scripture = "Psalm 23:1" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 4, Text = "test4", IsDaily = false, IsAnswered = false, Category = "Promises", Scripture = "Jeremiah 29:11", LastPrayed = new DateTime(12 / 21 / 2021) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 5, Text = "test5", IsDaily = true, IsAnswered = false, Category = "God Is", Scripture = "Exodus 3:14" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 3, Text = "test6", IsDaily = false, IsAnswered = false, Category = "In Christ", Scripture = "2 Corinthians 5:17", LastPrayed = new DateTime(01 / 12 / 2022) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 7, Text = "test7", IsDaily = true, IsAnswered = false, Category = "Petition", Scripture = "Philippians 4:6-7" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 8, Text = "test8", IsDaily = false, IsAnswered = false, Category = "Names of God", Scripture = "Psalm 46:1", LastPrayed = new DateTime(03 / 30 / 2022) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 10, Text = "test9", IsDaily = true, IsAnswered = false, Category = "Biblical Prayers", Scripture = "Matthew 6:9-13" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 9, Text = "test10", IsDaily = true, IsAnswered = false, Category = "Promises", Scripture = "Romans 8:28" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 18, Text = "test18", IsDaily = false, IsAnswered = false, Category = "In Christ", Scripture = "Romans 12:2", LastPrayed = new DateTime(06 / 30 / 2023) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 19, Text = "test19", IsDaily = false, IsAnswered = false, Category = "Petition", Scripture = "Matthew 7:7-8", LastPrayed = new DateTime(07 / 01 / 2023) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 20, Text = "test20", IsDaily = false, IsAnswered = false, Category = "Names of God", Scripture = "Psalm 27:1", LastPrayed = new DateTime(07 / 11 / 2023) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 21, Text = "test21", IsDaily = false, IsAnswered = false, Category = "Biblical Prayers", Scripture = "Philippians 4:13", LastPrayed = new DateTime(07 / 12 / 2023) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 22, Text = "test22", IsDaily = false, IsAnswered = false, Category = "Promises", Scripture = "Romans 15:13", LastPrayed = new DateTime(07 / 21 / 2023) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 23, Text = "test23", IsDaily = false, IsAnswered = false, Category = "God Is", Scripture = "Psalm 103:8", LastPrayed = new DateTime(08 / 16 / 2023) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 24, Text = "test24", IsDaily = false, IsAnswered = false, Category = "In Christ", Scripture = "Colossians 3:17", LastPrayed = new DateTime(08 / 24 / 2023) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 25, Text = "test25", IsDaily = false, IsAnswered = false, Category = "Petition", Scripture = "Philippians 4:19", LastPrayed = new DateTime(08 / 31 / 2023) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 26, Text = "test26", IsDaily = false, IsAnswered = false, Category = "Names of God", Scripture = "Proverbs 3:5-6", LastPrayed = new DateTime(09 / 07 / 2023) });

            Assert.AreEqual(new DateTime(10 / 10 / 2021), prayerScheduler.NonDailyPrayers[0].LastPrayed);
            Assert.AreEqual(new DateTime(01 / 12 / 2022), prayerScheduler.NonDailyPrayers[2].LastPrayed);
            Assert.AreEqual(new DateTime(03 / 30 / 2022), prayerScheduler.NonDailyPrayers[3].LastPrayed);
            Assert.AreEqual(new DateTime(07 / 21 / 2023), prayerScheduler.NonDailyPrayers[8].LastPrayed);

            List<Prayer> prayer1 = prayerScheduler.GetPrayers(9);
            Assert.AreNotEqual(new DateTime(10 / 10 / 2021), prayer1[6].LastPrayed);
            Assert.AreNotEqual(new DateTime(01 / 12 / 2022), prayer1[8].LastPrayed);
            Assert.AreEqual(new DateTime(03 / 30 / 2022), prayerScheduler.NonDailyPrayers[3].LastPrayed);
            Assert.AreEqual(new DateTime(06 / 30 / 2023), prayerScheduler.NonDailyPrayers[4].LastPrayed);


        }

        [TestMethod]
        public void TestAddSame()
        {
            PrayerScheduler.PrayerScheduler prayerScheduler = new();

            prayerScheduler.AddPrayer(new Prayer() { ID = 1, Text = "test1", IsDaily = true, IsAnswered = false, Category = "Names of God", Scripture = "John 3:16" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 2, Text = "test2", IsDaily = false, IsAnswered = false, Category = "Names of God", Scripture = "1 John 3:1" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 3, Text = "test3", IsDaily = true, IsAnswered = true, Category = "Biblical Prayers", Scripture = "Psalm 23:1" });

            Assert.AreEqual(1, prayerScheduler.NumDailyPrayers);
            Assert.AreEqual(1, prayerScheduler.NumNonDailyPrayers);
            Assert.ThrowsException<DuplicateIDException>(() =>
            {
                prayerScheduler.AddPrayer(new Prayer() { ID = 1, Text = "test40", IsDaily = false, IsAnswered = true, Category = "Name of God", Scripture = "John 3:15" });
            });
            
            Assert.AreEqual(1, prayerScheduler.NumDailyPrayers);
        }

        [TestMethod]
        public void TestAdd()
        {
            PrayerScheduler.PrayerScheduler prayerScheduler = new();

            prayerScheduler.AddPrayer(new Prayer() { ID = 1, Text = "test1", IsDaily = true, IsAnswered = true, Category = "Names of God", Scripture = "John 3:16" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 2, Text = "test2", IsDaily = false, IsAnswered = false, Category = "Names of God", Scripture = "1 John 3:1" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 3, Text = "test3", IsDaily = true, IsAnswered = false, Category = "Biblical Prayers", Scripture = "Psalm 23:1" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 4, Text = "test4", IsDaily = false, IsAnswered = false, Category = "Promises", Scripture = "Jeremiah 29:11" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 5, Text = "test5", IsDaily = true, IsAnswered = false, Category = "God Is", Scripture = "Exodus 3:14" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 6, Text = "test6", IsDaily = false, IsAnswered = false, Category = "In Christ", Scripture = "2 Corinthians 5:17" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 7, Text = "test7", IsDaily = true, IsAnswered = false, Category = "Petition", Scripture = "Philippians 4:6-7" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 8, Text = "test8", IsDaily = false, IsAnswered = false, Category = "Names of God", Scripture = "Psalm 46:1" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 9, Text = "test9", IsDaily = true, IsAnswered = false, Category = "Biblical Prayers", Scripture = "Matthew 6:9-13" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 10, Text = "test10", IsDaily = false, IsAnswered = false, Category = "Promises", Scripture = "Romans 8:28" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 11, Text = "test11", IsDaily = true, IsAnswered = false, Category = "God Is", Scripture = "Psalm 139:7-10" });


            Assert.AreEqual(5, prayerScheduler.NumDailyPrayers);
            Assert.AreEqual(5, prayerScheduler.NumNonDailyPrayers);

            prayerScheduler.AddPrayer(new Prayer() { ID = 12, Text = "test12", IsDaily = false, IsAnswered = false, Category = "In Christ", Scripture = "Ephesians 2:8-9" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 13, Text = "test13", IsDaily = true, IsAnswered = false, Category = "Petition", Scripture = "James 5:16" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 14, Text = "test14", IsDaily = false, IsAnswered = false, Category = "Names of God", Scripture = "Psalm 145:18" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 15, Text = "test15", IsDaily = true, IsAnswered = false, Category = "Biblical Prayers", Scripture = "1 Thessalonians 5:16-18" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 16, Text = "test16", IsDaily = false, IsAnswered = false, Category = "Promises", Scripture = "Isaiah 41:10" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 17, Text = "test17", IsDaily = true, IsAnswered = true, Category = "God Is", Scripture = "John 14:6" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 18, Text = "test18", IsDaily = false, IsAnswered = false, Category = "In Christ", Scripture = "Romans 12:2" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 19, Text = "test19", IsDaily = true, IsAnswered = false, Category = "Petition", Scripture = "Matthew 7:7-8" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 20, Text = "test20", IsDaily = false, IsAnswered = false, Category = "Names of God", Scripture = "Psalm 27:1" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 21, Text = "test21", IsDaily = true, IsAnswered = false, Category = "Biblical Prayers", Scripture = "Philippians 4:13" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 22, Text = "test22", IsDaily = false, IsAnswered = false, Category = "Promises", Scripture = "Romans 15:13" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 23, Text = "test23", IsDaily = true, IsAnswered = false, Category = "God Is", Scripture = "Psalm 103:8" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 24, Text = "test24", IsDaily = false, IsAnswered = false, Category = "In Christ", Scripture = "Colossians 3:17" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 25, Text = "test25", IsDaily = true, IsAnswered = false, Category = "Petition", Scripture = "Philippians 4:19" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 26, Text = "test26", IsDaily = false, IsAnswered = false, Category = "Names of God", Scripture = "Proverbs 3:5-6" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 27, Text = "test27", IsDaily = true, IsAnswered = false, Category = "Biblical Prayers", Scripture = "Psalm 19:14" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 28, Text = "test28", IsDaily = false, IsAnswered = false, Category = "Promises", Scripture = "Jeremiah 33:3" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 29, Text = "test29", IsDaily = true, IsAnswered = false, Category = "God Is", Scripture = "Revelation 1:8" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 30, Text = "test30", IsDaily = false, IsAnswered = true, Category = "In Christ", Scripture = "Galatians 2:20" });

            Assert.AreEqual(13, prayerScheduler.NumDailyPrayers);
            Assert.AreEqual(14, prayerScheduler.NumNonDailyPrayers);
            Assert.AreEqual(3, prayerScheduler.AnsweredPrayers.Count);
        }


        [TestMethod]
        public void TestGetPrayersLess()
        {
            PrayerScheduler.PrayerScheduler prayerScheduler = new();

            prayerScheduler.AddPrayer(new Prayer() { ID = 1, Text = "test1", IsDaily = true, IsAnswered = true, Category = "Names of God", Scripture = "John 3:16" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 6, Text = "test2", IsDaily = false, IsAnswered = true, Category = "Names of God", Scripture = "1 John 3:1", LastPrayed = new DateTime(10 / 10 / 2021) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 29, Text = "test3", IsDaily = true, IsAnswered = false, Category = "Biblical Prayers", Scripture = "Psalm 23:1" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 4, Text = "test4", IsDaily = false, IsAnswered = false, Category = "Promises", Scripture = "Jeremiah 29:11", LastPrayed = new DateTime(12 / 21 / 2021) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 5, Text = "test5", IsDaily = true, IsAnswered = false, Category = "God Is", Scripture = "Exodus 3:14" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 3, Text = "test6", IsDaily = false, IsAnswered = false, Category = "In Christ", Scripture = "2 Corinthians 5:17", LastPrayed = new DateTime(01 / 12 / 2022) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 7, Text = "test7", IsDaily = true, IsAnswered = false, Category = "Petition", Scripture = "Philippians 4:6-7"});
            prayerScheduler.AddPrayer(new Prayer() { ID = 8, Text = "test8", IsDaily = false, IsAnswered = false, Category = "Names of God", Scripture = "Psalm 46:1", LastPrayed = new DateTime(03 / 30 / 2022) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 10, Text = "test9", IsDaily = true, IsAnswered = false, Category = "Biblical Prayers", Scripture = "Matthew 6:9-13" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 9, Text = "test10", IsDaily = true, IsAnswered = false, Category = "Promises", Scripture = "Romans 8:28" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 12, Text = "test12", IsDaily = false, IsAnswered = false, Category = "In Christ", Scripture = "Ephesians 2:8-9", LastPrayed = new DateTime(05 / 21 / 2022) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 13, Text = "test13", IsDaily = false, IsAnswered = false, Category = "Petition", Scripture = "James 5:16", LastPrayed = new DateTime(05 / 25 / 2022) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 14, Text = "test14", IsDaily = false, IsAnswered = false, Category = "Names of God", Scripture = "Psalm 145:18", LastPrayed = new DateTime(05 / 31 / 2022) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 15, Text = "test15", IsDaily = true, IsAnswered = false, Category = "Biblical Prayers", Scripture = "1 Thessalonians 5:16-18" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 16, Text = "test16", IsDaily = false, IsAnswered = false, Category = "Promises", Scripture = "Isaiah 41:10", LastPrayed = new DateTime(06 / 21 / 2023) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 17, Text = "test17", IsDaily = true, IsAnswered = false, Category = "God Is", Scripture = "John 14:6" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 18, Text = "test18", IsDaily = false, IsAnswered = false, Category = "In Christ", Scripture = "Romans 12:2", LastPrayed = new DateTime(06 / 30 / 2023) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 19, Text = "test19", IsDaily = false, IsAnswered = false, Category = "Petition", Scripture = "Matthew 7:7-8", LastPrayed = new DateTime(07 / 01 / 2023) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 20, Text = "test20", IsDaily = false, IsAnswered = false, Category = "Names of God", Scripture = "Psalm 27:1", LastPrayed = new DateTime(07 / 11 / 2023) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 21, Text = "test21", IsDaily = false, IsAnswered = false, Category = "Biblical Prayers", Scripture = "Philippians 4:13", LastPrayed = new DateTime(07 / 12 / 2023) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 22, Text = "test22", IsDaily = false, IsAnswered = false, Category = "Promises", Scripture = "Romans 15:13", LastPrayed = new DateTime(07 / 21 / 2023) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 23, Text = "test23", IsDaily = false, IsAnswered = false, Category = "God Is", Scripture = "Psalm 103:8", LastPrayed = new DateTime(08 / 16 / 2023) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 24, Text = "test24", IsDaily = false, IsAnswered = false, Category = "In Christ", Scripture = "Colossians 3:17", LastPrayed = new DateTime(08 / 24 / 2023) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 25, Text = "test25", IsDaily = false, IsAnswered = false, Category = "Petition", Scripture = "Philippians 4:19", LastPrayed = new DateTime(08 / 31 / 2023) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 26, Text = "test26", IsDaily = false, IsAnswered = false, Category = "Names of God", Scripture = "Proverbs 3:5-6", LastPrayed = new DateTime(09 / 07 / 2023) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 27, Text = "test27", IsDaily = true, IsAnswered = false, Category = "Biblical Prayers", Scripture = "Psalm 19:14" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 28, Text = "test28", IsDaily = false, IsAnswered = false, Category = "Promises", Scripture = "Jeremiah 33:3", LastPrayed = new DateTime(09 / 29 / 2023) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 2, Text = "test29", IsDaily = true, IsAnswered = false, Category = "God Is", Scripture = "Revelation 1:8" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 30, Text = "test30", IsDaily = false, IsAnswered = false, Category = "In Christ", Scripture = "Galatians 2:20", LastPrayed = new DateTime(10 / 30 / 2023) });


            Assert.AreEqual(9, prayerScheduler.NumDailyPrayers);
            Assert.AreEqual(18, prayerScheduler.NumNonDailyPrayers);
            Assert.AreEqual(2, prayerScheduler.AnsweredPrayers.Count);

            List<Prayer> prayer1 = prayerScheduler.GetPrayers(7);

            Assert.AreEqual(9, prayer1.Count());
            string ids = "";
            for(int i = 0; i < prayer1.Count(); i++)
            {
            ids += prayer1[i].ID;
                
                if (i != prayer1.Count() - 1) { ids += ","; }

            }

            Assert.AreEqual("29,5,7,10,9,15,17,27,2", ids);

        }


        [TestMethod]
        public void TestGetPrayers1()
        {
            PrayerScheduler.PrayerScheduler prayerScheduler = new();

            prayerScheduler.AddPrayer(new Prayer() { ID = 1, Text = "test1", IsDaily = true, IsAnswered = true, Category = "Names of God", Scripture = "John 3:16" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 6, Text = "test2", IsDaily = false, IsAnswered = true, Category = "Names of God", Scripture = "1 John 3:1", LastPrayed = new DateTime(10 / 10 / 2021) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 2, Text = "test3", IsDaily = true, IsAnswered = false, Category = "Biblical Prayers", Scripture = "Psalm 23:1" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 4, Text = "test4", IsDaily = false, IsAnswered = false, Category = "Promises", Scripture = "Jeremiah 29:11", LastPrayed = new DateTime(12 / 21 / 2021) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 5, Text = "test5", IsDaily = true, IsAnswered = false, Category = "God Is", Scripture = "Exodus 3:14" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 3, Text = "test6", IsDaily = false, IsAnswered = false, Category = "In Christ", Scripture = "2 Corinthians 5:17", LastPrayed = new DateTime(01 / 12 / 2022) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 7, Text = "test7", IsDaily = true, IsAnswered = false, Category = "Petition", Scripture = "Philippians 4:6-7" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 8, Text = "test8", IsDaily = false, IsAnswered = true, Category = "Names of God", Scripture = "Psalm 46:1", LastPrayed = new DateTime(03 / 30 / 2022) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 10, Text = "test9", IsDaily = true, IsAnswered = false, Category = "Biblical Prayers", Scripture = "Matthew 6:9-13" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 9, Text = "test10", IsDaily = true, IsAnswered = false, Category = "Promises", Scripture = "Romans 8:28" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 12, Text = "test12", IsDaily = false, IsAnswered = false, Category = "In Christ", Scripture = "Ephesians 2:8-9", LastPrayed = new DateTime(05 / 21 / 2022) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 13, Text = "test13", IsDaily = false, IsAnswered = false, Category = "Petition", Scripture = "James 5:16", LastPrayed = new DateTime(05 / 25 / 2022) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 14, Text = "test14", IsDaily = false, IsAnswered = false, Category = "Names of God", Scripture = "Psalm 145:18", LastPrayed = new DateTime(05 / 31 / 2022) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 15, Text = "test15", IsDaily = true, IsAnswered = false, Category = "Biblical Prayers", Scripture = "1 Thessalonians 5:16-18" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 16, Text = "test16", IsDaily = false, IsAnswered = false, Category = "Promises", Scripture = "Isaiah 41:10", LastPrayed = new DateTime(06 / 21 / 2023) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 17, Text = "test17", IsDaily = true, IsAnswered = false, Category = "God Is", Scripture = "John 14:6" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 18, Text = "test18", IsDaily = false, IsAnswered = false, Category = "In Christ", Scripture = "Romans 12:2", LastPrayed = new DateTime(06 / 30 / 2023) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 19, Text = "test19", IsDaily = false, IsAnswered = false, Category = "Petition", Scripture = "Matthew 7:7-8", LastPrayed = new DateTime(07 / 01 / 2023) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 20, Text = "test20", IsDaily = false, IsAnswered = false, Category = "Names of God", Scripture = "Psalm 27:1", LastPrayed = new DateTime(07 / 11 / 2023) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 21, Text = "test21", IsDaily = false, IsAnswered = false, Category = "Biblical Prayers", Scripture = "Philippians 4:13", LastPrayed = new DateTime(07 / 12 / 2023) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 22, Text = "test22", IsDaily = false, IsAnswered = false, Category = "Promises", Scripture = "Romans 15:13", LastPrayed = new DateTime(07 / 21 / 2023) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 23, Text = "test23", IsDaily = false, IsAnswered = false, Category = "God Is", Scripture = "Psalm 103:8", LastPrayed = new DateTime(08 / 16 / 2023) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 24, Text = "test24", IsDaily = false, IsAnswered = false, Category = "In Christ", Scripture = "Colossians 3:17", LastPrayed = new DateTime(08 / 24 / 2023) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 25, Text = "test25", IsDaily = false, IsAnswered = false, Category = "Petition", Scripture = "Philippians 4:19", LastPrayed = new DateTime(08 / 31 / 2023) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 26, Text = "test26", IsDaily = false, IsAnswered = false, Category = "Names of God", Scripture = "Proverbs 3:5-6", LastPrayed = new DateTime(09 / 07 / 2023) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 27, Text = "test27", IsDaily = true, IsAnswered = false, Category = "Biblical Prayers", Scripture = "Psalm 19:14" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 28, Text = "test28", IsDaily = false, IsAnswered = false, Category = "Promises", Scripture = "Jeremiah 33:3", LastPrayed = new DateTime(09 / 29 / 2023) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 29, Text = "test29", IsDaily = true, IsAnswered = false, Category = "God Is", Scripture = "Revelation 1:8" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 30, Text = "test30", IsDaily = false, IsAnswered = false, Category = "In Christ", Scripture = "Galatians 2:20", LastPrayed = new DateTime(10 / 30 / 2023) });


            Assert.AreEqual(9, prayerScheduler.NumDailyPrayers);
            Assert.AreEqual(17, prayerScheduler.NumNonDailyPrayers);
            Assert.AreEqual(3, prayerScheduler.AnsweredPrayers.Count);

            List<Prayer> prayer1 = prayerScheduler.GetPrayers(7);

            Assert.AreEqual(9, prayer1.Count());
            string ids = "";
            for (int i = 0; i < prayer1.Count(); i++)
            {
                ids += prayer1[i].ID;

                if (i != prayer1.Count() - 1) { ids += ","; }

            }

            Assert.AreEqual("2,5,7,10,9,15,17,27,29", ids);



            List<Prayer> prayer2 = prayerScheduler.GetPrayers(13);
            Assert.AreEqual(13, prayer2.Count());

            string ids2 = "";
            for (int i = 0; i < prayer2.Count(); i++)
            {
                ids2 += prayer2[i].ID;

                if (i != prayer2.Count() - 1) { ids2 += ","; }

            }

            Assert.AreEqual("2,5,7,10,9,15,17,27,29,4,3,12,13", ids2);
        }

        [TestMethod]
        public void TestGetPrayersMultiple()
        {
            PrayerScheduler.PrayerScheduler prayerScheduler = new();

            prayerScheduler.AddPrayer(new Prayer() { ID = 1, Text = "test1", IsDaily = true, IsAnswered = true, Category = "Names of God", Scripture = "John 3:16" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 6, Text = "test2", IsDaily = false, IsAnswered = true, Category = "Names of God", Scripture = "1 John 3:1", LastPrayed = new DateTime(10 / 10 / 2021) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 2, Text = "test3", IsDaily = true, IsAnswered = false, Category = "Biblical Prayers", Scripture = "Psalm 23:1" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 4, Text = "test4", IsDaily = false, IsAnswered = false, Category = "Promises", Scripture = "Jeremiah 29:11", LastPrayed = new DateTime(12 / 21 / 2021) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 5, Text = "test5", IsDaily = true, IsAnswered = false, Category = "God Is", Scripture = "Exodus 3:14" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 3, Text = "test6", IsDaily = false, IsAnswered = false, Category = "In Christ", Scripture = "2 Corinthians 5:17", LastPrayed = new DateTime(01 / 12 / 2022) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 7, Text = "test7", IsDaily = true, IsAnswered = false, Category = "Petition", Scripture = "Philippians 4:6-7" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 8, Text = "test8", IsDaily = false, IsAnswered = false, Category = "Names of God", Scripture = "Psalm 46:1", LastPrayed = new DateTime(03 / 30 / 2022) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 10, Text = "test9", IsDaily = true, IsAnswered = false, Category = "Biblical Prayers", Scripture = "Matthew 6:9-13" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 9, Text = "test10", IsDaily = true, IsAnswered = false, Category = "Promises", Scripture = "Romans 8:28" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 12, Text = "test12", IsDaily = false, IsAnswered = false, Category = "In Christ", Scripture = "Ephesians 2:8-9", LastPrayed = new DateTime(05 / 21 / 2022) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 13, Text = "test13", IsDaily = false, IsAnswered = false, Category = "Petition", Scripture = "James 5:16", LastPrayed = new DateTime(05 / 25 / 2022) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 14, Text = "test14", IsDaily = false, IsAnswered = false, Category = "Names of God", Scripture = "Psalm 145:18", LastPrayed = new DateTime(05 / 31 / 2022) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 15, Text = "test15", IsDaily = true, IsAnswered = false, Category = "Biblical Prayers", Scripture = "1 Thessalonians 5:16-18" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 16, Text = "test16", IsDaily = false, IsAnswered = false, Category = "Promises", Scripture = "Isaiah 41:10", LastPrayed = new DateTime(06 / 21 / 2023) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 17, Text = "test17", IsDaily = true, IsAnswered = false, Category = "God Is", Scripture = "John 14:6" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 18, Text = "test18", IsDaily = false, IsAnswered = false, Category = "In Christ", Scripture = "Romans 12:2", LastPrayed = new DateTime(06 / 30 / 2023) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 19, Text = "test19", IsDaily = false, IsAnswered = false, Category = "Petition", Scripture = "Matthew 7:7-8", LastPrayed = new DateTime(07 / 01 / 2023) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 20, Text = "test20", IsDaily = false, IsAnswered = false, Category = "Names of God", Scripture = "Psalm 27:1", LastPrayed = new DateTime(07 / 11 / 2023) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 21, Text = "test21", IsDaily = false, IsAnswered = false, Category = "Biblical Prayers", Scripture = "Philippians 4:13", LastPrayed = new DateTime(07 / 12 / 2023) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 22, Text = "test22", IsDaily = false, IsAnswered = false, Category = "Promises", Scripture = "Romans 15:13", LastPrayed = new DateTime(07 / 21 / 2023) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 23, Text = "test23", IsDaily = false, IsAnswered = false, Category = "God Is", Scripture = "Psalm 103:8", LastPrayed = new DateTime(08 / 16 / 2023) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 24, Text = "test24", IsDaily = false, IsAnswered = false, Category = "In Christ", Scripture = "Colossians 3:17", LastPrayed = new DateTime(08 / 24 / 2023) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 25, Text = "test25", IsDaily = false, IsAnswered = false, Category = "Petition", Scripture = "Philippians 4:19", LastPrayed = new DateTime(08 / 31 / 2023) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 26, Text = "test26", IsDaily = false, IsAnswered = false, Category = "Names of God", Scripture = "Proverbs 3:5-6", LastPrayed = new DateTime(09 / 07 / 2023) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 27, Text = "test27", IsDaily = true, IsAnswered = false, Category = "Biblical Prayers", Scripture = "Psalm 19:14" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 28, Text = "test28", IsDaily = false, IsAnswered = false, Category = "Promises", Scripture = "Jeremiah 33:3", LastPrayed = new DateTime(09 / 29 / 2023) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 29, Text = "test29", IsDaily = true, IsAnswered = false, Category = "God Is", Scripture = "Revelation 1:8" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 30, Text = "test30", IsDaily = false, IsAnswered = false, Category = "In Christ", Scripture = "Galatians 2:20", LastPrayed = new DateTime(10 / 30 / 2023) });


            Assert.AreEqual(9, prayerScheduler.NumDailyPrayers);
            Assert.AreEqual(18, prayerScheduler.NumNonDailyPrayers);
            Assert.AreEqual(2, prayerScheduler.AnsweredPrayers.Count);

            List<Prayer> prayer1 = prayerScheduler.GetPrayers(7);

            Assert.AreEqual(9, prayer1.Count());
            string ids = "";
            for (int i = 0; i < prayer1.Count(); i++)
            {
                ids += prayer1[i].ID;

                if (i != prayer1.Count() - 1) { ids += ","; }

            }

            Assert.AreEqual("2,5,7,10,9,15,17,27,29", ids);



            List<Prayer> prayer2 = prayerScheduler.GetPrayers(13);
            Assert.AreEqual(13, prayer2.Count());

            string ids2 = "";
            for (int i = 0; i < prayer2.Count(); i++)
            {
                ids2 += prayer2[i].ID;

                if (i != prayer2.Count() - 1) { ids2 += ","; }

            }

            Assert.AreEqual("2,5,7,10,9,15,17,27,29,4,3,8,12", ids2);

            List<Prayer> prayer3 = prayerScheduler.GetPrayers(20);
            Assert.AreEqual(20, prayer3.Count());

            string ids3 = "";
            for (int i = 0; i < prayer3.Count(); i++)
            {
                ids3 += prayer3[i].ID;

                if (i != prayer3.Count() - 1) { ids3 += ","; }

            }

            Assert.AreEqual("2,5,7,10,9,15,17,27,29,13,14,16,18,19,20,21,22,23,24,25", ids3);


            List<Prayer> prayer4 = prayerScheduler.GetPrayers(20);
            Assert.AreEqual(20, prayer4.Count());

            string ids4 = "";
            for (int i = 0; i < prayer4.Count(); i++)
            {
                ids4 += prayer4[i].ID;

                if (i != prayer4.Count() - 1) { ids4 += ","; }

            }

            Assert.AreEqual("2,5,7,10,9,15,17,27,29,26,28,30,4,3,8,12,13,14,16,18", ids4);
        }


        [TestMethod]
        public void TestGetPrayersAndAnswer()
        {
            PrayerScheduler.PrayerScheduler prayerScheduler = new();

            prayerScheduler.AddPrayer(new Prayer() { ID = 1, Text = "test1", IsDaily = true, IsAnswered = false, Category = "Names of God", Scripture = "John 3:16" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 6, Text = "test2", IsDaily = false, IsAnswered = false, Category = "Names of God", Scripture = "1 John 3:1", LastPrayed = new DateTime(10 / 10 / 2021) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 2, Text = "test3", IsDaily = true, IsAnswered = false, Category = "Biblical Prayers", Scripture = "Psalm 23:1" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 4, Text = "test4", IsDaily = false, IsAnswered = false, Category = "Promises", Scripture = "Jeremiah 29:11", LastPrayed = new DateTime(12 / 21 / 2021) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 5, Text = "test5", IsDaily = true, IsAnswered = false, Category = "God Is", Scripture = "Exodus 3:14" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 3, Text = "test6", IsDaily = false, IsAnswered = false, Category = "In Christ", Scripture = "2 Corinthians 5:17", LastPrayed = new DateTime(01 / 12 / 2022) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 7, Text = "test7", IsDaily = true, IsAnswered = false, Category = "Petition", Scripture = "Philippians 4:6-7" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 8, Text = "test8", IsDaily = false, IsAnswered = false, Category = "Names of God", Scripture = "Psalm 46:1", LastPrayed = new DateTime(03 / 30 / 2022) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 10, Text = "test9", IsDaily = true, IsAnswered = false, Category = "Biblical Prayers", Scripture = "Matthew 6:9-13" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 9, Text = "test10", IsDaily = true, IsAnswered = false, Category = "Promises", Scripture = "Romans 8:28" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 12, Text = "test12", IsDaily = false, IsAnswered = false, Category = "In Christ", Scripture = "Ephesians 2:8-9", LastPrayed = new DateTime(05 / 21 / 2022) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 13, Text = "test13", IsDaily = false, IsAnswered = false, Category = "Petition", Scripture = "James 5:16", LastPrayed = new DateTime(05 / 25 / 2022) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 14, Text = "test14", IsDaily = false, IsAnswered = false, Category = "Names of God", Scripture = "Psalm 145:18", LastPrayed = new DateTime(05 / 31 / 2022) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 15, Text = "test15", IsDaily = true, IsAnswered = false, Category = "Biblical Prayers", Scripture = "1 Thessalonians 5:16-18" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 16, Text = "test16", IsDaily = false, IsAnswered = false, Category = "Promises", Scripture = "Isaiah 41:10", LastPrayed = new DateTime(06 / 21 / 2023) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 17, Text = "test17", IsDaily = true, IsAnswered = false, Category = "God Is", Scripture = "John 14:6" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 18, Text = "test18", IsDaily = false, IsAnswered = false, Category = "In Christ", Scripture = "Romans 12:2", LastPrayed = new DateTime(06 / 30 / 2023) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 19, Text = "test19", IsDaily = false, IsAnswered = false, Category = "Petition", Scripture = "Matthew 7:7-8", LastPrayed = new DateTime(07 / 01 / 2023) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 20, Text = "test20", IsDaily = false, IsAnswered = false, Category = "Names of God", Scripture = "Psalm 27:1", LastPrayed = new DateTime(07 / 11 / 2023) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 21, Text = "test21", IsDaily = false, IsAnswered = false, Category = "Biblical Prayers", Scripture = "Philippians 4:13", LastPrayed = new DateTime(07 / 12 / 2023) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 22, Text = "test22", IsDaily = false, IsAnswered = false, Category = "Promises", Scripture = "Romans 15:13", LastPrayed = new DateTime(07 / 21 / 2023) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 23, Text = "test23", IsDaily = false, IsAnswered = false, Category = "God Is", Scripture = "Psalm 103:8", LastPrayed = new DateTime(08 / 16 / 2023) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 24, Text = "test24", IsDaily = false, IsAnswered = false, Category = "In Christ", Scripture = "Colossians 3:17", LastPrayed = new DateTime(08 / 24 / 2023) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 25, Text = "test25", IsDaily = false, IsAnswered = false, Category = "Petition", Scripture = "Philippians 4:19", LastPrayed = new DateTime(08 / 31 / 2023) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 26, Text = "test26", IsDaily = false, IsAnswered = false, Category = "Names of God", Scripture = "Proverbs 3:5-6", LastPrayed = new DateTime(09 / 07 / 2023) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 27, Text = "test27", IsDaily = true, IsAnswered = false, Category = "Biblical Prayers", Scripture = "Psalm 19:14" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 28, Text = "test28", IsDaily = false, IsAnswered = false, Category = "Promises", Scripture = "Jeremiah 33:3", LastPrayed = new DateTime(09 / 29 / 2023) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 29, Text = "test29", IsDaily = true, IsAnswered = false, Category = "God Is", Scripture = "Revelation 1:8" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 30, Text = "test30", IsDaily = false, IsAnswered = true, Category = "In Christ", Scripture = "Galatians 2:20", LastPrayed = new DateTime(10 / 30 / 2023) });


            Assert.AreEqual(10, prayerScheduler.NumDailyPrayers);
            Assert.AreEqual(18, prayerScheduler.NumNonDailyPrayers);
            Assert.AreEqual(1, prayerScheduler.AnsweredPrayers.Count);


            prayerScheduler.AnswerPrayer(5);
            Assert.AreEqual(9, prayerScheduler.NumDailyPrayers);
            Assert.AreEqual(2, prayerScheduler.AnsweredPrayers.Count);

            List<Prayer> prayer1 = prayerScheduler.GetPrayers(7);

            Assert.AreEqual(9, prayer1.Count());
            string ids = "";
            for (int i = 0; i < prayer1.Count(); i++)
            {
                ids += prayer1[i].ID;

                if (i != prayer1.Count() - 1) { ids += ","; }

            }

            Assert.AreEqual("1,2,7,10,9,15,17,27,29", ids);


            prayerScheduler.AnswerPrayer(6);
            Assert.AreEqual(17, prayerScheduler.NumNonDailyPrayers);
            Assert.AreEqual(3, prayerScheduler.AnsweredPrayers.Count);



            List<Prayer> prayer2 = prayerScheduler.GetPrayers(13);
            Assert.AreEqual(13, prayer2.Count());

            string ids2 = "";
            for (int i = 0; i < prayer2.Count(); i++)
            {
                ids2 += prayer2[i].ID;

                if (i != prayer2.Count() - 1) { ids2 += ","; }

            }

            Assert.AreEqual("1,2,7,10,9,15,17,27,29,4,3,8,12", ids2);


            prayerScheduler.AnswerPrayer(19);
            prayerScheduler.AnswerPrayer(21);
            prayerScheduler.AnswerPrayer(2);
            Assert.AreEqual(15, prayerScheduler.NumNonDailyPrayers);
            Assert.AreEqual(8, prayerScheduler.NumDailyPrayers);
            Assert.AreEqual(6, prayerScheduler.AnsweredPrayers.Count);

            List<Prayer> prayer3 = prayerScheduler.GetPrayers(20);
            Assert.AreEqual(20, prayer3.Count());


            string ids3 = "";
            for (int i = 0; i < prayer3.Count(); i++)
            {
                ids3 += prayer3[i].ID;

                if (i != prayer3.Count() - 1) { ids3 += ","; }

            }

            Assert.AreEqual("1,7,10,9,15,17,27,29,13,14,16,18,20,22,23,24,25,26,28,4", ids3);


            List<Prayer> prayer4 = prayerScheduler.GetPrayers(20);
            Assert.AreEqual(20, prayer4.Count());

            string ids4 = "";
            for (int i = 0; i < prayer4.Count(); i++)
            {
                ids4 += prayer4[i].ID;

                if (i != prayer4.Count() - 1) { ids4 += ","; }

            }

            Assert.AreEqual("1,7,10,9,15,17,27,29,3,8,12,13,14,16,18,20,22,23,24,25", ids4);
        }


        [TestMethod]
        public void TestAllTogether()
        {
            PrayerScheduler.PrayerScheduler prayerScheduler = new();

            prayerScheduler.AddPrayer(new Prayer() { ID = 1, Text = "test1", IsDaily = true, IsAnswered = true, Category = "Names of God", Scripture = "John 3:16" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 6, Text = "test2", IsDaily = false, IsAnswered = false, Category = "Names of God", Scripture = "1 John 3:1", LastPrayed = new DateTime(10 / 10 / 2021) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 2, Text = "test3", IsDaily = true, IsAnswered = false, Category = "Biblical Prayers", Scripture = "Psalm 23:1" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 4, Text = "test4", IsDaily = false, IsAnswered = false, Category = "Promises", Scripture = "Jeremiah 29:11", LastPrayed = new DateTime(12 / 21 / 2021) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 5, Text = "test5", IsDaily = true, IsAnswered = false, Category = "God Is", Scripture = "Exodus 3:14" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 3, Text = "test6", IsDaily = false, IsAnswered = false, Category = "In Christ", Scripture = "2 Corinthians 5:17", LastPrayed = new DateTime(01 / 12 / 2022) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 7, Text = "test7", IsDaily = true, IsAnswered = false, Category = "Petition", Scripture = "Philippians 4:6-7" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 8, Text = "test8", IsDaily = false, IsAnswered = false, Category = "Names of God", Scripture = "Psalm 46:1", LastPrayed = new DateTime(03 / 30 / 2022) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 10, Text = "test9", IsDaily = true, IsAnswered = false, Category = "Biblical Prayers", Scripture = "Matthew 6:9-13" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 9, Text = "test10", IsDaily = true, IsAnswered = false, Category = "Promises", Scripture = "Romans 8:28" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 12, Text = "test12", IsDaily = false, IsAnswered = false, Category = "In Christ", Scripture = "Ephesians 2:8-9", LastPrayed = new DateTime(05 / 21 / 2022) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 13, Text = "test13", IsDaily = false, IsAnswered = false, Category = "Petition", Scripture = "James 5:16", LastPrayed = new DateTime(05 / 25 / 2022) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 14, Text = "test14", IsDaily = false, IsAnswered = false, Category = "Names of God", Scripture = "Psalm 145:18", LastPrayed = new DateTime(05 / 31 / 2022) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 15, Text = "test15", IsDaily = true, IsAnswered = false, Category = "Biblical Prayers", Scripture = "1 Thessalonians 5:16-18" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 16, Text = "test16", IsDaily = false, IsAnswered = false, Category = "Promises", Scripture = "Isaiah 41:10", LastPrayed = new DateTime(06 / 21 / 2023) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 17, Text = "test17", IsDaily = true, IsAnswered = false, Category = "God Is", Scripture = "John 14:6" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 18, Text = "test18", IsDaily = false, IsAnswered = false, Category = "In Christ", Scripture = "Romans 12:2", LastPrayed = new DateTime(06 / 30 / 2023) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 19, Text = "test19", IsDaily = false, IsAnswered = false, Category = "Petition", Scripture = "Matthew 7:7-8", LastPrayed = new DateTime(07 / 01 / 2023) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 20, Text = "test20", IsDaily = false, IsAnswered = false, Category = "Names of God", Scripture = "Psalm 27:1", LastPrayed = new DateTime(07 / 11 / 2023) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 21, Text = "test21", IsDaily = false, IsAnswered = false, Category = "Biblical Prayers", Scripture = "Philippians 4:13", LastPrayed = new DateTime(07 / 12 / 2023) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 22, Text = "test22", IsDaily = false, IsAnswered = false, Category = "Promises", Scripture = "Romans 15:13", LastPrayed = new DateTime(07 / 21 / 2023) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 23, Text = "test23", IsDaily = false, IsAnswered = false, Category = "God Is", Scripture = "Psalm 103:8", LastPrayed = new DateTime(08 / 16 / 2023) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 24, Text = "test24", IsDaily = false, IsAnswered = false, Category = "In Christ", Scripture = "Colossians 3:17", LastPrayed = new DateTime(08 / 24 / 2023) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 25, Text = "test25", IsDaily = false, IsAnswered = false, Category = "Petition", Scripture = "Philippians 4:19", LastPrayed = new DateTime(08 / 31 / 2023) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 26, Text = "test26", IsDaily = false, IsAnswered = false, Category = "Names of God", Scripture = "Proverbs 3:5-6", LastPrayed = new DateTime(09 / 07 / 2023) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 27, Text = "test27", IsDaily = true, IsAnswered = false, Category = "Biblical Prayers", Scripture = "Psalm 19:14" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 28, Text = "test28", IsDaily = false, IsAnswered = false, Category = "Promises", Scripture = "Jeremiah 33:3", LastPrayed = new DateTime(09 / 29 / 2023) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 29, Text = "test29", IsDaily = true, IsAnswered = false, Category = "God Is", Scripture = "Revelation 1:8" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 30, Text = "test30", IsDaily = false, IsAnswered = true, Category = "In Christ", Scripture = "Galatians 2:20", LastPrayed = new DateTime(10 / 30 / 2023) });


            Assert.AreEqual(9, prayerScheduler.NumDailyPrayers);
            Assert.AreEqual(18, prayerScheduler.NumNonDailyPrayers);
            Assert.AreEqual(2, prayerScheduler.AnsweredPrayers.Count);


            prayerScheduler.AnswerPrayer(5);
            Assert.AreEqual(8, prayerScheduler.NumDailyPrayers);
            Assert.AreEqual(3, prayerScheduler.AnsweredPrayers.Count);

            List<Prayer> prayer1 = prayerScheduler.GetPrayers(7);

            Assert.AreEqual(8, prayer1.Count());
            string ids = "";
            for (int i = 0; i < prayer1.Count(); i++)
            {
                ids += prayer1[i].ID;

                if (i != prayer1.Count() - 1) { ids += ","; }

            }

            Assert.AreEqual("2,7,10,9,15,17,27,29", ids);


            prayerScheduler.AnswerPrayer(6);
            Assert.AreEqual(17, prayerScheduler.NumNonDailyPrayers);
            Assert.AreEqual(4, prayerScheduler.AnsweredPrayers.Count);



            List<Prayer> prayer2 = prayerScheduler.GetPrayers(13);
            Assert.AreEqual(13, prayer2.Count());

            string ids2 = "";
            for (int i = 0; i < prayer2.Count(); i++)
            {
                ids2 += prayer2[i].ID;

                if (i != prayer2.Count() - 1) { ids2 += ","; }

            }

            Assert.AreEqual("2,7,10,9,15,17,27,29,4,3,8,12,13", ids2);


            prayerScheduler.AnswerPrayer(19);
            prayerScheduler.AnswerPrayer(21);
            prayerScheduler.AnswerPrayer(2);
            Assert.AreEqual(15, prayerScheduler.NumNonDailyPrayers);
            Assert.AreEqual(7, prayerScheduler.NumDailyPrayers);
            Assert.AreEqual(7, prayerScheduler.AnsweredPrayers.Count);

            List<Prayer> prayer3 = prayerScheduler.GetPrayers(20);
            Assert.AreEqual(20, prayer3.Count());


            string ids3 = "";
            for (int i = 0; i < prayer3.Count(); i++)
            {
                ids3 += prayer3[i].ID;

                if (i != prayer3.Count() - 1) { ids3 += ","; }

            }

            Assert.AreEqual("7,10,9,15,17,27,29,14,16,18,20,22,23,24,25,26,28,4,3,8", ids3);

            prayerScheduler.AddPrayer(new Prayer() { ID = 31, Text = "test16", IsDaily = false, IsAnswered = true, Category = "Promises", Scripture = "Isaiah 41:10", LastPrayed = new DateTime(06 / 21 / 2023) });
            prayerScheduler.AddPrayer(new Prayer() { ID = 32, Text = "test17", IsDaily = true, IsAnswered = false, Category = "God Is", Scripture = "John 14:6" });
            prayerScheduler.AddPrayer(new Prayer() { ID = 33, Text = "test18", IsDaily = false, IsAnswered = false, Category = "In Christ", Scripture = "Romans 12:2", LastPrayed = new DateTime(06 / 30 / 2023) });


            List<Prayer> prayer4 = prayerScheduler.GetPrayers(25);
            Assert.AreEqual(25, prayer4.Count());

            string ids4 = "";
            for (int i = 0; i < prayer4.Count(); i++)
            {
                ids4 += prayer4[i].ID;

                if (i != prayer4.Count() - 1) { ids4 += ","; }

            }

            Assert.AreEqual("7,10,9,15,17,27,29,32,12,13,14,16,18,20,22,23,24,25,26,28,4,3,8,33,12", ids4);
            Assert.AreEqual(16, prayerScheduler.NumNonDailyPrayers);
            Assert.AreEqual(8, prayerScheduler.NumDailyPrayers);
            Assert.AreEqual(8, prayerScheduler.AnsweredPrayers.Count);
        }
    }





    }

