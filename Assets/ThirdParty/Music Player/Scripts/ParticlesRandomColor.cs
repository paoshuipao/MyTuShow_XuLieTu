using UnityEngine;
using System.Collections;

///Developed by Indie Games Studio
///https://www.assetstore.unity3d.com/en/#!/publisher/9268

public class ParticlesRandomColor : MonoBehaviour
{
		/// <summary>
		/// The particle system component.
		/// </summary>
		public ParticleSystem ps;

		/// <summary>
		/// The alpha of the color.
		/// </summary>
		[Range(0,255)]
		public float alpha = 126;

		/// <summary>
		/// The is running flag.
		/// </summary>
		public bool isRunning;

		/// <summary>
		/// The sleep time.
		/// </summary>
		private float sleepTime = 0.5f;

		// Use this for initialization
		IEnumerator Start ()
		{
				while (isRunning) {
						if (GetComponent<ParticleSystem>() != null) {
								ps.startColor = new Color (Random.Range (0, 255), Random.Range (0, 255), Random.Range (0, 255), alpha) / 255.0f;
						}
						yield return new WaitForSeconds (sleepTime);
				}
		}
}