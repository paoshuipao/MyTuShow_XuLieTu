using UnityEngine;
using System.Collections;
using UnityEngine.UI;

///Developed by Indie Games Studio
///https://www.assetstore.unity3d.com/en/#!/publisher/9268

public class MusicInfoManager : MonoBehaviour
{
		/// <summary>
		/// The music player.
		/// </summary>
		public MusicPlayer musicPlayer;

		/// <summary>
		/// The music info.
		/// </summary>
		private MusicInfo[] musicInfo;

		/// <summary>
		/// The music logo.
		/// </summary>
		public Image musicLogo;

		/// <summary>
		/// The URL,music name.
		/// </summary>
		public Text url, musicName;

		/// <summary>
		/// The music info animator.
		/// </summary>
		public Animator musicInfoAnimator;

		// Use this for initialization
		void Start ()
		{
				if (musicLogo == null) {
						musicLogo = transform.Find ("Logo").GetComponent<Image> ();
				}
				if (url == null) {
						url = transform.Find ("URL").GetComponent<Text> ();
				}

				if (musicName == null) {
						musicName = transform.Find ("MusicName").GetComponent<Text> ();
				}

				if (musicInfoAnimator == null) {
						musicInfoAnimator = GetComponent<Animator> ();
				}

				if (musicPlayer == null) {
					GameObject musicPlayerGameObject = GameObject.Find ("MusicPlayer");
					if(musicPlayerGameObject!=null)
						musicPlayer = musicPlayerGameObject.GetComponent<MusicPlayer> ();
				}

				musicInfo = GetComponents<MusicInfo> ();
				ApplyInfo (0);
		}
		
		/// <summary>
		/// Set the music info.
		/// </summary>
		public void SetMusicInfo ()
		{
				if (musicPlayer.currentClipIndex >= 0 && musicPlayer.currentClipIndex < musicPlayer.L_AudioClip.Count) {
						musicInfoAnimator.SetBool ("Toggle", false);
						ApplyInfo (musicPlayer.currentClipIndex);
				}
		}

		/// <summary>
		/// Apply the info.
		/// </summary>
		/// <param name="index">Index.</param>
		private void ApplyInfo (int index)
		{
				if (!(index >= 0 && index < musicInfo.Length)) {
						return;
				}

				musicLogo.sprite = musicInfo [index].musicLogo;
				url.text = musicInfo [index].url;
				musicName.text = musicInfo [index].musicName;
		}
}
