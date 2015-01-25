using UnityEngine;
using System.Collections;

public class EndCinematique : MonoBehaviour {

	// Use this for initialization
	IEnumerator Start () {
		animation.Play ();
		yield return new WaitForSeconds (animation.clip.length);
		Application.LoadLevel ("Menu");
	}
}
