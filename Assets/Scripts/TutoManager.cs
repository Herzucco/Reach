using UnityEngine;
using System.Collections;

public class TutoManager : MonoBehaviour {
	public float animDuration;
	public GameObject[] allLabels;
	public bool goNow = false;
	private int i;
	// Use this for initialization
	void Start(){
		if (goNow) {
			StartTuto();
		}
	}
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
