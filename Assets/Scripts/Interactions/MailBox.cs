using UnityEngine;
using System.Collections;

[RequireComponent(typeof (PhotonView))]
public class MailBox : MonoBehaviour {
	public Transform oneSpawn;
	public Transform twoSpawn;

	public Renderer renderer;
	public bool isFull = false;

	private PhotonView photonView;
	private PlayerSnap snap;
	public Texture2D receivedTexture = null;

	public AudioClip inboxSound;
	public AudioClip outboxSound;
	protected AudioSource soundSource;

	protected virtual void Start(){
		photonView = GetComponent<PhotonView> ();
		GameManager.OnPlayerSet += OnGameReady;
		soundSource = GetComponent<AudioSource>();
	}

	[RPC]
	protected virtual void ListenMailBox(byte[] receivedByte){
		Debug.Log ("oker");
		receivedTexture = new Texture2D(1, 1);
		receivedTexture.LoadImage(receivedByte);
		isFull = true;
		snap = Camera.main.gameObject.GetComponent<PlayerSnap> ();
		snap.SetTexture(receivedTexture);

		soundSource.clip = outboxSound;
		soundSource.Play();
	}
	
	public virtual void TriggerMailBox(){
		snap = Camera.main.gameObject.GetComponent<PlayerSnap> ();
		if (snap.TextureToSend != null) {
			Debug.Log("RPC");
			Debug.Log(snap.TextureToSend.EncodeToPNG().Length);
			photonView.RPC("ListenMailBox", PhotonTargets.Others, snap.TextureToSend.EncodeToJPG());
		}
	}
		
	void OnGameReady(){
		if (GameManager.player == Player.ONE) {
			transform.position = oneSpawn.position;
		} else {
			transform.position = twoSpawn.position;
		}

		GameManager.OnPlayerSet -= OnGameReady;
	}
}
