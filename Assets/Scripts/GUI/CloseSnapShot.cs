using UnityEngine;
using System.Collections;

public class CloseSnapShot : MonoBehaviour {

	[SerializeField]
	private PlayerSnap snap;
	[SerializeField]
	GameObject rootSnapShotUI;
	public PlayerSnap snapScript;

	float lastShowPicInput;
	float showPicInput;

	void Update()
	{
		lastShowPicInput = showPicInput;
		showPicInput = Input.GetAxis ("Show Picture");

		if(showPicInput == 1 && lastShowPicInput == 0 && snapScript.textureReceived != null){
			if (snapScript.targetRenderer.gameObject.active == true)
			{
				CloseUI();				
			}
		}
	}

	public void CloseUI(){
		snap.HidePicture();
	}
}
