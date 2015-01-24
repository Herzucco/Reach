using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class AttractedBody : MonoBehaviour {

	public Transform GetTransform;
	public Rigidbody GetRigidBody;

	// Use this for initialization
	void Awake () {
		GetTransform = GetComponent<Transform> ();
		GetRigidBody = GetComponent<Rigidbody> ();
		GetRigidBody.constraints = RigidbodyConstraints.FreezeRotation;
		GetRigidBody.useGravity = false;
	}

	public void Attract(){
		Attractor[] a = GameObject.FindObjectsOfType<Attractor> ();

		for (int i = 0; i < a.Length; i++) {
			a[i].AddBody ((this));
		}
	}

}
