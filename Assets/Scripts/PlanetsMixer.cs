using UnityEngine;
using System.Collections;

public class PlanetsMixer : MonoBehaviour {

	[SerializeField]
	GameObject[] objectsToRemove;
	[SerializeField]
	AnimationClip mixClip;
	[SerializeField]
	float distanceByStep;
	[SerializeField]
	int totalSteps;
	[SerializeField]
	Transform[] planetes;
	int currentState = 0;
	public int CurrentState{
		get{
			return currentState;
		}
	}
	public int StateNumbers{
		get{return totalSteps;}
	}
	MovePlayer[] mp;

	void OnEnable(){
		GameManager.OnPlayerSet += SetPlanetes;
	}

	void Disable(){
		GameManager.OnPlayerSet -= SetPlanetes;
	}

	void SetPlanetes(){
		planetes [0].position = new Vector3 (0, distanceByStep / 2 * totalSteps,0);
		planetes [1].position = new Vector3 (0, -distanceByStep / 2 * totalSteps,0);
	}

	void Update(){
		if(Input.GetKeyUp(KeyCode.P)){
			//NewState(currentState + 1);
			MixPlanetes();
		}
	}

	void Start(){
		mp = GameObject.FindObjectsOfType<MovePlayer> ();
	}

	public void NewState(int state){
		mp = GameObject.FindObjectsOfType<MovePlayer> ();
		currentState = state;
		StartCoroutine (NewState ());
		//Debug.Log (state);
	}
	
	IEnumerator NewState(){
		FixPlayers ();
		while(planetes [0].position != new Vector3 (0, distanceByStep / 2 * (totalSteps - currentState) ,0)){
			planetes[0].position = Vector3.MoveTowards(planetes[0].position, new Vector3 (0, distanceByStep / 2 * (totalSteps - currentState) ,0),1f);
			planetes[1].position = Vector3.MoveTowards(planetes[1].position, new Vector3 (0, -distanceByStep / 2 * (totalSteps - currentState) ,0),1f);
			yield return null;
		}
		FreePlayers ();
	}

	public void MixPlanetes(){
		mp = GameObject.FindObjectsOfType<MovePlayer> ();
		StartCoroutine (MixPlanetesCoroutine ());
	}

	IEnumerator MixPlanetesCoroutine(){
		planetes [0].parent = transform.GetChild(0);
		planetes [1].parent = transform.GetChild(1);
		planetes [0].transform.localPosition = Vector3.zero;
		planetes [1].transform.localPosition = Vector3.zero;
		planetes [0].transform.localRotation = Quaternion.identity;
		planetes [1].transform.localRotation = Quaternion.identity;
		animation.Play ();
		FixPlayers ();
		yield return new WaitForSeconds (mixClip.length);
		FreePlayers ();
		for(int i = 0; i< objectsToRemove.Length; i++){
			objectsToRemove[i].SetActive(false);
		}
	}

	void FixPlayers(){
		for(int i= 0; i < mp.Length; i++){
			mp[i].moving = false;
			Transform closestPlanete = Vector3.Distance (mp[i].transform.position, planetes [0].position) < Vector3.Distance (mp[i].transform.position, planetes [1].position) ? planetes [0].transform : planetes [1].transform;
			mp[i].transform.parent = closestPlanete;
		}
	}

	void FreePlayers(){
		for(int i= 0; i < mp.Length; i++){
			mp[i].moving = true;			
			mp[i].transform.parent = null;
            mp[i].rigidbody.velocity.Set(0, 0, 0);
		}
	}
}