﻿using UnityEngine;
using System.Collections;

public class MysteryManager : MonoBehaviour {
	public static void Initialize(){
		
	}	

	public static void MysteryResolved(Mysteries id){
		Debug.Log ("Mystery " + id + " has been resolved");
	}
}