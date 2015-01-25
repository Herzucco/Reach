using UnityEngine;
using System.Collections;

public class FinalState : FSMState<MysteryManager> {
	
	private static readonly FinalState instance = new FinalState();
	
	public static FinalState Instance
	{
		get { return instance; }
	}

	private PlanetsMixer mixer;
	private MovePlayer[] players;

	void Start(){
		mixer = GameObject.FindObjectOfType<PlanetsMixer> ();
		players = GameObject.FindObjectsOfType<MovePlayer> ();
	}

	public override void Execute(MysteryManager o, FSM<MysteryManager> fsm)
	{
		mixer = GameObject.FindObjectOfType<PlanetsMixer> ();
		if(Vector3.Distance(players[0].transform.position, players[1].transform.position) <= 5){
			//Fin du Game
			Application.LoadLevel("Cinematic");
		}
	}
	
	public override void Transition(MysteryManager o, FSM<MysteryManager> fsm)
	{
		
	}
}
