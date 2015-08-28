using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float speed;
	public float lifeTime;
	public int damage;

	float age;

	void Start(){
		age = 0;
	}
	void Update () 
	{
		age += 1 * Time.deltaTime;
		if (age > lifeTime)
			Destroy (gameObject);
		transform.Translate (Vector3.forward * Time.deltaTime * speed);
	}
	void OnTriggerEnter(Collider other)
	{
		Debug.Log (other.name);
		if (other.GetComponent<PhotonView> ().isMine)
			other.GetComponent<PhotonView> ().RPC ("GetHit", PhotonTargets.AllBuffered,damage);
	}
}
