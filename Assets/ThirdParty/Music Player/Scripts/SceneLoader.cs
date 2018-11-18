using UnityEngine;
using System.Collections;

///Developed by Indie Games Studio
///https://www.assetstore.unity3d.com/en/#!/publisher/9268

[DisallowMultipleComponent]
public class SceneLoader : MonoBehaviour
{
		/// <summary>
		/// The name of the scene.
		/// </summary>
		public string sceneName;

		/// <summary>
		/// The delay time before loading the scene.
		/// </summary>
		public float sleepTime;

		// Use this for initialization
		void Start ()
		{
				Invoke ("LoadScene", sleepTime);				
		}

		private void LoadScene ()
		{
				if (!string.IsNullOrEmpty (sceneName)) {
						Application.LoadLevel (sceneName);
				}
		}
}
