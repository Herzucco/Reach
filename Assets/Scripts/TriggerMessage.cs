using UnityEngine;
using System.Collections;

public class TriggerMessage : MonoBehaviour {

	public string infoLabel;
	private GameObject labelObject;

	void OnTriggerEnter(Collider other) {
        labelObject = GameObject.FindWithTag(infoLabel);
        labelObject.animation.Play();
        Debug.Log(labelObject);
        Destroy(this.gameObject);
    }

}
