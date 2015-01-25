using UnityEngine;
using System.Collections;

public class MasterAnswers : MonoBehaviour {

	[RPC]
	public void AlertResolve(){
		renderer.material.color = Color.green;
	}
	
	[RPC]
	public void AlertBad(){
		renderer.material.color = Color.white;
	}
}
