using UnityEngine;
using System.Collections;

public class HelloDeclencher : MonoBehaviour {
	public AudioSource helloSource;

	[RPC]
	protected virtual void ListenHello(){
		helloSource.Play ();
	}
	
	public virtual void TriggerHello(){
		PhotonView photonView = GetComponent<PhotonView> ();
		photonView.RPC("ListenHello", PhotonTargets.Others);
	}
}
