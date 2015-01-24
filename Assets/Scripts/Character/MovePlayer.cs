using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class MovePlayer : MonoBehaviour {

	[HideInInspector]
	public bool moving = true;

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
	private	float rotationSpeedX;
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
	float rotX;
	float rotY;
	Transform cam;
	bool jumping;
	bool grounded;
	float _jumpedTime;
	float oldActionInput;
	float currentActionInput;

	void Awake(){
		Screen.showCursor = false;
		oldActionInput = 0;
		currentActionInput = 0;
		_jumpedTime = jumpDuration;
		grounded = false;
		jumping = false;
		rotX = 0;
		rotY = 0;
		mRigidbody = rigidbody;
		mTransform = transform;
		moveVec = Vector3.zero;
		cam = Camera.main.transform;
	}

	void Update(){
		if(!moving)
			return;
		oldActionInput = currentActionInput;
		currentActionInput = Input.GetAxis ("Action");
		if(currentActionInput == 1 && oldActionInput == 0 && currentAction != null){
			currentAction();
		}
		grounded = IsGrounded ();
		moveVec.z = Input.GetAxis ("VerticalPad");
		moveVec.x = Input.GetAxis ("HorizontalPad");
		if(moveVec.z != 0 || moveVec.x != 0){
			moveVec.z = Input.GetAxis ("Vertical");
			moveVec.x = Input.GetAxis ("Horizontal");
		}
		float goodAxis = Input.GetAxis ("Mouse YPad") != 0 ? Input.GetAxis ("Mouse YPad") : Input.GetAxis ("Mouse Y");
		rotX = cam.localRotation.eulerAngles.x - goodAxis * rotationSpeedX;
		if(rotX >80 && rotX < 100){
			rotX = 80;
		}else if(rotX < 280 && rotX > 200){
			rotX = 280;
		}
		if(Mathf.Abs(rotX) < 0.2)
			rotX = 0;
		goodAxis = Input.GetAxis ("Mouse XPad") != 0 ? Input.GetAxis ("Mouse XPad") : Input.GetAxis ("Mouse X");
		rotY = goodAxis * rotationSpeedY;
		if(Mathf.Abs(rotY) < 0.2)
			rotY = 0;
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

	void LateUpdate(){
		cam.localRotation = Quaternion.Euler (rotX, 0, 0);
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
}
