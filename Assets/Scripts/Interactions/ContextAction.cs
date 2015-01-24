using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public abstract class ContextAction : MonoBehaviour {


	public delegate void ActionDelegate ();
	[SerializeField]
	protected string ActionName;
	protected Collider mCollider;

	protected void Awake(){
		mCollider = collider;
		mCollider.isTrigger = true;
	}

	protected void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){
			MovePlayer mp = other.GetComponent<MovePlayer>();
			mp.ActionChanged(Action, ActionName, true);
		}
	}

	protected void OnTriggerExit(Collider other){
		if(other.tag == "Player"){
			MovePlayer mp = other.GetComponent<MovePlayer>();
			if(mp.CurrentAction == Action){
				mp.ActionChanged(Action, null, false);
			}
		}
	}

	public abstract void Action();
}
