using UnityEngine;
using System.Collections;

public class PlayerFreeze : MonoBehaviour {
	[HideInInspector]
	public Statue statue;
	// Use this for initialization
	void Start () {
		GetComponent<MovePlayer> ().moving = false;
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		if (Physics.Raycast (Camera.main.transform.position, Camera.main.transform.forward, out hit)) {
			if(hit.transform.gameObject.tag == "One" && GameManager.player != Player.ONE){
				CheckHello();
			}else if(hit.transform.gameObject.tag == "Two" && GameManager.player != Player.TWO){
				CheckHello();
			}
			Debug.Log(hit.transform.name);
		}
	}

	void CheckHello(){
		if (GetComponent<MovePlayer> ().helloing) {
			statue.Resolve();
			Destroy(this);
		}
	}
}
