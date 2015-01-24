﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class MovePlayer : MonoBehaviour {

	[HideInInspector]
	public bool moving = true;

	[SerializeField]
	Animator anim;
	[SerializeField]
	float jumpDuration;
	[SerializeField]
	float minJumpDuration;
	[SerializeField]
	AnimationCurve jumpCurve;
	[SerializeField]
	float jumpForce;
	[SerializeField]
	private	float speed;
	[SerializeField]
	private	float rotationSpeedY;
	[SerializeField]
	private float smoothingForce;
	[SerializeField]
	ContextActionPanel actionPanel;

	ContextAction.ActionDelegate currentAction;
	public ContextAction.ActionDelegate CurrentAction{
		get{ return currentAction;}
	}

	Rigidbody mRigidbody;
	Transform mTransform;
	Vector3 moveVec;
	float rotY;
	Transform cam;
	bool jumping;
	bool grounded;
	float _jumpedTime;
	float oldActionInput;
	float currentActionInput;
	bool helloing;

	void Awake(){
		helloing = false;
		Screen.showCursor = false;
		oldActionInput = 0;
		currentActionInput = 0;
		_jumpedTime = jumpDuration;
		grounded = false;
		jumping = false;
		rotY = 0;
		mRigidbody = rigidbody;
		mTransform = transform;
		moveVec = Vector3.zero;
		cam = Camera.main.transform;
	}

	void Update(){
		if(Input.GetAxis("Hello") > 0){
			moving = false;
			StartCoroutine(Hello());
		}
		anim.SetFloat ("speed", Mathf.Abs (moveVec.x) + Mathf.Abs (moveVec.z));
		anim.SetBool ("jumping", !grounded);
		anim.SetBool ("hello", helloing);
		if(!moving)
			return;
		oldActionInput = currentActionInput;
		currentActionInput = Input.GetAxis ("Action");
		if(currentActionInput == 1 && oldActionInput == 0 && currentAction != null){
			currentAction();
		}
		grounded = IsGrounded ();
		moveVec.z = Input.GetAxis ("Vertical");
		rotY = Input.GetAxis ("Horizontal") * rotationSpeedY;
		if(jumping || grounded){
			jumping = Input.GetAxis ("Jump") > 0;
			if(jumping)
				_jumpedTime = 0;
		}
	}

	void FixedUpdate(){
		if(!moving)
			return;
		Jump ();
		mRigidbody.MovePosition (mTransform.position + mTransform.TransformDirection (moveVec * speed));
		mTransform.Rotate (Vector3.up, rotY);
	}


	bool IsGrounded(){
		return Physics.Raycast(mTransform.position, -mTransform.up, 2);
	}

	void Jump(){
		if(jumping || _jumpedTime < minJumpDuration){
			_jumpedTime += Time.fixedDeltaTime;
			moveVec.y = jumpCurve.Evaluate(_jumpedTime / jumpDuration) * jumpForce;
			if(_jumpedTime > jumpDuration){
				jumping = false;
				_jumpedTime = jumpDuration;
			}
		}else{
			moveVec.y = Mathf.Lerp(moveVec.y, 0, smoothingForce);
		}
	}

	public void ActionChanged(ContextAction.ActionDelegate action, string name, bool activation){
		if(activation){
			currentAction = action;
			actionPanel.Launch(name);
		}else if(currentAction == action){
			currentAction = null;
			actionPanel.Close();
		}
	}

	IEnumerator Hello(){
		helloing = true;
		yield return new WaitForSeconds (2);
		moving = true;
		helloing = false;
	}
}
