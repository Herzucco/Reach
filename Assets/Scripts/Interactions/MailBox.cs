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
	private int times = 0;
	private byte[] b;

	protected virtual void Start(){
		photonView = GetComponent<PhotonView> ();
		GameManager.OnPlayerSet += OnGameReady;
		soundSource = GetComponent<AudioSource>();
	}

	[RPC]
	protected virtual void ListenMailBox(byte[] receivedByte){
		times++;
		if (times >= 2) {
			byte[] c = new byte[receivedByte.Length*2];
			for(int i = 0; i < c.Length; i++){
				if(i < receivedByte.Length){
					c[i] = b[i];
				}else{
					c[i] = receivedByte[i];
				}
			}
			receivedTexture = new Texture2D(1, 1);
			receivedTexture.LoadImage(c);
			isFull = true;
			snap = Camera.main.gameObject.GetComponent<PlayerSnap> ();
			snap.SetTexture(receivedTexture);
			
			soundSource.clip = outboxSound;
			soundSource.Play();
		}else{
			b = receivedByte;
		}

	}
	
	public virtual void TriggerMailBox(){
		snap = Camera.main.gameObject.GetComponent<PlayerSnap> ();
		if (snap.TextureToSend != null) {
			Debug.Log("RPC");
			Debug.Log(snap.TextureToSend.EncodeToPNG().Length);
			byte[] grotruk = snap.TextureToSend.EncodeToPNG();
			byte[] petitbidule = new byte[grotruk.Length/2];
			byte[] petitbidule2 = new byte[grotruk.Length/2];
			for(int i = 0; i < grotruk.Length/2; i++){
				petitbidule[i] = grotruk[i];
			} 

			for(int i = grotruk.Length/2 - 1; i < grotruk.Length; i++){
				petitbidule2[i] = grotruk[i];
			} 

			Debug.Log(petitbidule.Length);
			photonView.RPC("ListenMailBox", PhotonTargets.Others, petitbidule);
			photonView.RPC("ListenMailBox", PhotonTargets.Others, petitbidule2);
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
