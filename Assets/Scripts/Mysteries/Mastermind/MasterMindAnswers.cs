using UnityEngine;
using System.Collections;

public class MasterMindAnswers : MonoBehaviour {	
	public bool rpced = false;

	[RPC]
	void AlertResolve(){
		rpced = true;
		renderer.material.color = Color.green;
	}

	[RPC]
	void AlertWrong(){
		rpced = true;
		renderer.material.color = Color.red;
	}
}
