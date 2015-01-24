using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class WalkSound : MonoBehaviour {

	protected Animator animator;
	protected AudioSource walkSource;

	void Start () {
		animator = GetComponent<Animator>();
		walkSource = GetComponent<AudioSource>();
	}
	
	void Update () {
		if (animator)
		{
			//get the current state
			AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

			if(stateInfo.nameHash == Animator.StringToHash("Base Layer.walk"))
			{
				walkSource.volume = 1;
			}
			else {
				walkSource.volume = 0;
			}
		}
	}
}
