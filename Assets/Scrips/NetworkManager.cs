using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NetworkManager : MonoBehaviour {

	public Text conectionStatusText;

	void Start () {
		PhotonNetwork.autoJoinLobby = true;
		PhotonNetwork.ConnectUsingSettings("Zombie_A01");

	}

	void OnJoinedLobby()
	{
		RoomOptions ro = new RoomOptions (){isVisible = true, maxPlayers = 10};
		PhotonNetwork.JoinOrCreateRoom ("MainRoom", ro, TypedLobby.Default);
	}

	void OnJoinedRoom()
	{
		Debug.Log ("JoinedRoom");
	}

	void Update () {
		conectionStatusText.text = PhotonNetwork.connectionState.ToString ();
	
	}
}
