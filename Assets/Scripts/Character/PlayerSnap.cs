using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerSnap : MonoBehaviour {

	[SerializeField]
	MovePlayer movePlayer;
	Dictionary<Player,Texture2D> snapShots;
	Renderer targetRenderer;
	float lastSnapInput;
	float snapInput;
	Player currentPlayer;

	void OnEnable(){
		GameManager.OnPlayerSet += Set;
	}
	void OnDisable(){
		GameManager.OnPlayerSet -= Set;
	}

	void Awake(){
		lastSnapInput = 0;
		snapInput = 0;
		snapShots = new Dictionary<Player, Texture2D> (){
			{Player.ONE, new Texture2D(1,1)},
			{Player.TWO, new Texture2D(1,1)}
		};
	}

	void Set(){
		currentPlayer = GameManager.player;
	}

	// Update is called once per frame
	void Update () {
		lastSnapInput = snapInput;
		snapInput = Input.GetAxis ("Snap");

	}

	void OnPostRender(){
		if(snapInput == 1 && lastSnapInput == 0 && currentPlayer != null){
			Snap();
		}
	}

	void Snap(){
		Texture2D texture = new Texture2D ((int)Camera.main.pixelWidth, (int)Camera.main.pixelHeight, TextureFormat.RGB24, true);
		texture.ReadPixels(new Rect(0, 0, Camera.main.pixelWidth, Camera.main.pixelHeight), 0, 0);
		texture.Apply ();
		snapShots[currentPlayer] = texture;
		targetRenderer.material.mainTexture = texture;
	}
}
