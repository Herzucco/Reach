using UnityEngine;
using System.Collections;

public class MysterySlabsState : FSMState<MysteryManager> {
	
	private static readonly MysterySlabsState instance = new MysterySlabsState();
	
	public static MysterySlabsState Instance
	{
		get { return instance; }
	}

	private static int slabsDone = 0;

	public override void Execute(MysteryManager o, FSM<MysteryManager> fsm)
	{

	}
	
	public override void Transition(MysteryManager o, FSM<MysteryManager> fsm)
	{
		
	}

	public override void MysterySolved(MysteryManager o, FSM<MysteryManager> fsm, Mysteries id){
		if (id == Mysteries.SlabSign) {
			slabsDone++;
			if(slabsDone >= 2){
				Debug.Log("Success");
			}
		}
	}
}
