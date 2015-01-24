using UnityEngine;
using System.Collections;

public class PlayerSpawn : MonoBehaviour {
	public GameObject player;

	void Start(){
		GameManager.OnPlayerSet += OnGameReady;
	}

	void OnGameReady(){
		GameObject go = PhotonNetwork.Instantiate(player.name, transform.position, Quaternion.identity, 0, null);

		Destroy (gameObject);
	}
}
