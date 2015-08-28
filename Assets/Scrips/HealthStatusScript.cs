using UnityEngine;
using System.Collections;

public class HealthStatusScript : MonoBehaviour {

	public int health;
	ZombieScript zombScript;
	PhotonView photonView;

	void Start () 
	{
		health = 100;
		photonView = GetComponent<PhotonView> ();
		zombScript = GetComponent<ZombieScript> ();
		bool startAsZombie = true;
		foreach (ZombieScript zombz in FindObjectsOfType<ZombieScript>())
			if (zombz.isActiveAndEnabled)
				startAsZombie = false;
		if (startAsZombie)
			photonView.RPC ("TurnZomb", PhotonTargets.AllBufferedViaServer);
	}
	
	[PunRPC]
	void TurnZomb()
	{
		zombScript.enabled = true;
	}
	[PunRPC]
	void GetHit(int damage){
		health -= damage;
		if (health <= 0)
			Die ();
	}
	void Die(){
		Destroy (gameObject);
	}
}
