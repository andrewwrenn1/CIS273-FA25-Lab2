using System;
namespace PrayerScheduler
{
	public class Prayer
	{
		public int ID { get; set; }

		public string Category { get; set; } = "";
		public string Scripture { get; set; } = "";
		public string Text { get; set; } = "";

		public bool IsDaily { get; set; } = false;
		public bool IsAnswered { get; set; } = false;

		public DateTime LastPrayed { get; set; }

		public Prayer()
		{
		}
	}
}

