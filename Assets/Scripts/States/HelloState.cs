using UnityEngine;
using System.Collections;

public class HelloState : FSMState<MysteryManager> {
	
	private static readonly HelloState instance = new HelloState();
	
	public static HelloState Instance
	{
		get { return instance; }
	}

	private static int helloDone = 0;
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
		
	}

	public override void MysterySolved(MysteryManager o, FSM<MysteryManager> fsm, Mysteries id){
		if (id == Mysteries.Hello) {
			helloDone++;
			if(helloDone >= 2){
				mixer.NewState(1);
				fsm.ChangeState(new MysterySlabsState());
			}
		}
	}
}
