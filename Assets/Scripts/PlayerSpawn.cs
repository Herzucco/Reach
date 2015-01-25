using UnityEngine;
using System.Collections;

public class PlayerSpawn : MonoBehaviour {
	public GameObject playerOne;
	public GameObject playerTwo;

	void Start(){
		GameManager.OnPlayerSet += OnGameReady;
	}

	void OnGameReady(){
		if (GameManager.player == Player.ONE) {
			GameObject go = PhotonNetwork.Instantiate (playerOne.name, transform.position, Quaternion.identity, 0, null);
		} else {
			GameObject go = PhotonNetwork.Instantiate (playerTwo.name, transform.position, Quaternion.identity, 0, null);
		}

		Destroy (gameObject);
		GameManager.OnPlayerSet -= OnGameReady;
	}
}
