using UnityEngine;
using System.Collections;

public class PlanetsMixer : MonoBehaviour {

	[SerializeField]
	float distanceByStep;
	[SerializeField]
	int totalSteps;
	[SerializeField]
	Transform[] planetes;
	int currentState = 0;

	void OnEnable(){
		GameManager.OnPlayerSet += SetPlanetes;
	}

	void SetPlanetes(){
		planetes [0].position = new Vector3 (0, distanceByStep / 2 * totalSteps,0);
		planetes [1].position = new Vector3 (0, -distanceByStep / 2 * totalSteps,0);
	}

	void Update(){
		if(Input.GetKeyUp(KeyCode.P)){
			NewState(currentState + 1);
		}
	}

	public void NewState(int state){
		currentState = state;
		StartCoroutine (NewState ());
	}
	
	IEnumerator NewState(){
		MovePlayer mp = GameObject.FindObjectOfType<MovePlayer> ();
		mp.moving = false;
		Transform closestPlanete = Vector3.Distance (mp.transform.position, planetes [0].position) < Vector3.Distance (mp.transform.position, planetes [1].position) ? planetes [0] : planetes [1];
		mp.transform.parent = closestPlanete;
		while(planetes [0].position != new Vector3 (0, distanceByStep / 2 * (totalSteps - currentState) ,0)){
			planetes[0].position = Vector3.MoveTowards(planetes[0].position, new Vector3 (0, distanceByStep / 2 * (totalSteps - currentState) ,0),1f);
			planetes[1].position = Vector3.MoveTowards(planetes[1].position, new Vector3 (0, -distanceByStep / 2 * (totalSteps - currentState) ,0),1f);
			yield return null;
		}
		mp.moving = true;
		mp.transform.parent = mp.transform.root;
	}
}