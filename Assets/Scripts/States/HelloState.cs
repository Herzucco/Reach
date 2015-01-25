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
		
		Debug.Log("lol what");
		if (id == Mysteries.Hello) {
			Debug.Log("mystery Solved");
			helloDone++;
			if(helloDone >= 2){
				Debug.Log("Lets go more");
				mixer.NewState(1);
				fsm.ChangeState(MysterySlabsState.Instance);
			}
		}
	}
}
