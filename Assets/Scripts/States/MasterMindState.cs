using UnityEngine;
using System.Collections;

public class MasterMindState : FSMState<MysteryManager> {
	
	private static readonly MasterMindState instance = new MasterMindState();
	
	public static MasterMindState Instance
	{
		get { return instance; }
	}

	private static int MasterMindDone = 0;
	private PlanetsMixer mixer;

	void Start(){
		mixer = GameObject.FindObjectOfType<PlanetsMixer> ();
	}

	public override void Execute(MysteryManager o, FSM<MysteryManager> fsm)
	{
		//Put Helps Here
	}
	
	public override void Transition(MysteryManager o, FSM<MysteryManager> fsm)
	{
		mixer.MixPlanetes ();
	}

	public override void MysterySolved(MysteryManager o, FSM<MysteryManager> fsm, Mysteries id){
		mixer = GameObject.FindObjectOfType<PlanetsMixer> ();
		if (id == Mysteries.Hello) {
			MasterMindDone++;
			if(MasterMindDone >= 2){
				fsm.ChangeState(FinalState.Instance);
			}
		}
	}
}
