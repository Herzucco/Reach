using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class MovePlayer : MonoBehaviour {

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

	Rigidbody mRigidbody;
	Transform mTransform;
	Vector3 moveVec;
	float rotX;
	float rotY;
	Transform cam;
	bool jumping;
	bool grounded;
	float _jumpedTime;

	void Awake(){
		Screen.showCursor = false;
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
		grounded = IsGrounded ();
		moveVec.z = Input.GetAxis ("Vertical");
		moveVec.x = Input.GetAxis ("Horizontal");
		rotX = cam.localRotation.eulerAngles.x - Input.GetAxis ("Mouse Y") * rotationSpeedX;
		if(rotX >80 && rotX < 100){
			rotX = 80;
		}else if(rotX < 280 && rotX > 200){
			rotX = 280;
		}
		rotY = Input.GetAxis ("Mouse X") * rotationSpeedY;
		if(jumping || grounded){
			jumping = Input.GetAxis ("Jump") > 0;
			if(jumping)
				_jumpedTime = 0;
		}
	}

	void FixedUpdate(){
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
}
