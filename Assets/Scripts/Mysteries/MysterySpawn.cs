using UnityEngine;
using System.Collections;

[RequireComponent(typeof (PhotonView))]
public class MysterySpawn : MonoBehaviour {
	public Mysteries id;
	public GameObject OnePrefab;
	public GameObject TwoPrefab;

	private PhotonView photonView;

	protected virtual void Start(){
		photonView = GetComponent<PhotonView> ();
		OnePrefab.SetActive(false);
		TwoPrefab.SetActive(false);
		GameManager.OnPlayerSet += SpawnPrefab;
	}

	[RPC]
	protected virtual void ListenMysteryResolved(){
		AlertMysteryManager ();
	}

	public virtual void TriggerMysteryResolved(){
		photonView.RPC("ListenMysteryResolved", PhotonTargets.Others);
		AlertMysteryManager ();
	}

	private void AlertMysteryManager(){
		MysteryManager.MysteryResolved (id);
	}

	private void SpawnPrefab(){
		Debug.Log (GameManager.player);
		if (GameManager.player == Player.ONE) {
			OnePrefab.SetActive(true);
		} else {
			TwoPrefab.SetActive(true);
		}
	}
}
