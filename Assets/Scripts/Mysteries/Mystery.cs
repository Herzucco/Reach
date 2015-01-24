using UnityEngine;
using System.Collections;

public class Mystery : MonoBehaviour {
	private MysterySpawn spawn;
	protected virtual void Awake(){
		spawn = transform.parent.gameObject.GetComponent<MysterySpawn>();
	}

	protected virtual void Resolve(){
		spawn.TriggerMysteryResolved ();
	}
}
