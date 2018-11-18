/*
using UnityEngine;
using System.Collections;

public class TestInput : MonoBehaviour
{
	public UI_FileBrowser _uiFB;
	public string Path;
	private bool DoOnce = false;

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Space))
		{
			_uiFB.Open (Path);
			DoOnce = true;
		}

		if( _uiFB.GetPath() != null && DoOnce )
		{
			Debug.Log( "Opened : "+_uiFB.GetPath() );
			DoOnce = false;
		}
	}
}
*/
