using UnityEngine;
using System.Collections;

public class ContextActionPanel : MonoBehaviour {

	[SerializeField]
	UILabel label;

	public void Launch(string actionName){
		gameObject.SetActive (true);
		label.text = actionName;
	}

	public void Close(){
		gameObject.SetActive (false);
	}
}
