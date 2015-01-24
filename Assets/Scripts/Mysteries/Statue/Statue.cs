using UnityEngine;
using System.Collections;

public class Statue : Mystery {

	public StatueArea area;
	private GameObject player;
	private GameObject other;

	void Update () {
		if (area.hasPlayer) {
			area.hasPlayer = false;
			Active();
		}
	}

	void Active(){
		GameObject[] players = GameObject.FindGameObjectsWithTag ("Player");
		for (int i = 0; i < players.Length; i++) {
			PhotonView phView = players[i].GetComponent<PhotonView>();
			if(phView.isMine){
				player = players[i];
				break;
			}
		}

		PlayerFreeze pf = player.AddComponent<PlayerFreeze>();
		pf.statue = this;
	}
}
