using UnityEngine;
using System.Collections;

[RequireComponent(typeof (PhotonView))]
public class MailBox : ContextAction {
	public Transform oneSpawn;
	public Transform twoSpawn;
	public Renderer renderer;
	public bool isFull = false;

	private PhotonView photonView;

	protected virtual void Start(){
		photonView = GetComponent<PhotonView> ();
		GameManager.OnPlayerSet += OnGameReady;

	}

	public override void Action ()
	{
		TriggerMailBox ();
		if (isFull) {

		} else {

		}
	}

	[RPC]
	protected virtual void ListenMailBox(){
	}
	
	public virtual void TriggerMailBox(){
		photonView.RPC("ListenMailBox", PhotonTargets.All);
	}
		
	void OnGameReady(){
		if (GameManager.player == Player.ONE) {
			transform.position = oneSpawn.position;
		} else {
			transform.position = twoSpawn.position;
		}
	}
}
