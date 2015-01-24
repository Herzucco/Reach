using UnityEngine;
using System.Collections;

public class CloseSnapShot : MonoBehaviour {

	[SerializeField]
	private PlayerSnap snap;
	[SerializeField]
	GameObject rootSnapShotUI;

	public void CloseUI(){
		snap.HidePicture();
	}
}
