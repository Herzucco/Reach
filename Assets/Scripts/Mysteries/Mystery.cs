using UnityEngine;
using System.Collections;

public class Mystery : MonoBehaviour {
	private MysterySpawn spawn;
    protected bool isResolved = false;
	protected virtual void Awake(){
		spawn = transform.parent.gameObject.GetComponent<MysterySpawn>();
	}

	public virtual void Resolve(){
        if (!isResolved)
        {
            isResolved = true;
            spawn.TriggerMysteryResolved();
        }
	}
}
