﻿using System;
using UnityEngine;
using System.Collections;

/// <summary>
/// This script automatically connects to Photon (using the settings file), 
/// tries to join a random room and creates one if none was found (which is ok).
/// </summary>
public class NetworkInitializer : Photon.MonoBehaviour
{
	public GameObject UIRoot;
	public GameObject Scene;
	public byte Version = 1;
	
	private int playerCount = 0;
	private bool ConnectInUpdate = true;
	private bool endUpdate = false;
	private GameObject bails;
	private GameObject player;
	public virtual void Start()
	{
		PhotonNetwork.autoJoinLobby = false;    // we join randomly. always. no need to join a lobby to get the list of rooms.
		Screen.lockCursor = true;
	}
	
	public virtual void Update()
	{
		if (ConnectInUpdate && !PhotonNetwork.connected) {
			Debug.Log ("Update() was called by Unity. Scene is loaded. Let's connect to the Photon Master Server. Calling: PhotonNetwork.ConnectUsingSettings();");

			ConnectInUpdate = false;
			PhotonNetwork.ConnectUsingSettings (Version + "." + Application.loadedLevel);
			endUpdate = true;
		}else if (PhotonNetwork.connected && !endUpdate) {
			OnConnectedToMaster();
			endUpdate = true;
		}else if(endUpdate){
			int newCount = PhotonNetwork.playerList.Length;
			
			if(newCount < playerCount){
				PhotonNetwork.LeaveRoom();
				Application.LoadLevel("Deco");
				Screen.showCursor = true;
			}else if(newCount > playerCount && newCount > 1){
				UIRoot.SetActive(false);
				Scene.SetActive(true);

				if(player != null){
					player.SetActive(true);

				}
				if(bails != null){
					bails.SetActive(true);
					bails.GetComponent<TutoManager>().StartTuto();
				}

			}
			
			playerCount = newCount;
		}
	}
	
	// to react to events "connected" and (expected) error "failed to join random room", we implement some methods. PhotonNetworkingMessage lists all available methods!
	public virtual void OnConnectedToMaster()
	{
		if (PhotonNetwork.networkingPeer.AvailableRegions != null) Debug.LogWarning("List of available regions counts " + PhotonNetwork.networkingPeer.AvailableRegions.Count + ". First: " + PhotonNetwork.networkingPeer.AvailableRegions[0] + " \t Current Region: " + PhotonNetwork.networkingPeer.CloudRegion);
		Debug.Log("OnConnectedToMaster() was called by PUN. Now this client is connected and could join a room. Calling: PhotonNetwork.JoinRandomRoom();");
		PhotonNetwork.JoinRandomRoom();
		
	}
	
	public virtual void OnPhotonRandomJoinFailed()
	{
		Debug.Log("OnPhotonRandomJoinFailed() was called by PUN. No random room available, so we create one. Calling: PhotonNetwork.CreateRoom(null, new RoomOptions() {maxPlayers = 4}, null);");
		PhotonNetwork.CreateRoom(null, new RoomOptions() { maxPlayers = 2 }, null);
	}
	
	// the following methods are implemented to give you some context. re-implement them as needed.
	
	public virtual void OnFailedToConnectToPhoton(DisconnectCause cause)
	{
		Debug.LogError("Cause: " + cause);
	}
	
	public void OnJoinedRoom()
	{
		Debug.Log (PhotonNetwork.playerList.Length);
		if (PhotonNetwork.playerList.Length == 1) {
			GameManager.player = Player.ONE;
			Scene.SetActive(false);

			player = GameObject.FindGameObjectWithTag("Player");
			bails = FindObjectOfType<TutoManager>().gameObject;

			player.SetActive(false);
			bails.SetActive(false);
			Debug.Log(bails);
		} else {
			GameManager.player = Player.TWO;
		}
		
		Debug.Log("OnJoinedRoom() called by PUN. Now this client is in a room. From here on, your game would be running. For reference, all callbacks are listed in enum: PhotonNetworkingMessage");
	}
	
	public void OnJoinedLobby()
	{
		Debug.Log("OnJoinedLobby(). Use a GUI to show existing rooms available in PhotonNetwork.GetRoomList().");
	}
}
