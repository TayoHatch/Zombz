using UnityEngine;
using System.Collections;

public class ShootingScript : MonoBehaviour {

	public GameObject bulletPrefab;
	public Transform bulletSpawnPoint;
	PhotonView photonView;

	void Start(){
		photonView = GetComponent<PhotonView> ();
	}

	void Update () {
		if (photonView.isMine && Input.GetButtonDown("Fire1"))
			photonView.RPC ("Shoot", PhotonTargets.AllViaServer);
	}
	[PunRPC]
	void Shoot(){
		Instantiate(bulletPrefab,bulletSpawnPoint.position,bulletSpawnPoint.rotation);
	}
}
