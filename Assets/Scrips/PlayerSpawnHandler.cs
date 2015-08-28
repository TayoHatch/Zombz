using UnityEngine;
using System.Collections;

public class PlayerSpawnHandler : MonoBehaviour {

	public GameObject playerPrefab;
	public int spawnHight = 0;

	void OnJoinedRoom()
	{
		StartCoroutine ("Spawn", 3.0f);
	}

	IEnumerator Spawn(float respawnTime)
	{
		yield return new WaitForSeconds (respawnTime);

		Vector3 spawnLocation = new Vector3 (Random.Range (-40, 40), spawnHight, Random.Range (-40, 40));
		PhotonNetwork.Instantiate (playerPrefab.name, spawnLocation, Quaternion.identity,0);
	}
}
