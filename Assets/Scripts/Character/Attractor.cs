using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Attractor : MonoBehaviour {

	[SerializeField]
	[Range(0,100)]
	public float gravity;
	[SerializeField]
	private float rotationRate;
	private List<AttractedBody> bodies;
	private Transform mTransform;

	public void AddBody(AttractedBody body){
		bodies.Add (body);
	}

	void Awake () {
		gravity = -gravity;
		bodies = new List<AttractedBody> ();
		mTransform = transform;
	}

	void Update(){
		for(int i = 0; i < bodies.Count; i++){
			if(bodies[i] != null){
				Vector3 gravityUp = (bodies[i].GetTransform.position - mTransform.position).normalized;
				Vector3 bodyUp = bodies[i].GetTransform.up;
				bodies[i].GetRigidBody.AddForce(gravityUp * gravity);
				Quaternion targetRotation = Quaternion.FromToRotation(bodyUp, gravityUp) * bodies[i].GetTransform.rotation;
				bodies[i].GetTransform.rotation = Quaternion.Slerp(bodies[i].GetTransform.rotation, targetRotation, rotationRate * Time.deltaTime);
			}else{
				break;
			}

		}
	}
}
