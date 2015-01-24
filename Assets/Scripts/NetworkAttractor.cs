using UnityEngine;
using System.Collections;

public class NetworkAttractor : MonoBehaviour {
	public Player playerToAttract;

	void Start(){
		GameManager.OnPlayerSet += OnGameReady;
	}
	
	void OnGameReady(){
		if (GameManager.player != playerToAttract) {
			GetComponent<Attractor>().enabled = false;
		}
	}
}
