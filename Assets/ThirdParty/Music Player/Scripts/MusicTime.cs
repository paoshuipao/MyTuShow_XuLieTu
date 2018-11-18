using UnityEngine;
using System.Collections;
using UnityEngine.UI;

///Developed by Indie Games Studio
///https://www.assetstore.unity3d.com/en/#!/publisher/9268

[DisallowMultipleComponent]
public class MusicTime : MonoBehaviour
{
		/// <summary>
		/// The minutes.
		/// </summary>
		private static int minutes;

		/// <summary>
		/// The seconds.
		/// </summary>
		private static int seconds;

		/// <summary>
		/// The string minutes.
		/// </summary>
		private static string strMinutes;

		/// <summary>
		/// The string seconds.
		/// </summary>
		private static string strSeconds;

		/// <summary>
		/// The time text.
		/// </summary>
		public Text timeText;

		// Use this for initialization
		void Start ()
		{
				///Setting up the references
				if (timeText == null) {
						timeText = GetComponent<Text> ();
				}
		}

		/// <summary>
		/// Sets the time.
		/// </summary>
		/// <param name="time">Time.</param>
		/// <param name="totalTime">Total time.</param>
		public void SetTime (float time, string totalTime)
		{
				if (timeText == null) {
						return;
				}
				timeText.text = TimeToString (time) + " / " + totalTime;
		}

		/// <summary>
		/// Convert the time in seconds to the string format "00:00".
		/// </summary>
		/// <returns>String Time Format.</returns>
		/// <param name="time">The time in seconds.</param>
		public static string TimeToString (float time)
		{
				minutes = (int)(time / 60.0f);
				seconds = (int)(time % 60.0f);
				strMinutes = "";
				strSeconds = "";
		
				if (minutes < 10) {
						strMinutes += "0";
				}
				if (seconds < 10) {
						strSeconds += "0";
				}
		
				strMinutes += minutes;
				strSeconds += seconds;
		
				return string.Format ("{0}:{1}", strMinutes, strSeconds);
		}
}