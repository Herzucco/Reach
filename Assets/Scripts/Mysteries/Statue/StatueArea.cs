using UnityEngine;
using System.Collections;

public class StatueArea : ContextAction {
	[HideInInspector]
	public bool hasPlayer = false;

	protected override void PlayerEnter(){

	}

	public override void Action(){
		hasPlayer = true;
		GameObject go = GameObject.FindGameObjectWithTag ("InteractSound");
		if (go != null) {
			go.GetComponent<AudioSource> ().Play ();
		}
	}
}
