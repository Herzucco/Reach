using UnityEngine;
using System.Collections;

public class PlanetsMixer : MonoBehaviour {

	[SerializeField]
	float distanceByStep;
	[SerializeField]
	int totalSteps;
	[SerializeField]
	Transform[] planetes;

	void OnEnable(){
		GameManager.OnPlayerSet += SetPlanetes;
	}

	void SetPlanetes(){
		planetes [0].position = new Vector3 (0, distanceByStep / 2 * totalSteps,0);
		planetes [1].position = new Vector3 (0, -distanceByStep / 2 * totalSteps,0);
	}
}
