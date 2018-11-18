using UnityEngine;
using System.Collections;
using UnityEngine.UI;

///Developed by Indie Games Studio
///https://www.assetstore.unity3d.com/en/#!/publisher/9268

public class SoundIconManager : MonoBehaviour
{
		/// <summary>
		/// The music player reference.
		/// </summary>
		public MusicPlayer musicPlayer;

		/// <summary>
		/// The sound level slider reference.
		/// </summary>
		public Slider soundLevelSlider;

		/// <summary>
		/// The sound button image reference.
		/// </summary>
		public Image soundButtonImage;

		// Use this for initialization
		void Start ()
		{
				///Setting up the referecnes
				if (soundButtonImage == null) {
						soundButtonImage = GetComponent<Image> ();
				}

				if (soundLevelSlider == null) {
						soundLevelSlider = GameObject.FindGameObjectWithTag ("SoundLevelSlider").GetComponent<Slider> ();
				}

				if (musicPlayer == null) {
						musicPlayer = GameObject.Find ("MusicPlayer").GetComponent<MusicPlayer> ();
				}
		}
	
		// Update is called once per frame
		void Update ()
		{
				///Check whether the music player is muted
				if (!musicPlayer.Muted) {
						///Set the sound icon relative to the value of sound level slider
						if (soundLevelSlider.value >= 0.6f) {
								soundButtonImage.sprite = musicPlayer.soundIcons [0];
						} else if (soundLevelSlider.value >= 0.3f && soundLevelSlider.value < 0.6f) {
								soundButtonImage.sprite = musicPlayer.soundIcons [1];
						} else if (soundLevelSlider.value > 0 && soundLevelSlider.value < 0.3f) {
								soundButtonImage.sprite = musicPlayer.soundIcons [2];
						} else if (soundLevelSlider.value == 0) {
								soundButtonImage.sprite = musicPlayer.soundIcons [3];
						}
				}
		}
}