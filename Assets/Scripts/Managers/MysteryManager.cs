using UnityEngine;
using System.Collections;

public class MysteryManager : MonoBehaviour {
	protected static FSM<MysteryManager> fsm;

	protected static MysteryManager instance;
	
	public static MysteryManager Instance
	{
		get { 
			if(instance == null){
				instance = FindObjectOfType<MysteryManager>();
			}

			return instance; 
		}
	}

	public static void Initialize(){
		fsm = new FSM<MysteryManager>();
		fsm.Configure(Instance, MysterySlabsState.Instance);
	}	

	public static void MysteryResolved(Mysteries id){
		fsm.current.MysterySolved (Instance, fsm, id);
	}
}
