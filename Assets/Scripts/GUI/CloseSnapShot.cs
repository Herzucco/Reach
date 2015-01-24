using UnityEngine;
using System.Collections;

public class CloseSnapShot : MonoBehaviour {

	[SerializeField]
	private PlayerSnap snap;
	[SerializeField]
	GameObject rootSnapShotUI;

	void OnKeyPress(bool pressed){
		if(!pressed){
			snap.HidePicture();
		}
	}
}
