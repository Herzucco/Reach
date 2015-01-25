﻿using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour {

	enum camStyle{
		FPS,
		TPS
	}
	[SerializeField]
	Transform player;
	[SerializeField]
	float rotationSpeedY;
	[SerializeField]
	Transform fpsPos;
	[SerializeField]
	Transform tpsPos;
	[SerializeField]
	LayerMask fpsMask;
	[SerializeField]
	LayerMask tpsMask;
	camStyle currentStyle;
	Camera cam;
	Transform mTransform;

	float currentSwitchInput;
	float prevSwitchInput;
	float rotY = 0;
	float rotX = 0;

	void Awake(){
		cam = GetComponent<Camera> ();
		currentSwitchInput = 0;
		prevSwitchInput = 0;
		mTransform = transform;
		currentStyle = camStyle.TPS;
	}

	void Update(){
		prevSwitchInput = currentSwitchInput;
		currentSwitchInput = Input.GetAxis ("Switch Cam");
		if(currentSwitchInput > 0.9 && prevSwitchInput < 0.2){
			Switch ();
		}
		if(currentStyle == camStyle.TPS){
			rotY = Input.GetAxis ("Horizontal") * rotationSpeedY;
			rotX = 0;
		}else{
			rotY = Input.GetAxis ("Mouse X") / 4;
			rotX = Input.GetAxis("Mouse Y") /4;
			player.GetComponent<MovePlayer>().SetMoveVecX = Input.GetAxis("Horizontal");
		}
	}

	void FixedUpdate(){		
		player.Rotate (Vector3.up, rotY);
		mTransform.Rotate (Vector3.left, rotX);
	}

	void Switch(){
		if(currentStyle == camStyle.FPS){
			currentStyle = camStyle.TPS;
			cam.cullingMask = tpsMask;
			mTransform.position = tpsPos.position;
			mTransform.rotation = tpsPos.rotation;
		}else{
			currentStyle = camStyle.FPS;
			cam.cullingMask = fpsMask;
			mTransform.position = fpsPos.position;
			mTransform.rotation = fpsPos.rotation;
		}
	}
}
