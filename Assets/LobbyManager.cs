//using UnityEngine;
//using System.Collections;
//using UnityEngine.UI;
//using System.Collections.Generic;
//
//public class LevelButton {
//	public string roomName;
//	public bool isVisible;
//	public bool isOpen;
//
//	public LevelButton(string room_name){
//		roomName = room_name;
//	}
//}
//
//public class LobbyManager : MonoBehaviour {
//
//	[SerializeField] Text connection;
//	[SerializeField] Text versionNumberText;
//	public RoomButton[] buttonList;
//	public Transform buttonListContentPanel;
//	public GameObject levelButtonPrefab;
//	public GameObject lobbyPanel;
//	public GameObject connectionStatusPanel;
//	public string versionNumber;
//	public Camera lobbyCamera;
//
//	void Start () {
//		versionNumberText.text = "Version " + versionNumber;
//	}
//
//	void Update () {
//		if (PhotonNetwork.room != null) {
//			DebugStatus.connectionStatus = PhotonNetwork.room.ToString ();
//		}
//		GenerateLevelButtons ();
//	
//	}
//
//	void GenerateLevelButtons(){
//		RoomInfo[] rooms = PhotonNetwork.GetRoomList ();
//		foreach (RoomInfo room in rooms) 
//		{
//			bool makeRoom = true;
//			if(buttonList != null){
//				buttonList = buttonListContentPanel.GetComponentsInChildren<RoomButton>();
//				foreach(RoomButton button in buttonList)
//				{
//					if(button.nameOfRoomToJoin == room.name){
//						Debug.Log("Did not make "+room.name+", because it already exists");
//						makeRoom  = false;
//					}
//				}
//			}
//			if(makeRoom){
//				GameObject newButton = Instantiate(levelButtonPrefab) as GameObject;
//				RoomButton button = newButton.GetComponent<RoomButton>();
//				button.nameOfRoomToJoin = room.name;
//				newButton.transform.SetParent(buttonListContentPanel);
//
//			}
//		}
//	}
//	public void ConnectToLobby (){
//		connectionStatusPanel.SetActive(true);
//		StartCoroutine ("UpdateConnectionString");
//		PhotonNetwork.ConnectUsingSettings(versionNumber);
//	}
//	IEnumerator UpdateConnectionString()
//		while (true) {
//			//playersOnMasterText.text = "("+PhotonNetwork.countOfPlayersOnMaster.ToString()+"/20)";
//			connection.text = PhotonNetwork.connectionState.ToString();
//			yield return null;
//		}
//	}
//	void OnJoinedLobby(){
//		connectionStatusPanel.SetActive(false);
//		lobbyPanel.SetActive (true);
//	}
//	public void OnJoinedRoom(){
//		Debug.Log ("On Joined Room");
//	}
//	public void CreatRoom(string roomName){
//		PhotonNetwork.CreateRoom (roomName);
//	}
//	public void JoinARoom(string roomName, RoomOptions roomOptions){
//		StopCoroutine ("UpdateConnectionString");
//		PhotonNetwork.JoinOrCreateRoom (roomName, roomOptions, TypedLobby.Default);
//		lobbyCamera.enabled = false;
//	}
//	public void DisconnectFromTheLobby(){
//		PhotonNetwork.Disconnect ();
//	}
//}
