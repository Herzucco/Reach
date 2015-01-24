using UnityEngine;
using System.Collections;

public class PlayerSnap : MonoBehaviour {

	[SerializeField]
	MovePlayer movePlayer;
	[HideInInspector]
	public Texture2D textureReceived;

	private Texture2D textureToSend;
	public Texture2D TextureToSend{
		get{
			return textureToSend;
		}
	}

	[SerializeField]
	Renderer targetRenderer;
	[SerializeField]
	GameObject closePictureUI;
	float lastSnapInput;
	float snapInput;
	float lastShowPicInput;
	float showPicInput;
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
	}

	void Set(){
		currentPlayer = GameManager.player;
	}

	// Update is called once per frame
	void Update () {
		lastSnapInput = snapInput;
		snapInput = Input.GetAxis ("Snap");
		lastShowPicInput = showPicInput;
		showPicInput = Input.GetAxis ("Show Picture");
		if(showPicInput == 1 && lastShowPicInput == 0 && textureReceived != null){
			ShowPicture();
		}
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

		textureToSend = texture;
	}

	public void ShowPicture(){
		movePlayer.moving = false;
		targetRenderer.gameObject.SetActive (true);
		closePictureUI.SetActive (true);
	}

	public void HidePicture(){
		movePlayer.moving = true;
		targetRenderer.gameObject.SetActive (false);
		closePictureUI.SetActive (false);
	}

	public void SetTexture(Texture2D texture){
		textureReceived = texture;
		targetRenderer.material.mainTexture = textureReceived;
	}
}
