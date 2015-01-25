using UnityEngine;
using System.Collections;

[RequireComponent(typeof (PhotonView))]
public class MailBox : ContextAction {
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

	public override void Action ()
	{
		if (isFull) {
			Debug.Log("Bouyou");

			isFull = false;
			snap = Camera.main.gameObject.GetComponent<PlayerSnap> ();
			snap.SetTexture(receivedTexture);
			ActionName = "Send";
			soundSource.clip = inboxSound;
			soundSource.Play();
		} else {
			Debug.Log("Incroyable");

			snap = Camera.main.gameObject.GetComponent<PlayerSnap> ();

			TriggerMailBox ();
		}
	}

	protected override void PlayerEnter(){
		if (isFull) {
			ActionName = "Read";
		} else {
			ActionName = "Send";
		}
	}

	[RPC]
	protected virtual void ListenMailBox(byte[] receivedByte){
		receivedTexture = new Texture2D(1, 1);
		receivedTexture.LoadImage(receivedByte);
		isFull = true;
		ActionName = "Read";

		soundSource.clip = outboxSound;
		soundSource.Play();
	}
	
	public virtual void TriggerMailBox(){
		if (snap.TextureToSend != null) {
			Debug.Log("olala");
			photonView.RPC("ListenMailBox", PhotonTargets.Others, snap.TextureToSend.EncodeToPNG());
		}
	}
		
	void OnGameReady(){
		if (GameManager.player == Player.ONE) {
			transform.position = oneSpawn.position;
		} else {
			transform.position = twoSpawn.position;
		}
	}
}
