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

	void Start(){
		Attractor a = GameObject.FindObjectOfType<Attractor> ();
		a.AddBody ((this));
	}

}
