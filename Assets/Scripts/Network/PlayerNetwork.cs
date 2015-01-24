using UnityEngine;
using System.Collections;

public class PlayerNetwork : MonoBehaviour {
	public MonoBehaviour[] componentsToDisable;
	public Camera cameraToDisable;
	public UIRoot uiToDisable;
	public GameObject snapshots;

	public void Awake(){
		PhotonView phView = GetComponent<PhotonView> ();

		if (!phView.isMine) {
			for(int i = 0; i < componentsToDisable.Length; i++){
				componentsToDisable[i].enabled = false;
			}

			cameraToDisable.gameObject.SetActive (false);
			uiToDisable.gameObject.SetActive(false);
		}

	}
}
