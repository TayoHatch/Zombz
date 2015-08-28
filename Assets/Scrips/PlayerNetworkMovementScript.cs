using UnityEngine;
using System.Collections;

public class PlayerNetworkMovementScript : MonoBehaviour 
{
	Vector3 position;
	Quaternion rotation;
	float smoothing = 10f;
	PhotonView photonView;
	public GameObject camera;
	
	void Start () {
		photonView = GetComponent<PhotonView> ();
		if(photonView.isMine)
		{
			GetComponent<Rigidbody>().useGravity = true;
			//GetComponent<HealthStatusScript>().enabled = true;
			GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController>().enabled = true;
			camera.SetActive(true);
		}
		else{
			StartCoroutine("UpdateData");
		}
	}
	
	IEnumerator UpdateData()
	{
		while(true)
		{
			transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime * smoothing);
			transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * smoothing);
			yield return null;
		}
	}
	
	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if(stream.isWriting)
		{
			stream.SendNext(transform.position);
			stream.SendNext(transform.rotation);
		}
		else
		{
			position = (Vector3)stream.ReceiveNext();
			rotation = (Quaternion)stream.ReceiveNext();
		}
	}
}
