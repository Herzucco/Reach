using UnityEngine;
using System.Collections;

[RequireComponent(typeof (PhotonView))]
public class MailBox : ContextAction {
	
	public Renderer renderer;
	private PhotonView photonView;
	
	public override void Action ()
	{
		renderer.material.color = new Color (Random.Range (0f, 1f), Random.Range (0f, 1f), Random.Range (0f, 1f));
	}
}
