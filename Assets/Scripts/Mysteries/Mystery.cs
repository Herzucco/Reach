using UnityEngine;
using System.Collections;

public class Mystery : MonoBehaviour {
	private MysterySpawn spawn;
    private bool isResolved = false;
	protected virtual void Awake(){
		spawn = transform.parent.gameObject.GetComponent<MysterySpawn>();
	}

	protected virtual void Resolve(){
        if (!isResolved)
        {
            isResolved = true;
            spawn.TriggerMysteryResolved();
        }
	}
}
