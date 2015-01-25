using UnityEngine;
using System.Collections;

public class MysteryManager : MonoBehaviour {
	public AudioClip clip;
	protected static AudioSource source;
	protected static FSM<MysteryManager> fsm;

	protected static MysteryManager instance;
	
	public static MysteryManager Instance
	{
		get { 
			if(instance == null){
				instance = FindObjectOfType<MysteryManager>();
				source = instance.gameObject.AddComponent<AudioSource>();
			}

			return instance; 
		}
	}

	public static void Initialize(){
		fsm = new FSM<MysteryManager>();
		fsm.Configure(Instance, HelloState.Instance);
	}	

	public static void MysteryResolved(Mysteries id){
		if (source != null) {
			source.clip = instance.clip;
			source.Play();
		}
		fsm.current.MysterySolved (Instance, fsm, id);
	}
}
