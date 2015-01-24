using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {

	public string sceneToLoad;

	public void LoadScene(){
		Application.LoadLevel (sceneToLoad);
	}
}
