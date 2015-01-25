using UnityEngine;
using System.Collections;

public class TutoManager : MonoBehaviour {
	public float animDuration;
	public GameObject[] allLabels;
	private int i;
	// Use this for initialization
	public void StartTuto () {
		StartCoroutine("ChangeAnim");
	}
	
	// Update is called once per frame
	void Update () {
		if (i == allLabels.Length)
		{
			StopCoroutine("ChangeAnim");
		}
	}

	IEnumerator ChangeAnim(){
		for(;;){
			yield return new WaitForSeconds(animDuration);
			allLabels[i].animation.Play();
			i += 1;
		}
	}
}
