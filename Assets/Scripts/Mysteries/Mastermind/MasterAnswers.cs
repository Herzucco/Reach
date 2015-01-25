using UnityEngine;
using System.Collections;

public class MasterAnswers : MonoBehaviour {
	public bool rpced = true;

	[RPC]
	public void AlertResolve(){
		rpced = true;
		renderer.material.color = Color.green;
	}
	
	[RPC]
	public void AlertBad(){
		rpced = true;
		renderer.material.color = Color.white;
	}
}
