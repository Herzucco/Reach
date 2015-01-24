using UnityEngine;
using System.Collections;

public class Mystery : MonoBehaviour {
	public Mysteries id;

	private PhotonView photonView;

	protected virtual void Start(){
		photonView = gameObject.AddComponent<PhotonView> ();
	}

	[RPC]
	protected virtual void ListenMysteryResolved(){
		AlertMysteryManager ();
	}

	protected virtual void TriggerMysteryResolved(){
		photonView.RPC("ListenMysteryResolved", PhotonTargets.All);
		AlertMysteryManager ();
	}

	private void AlertMysteryManager(){
		MysteryManager.MysteryResolved (id);
	}
}
