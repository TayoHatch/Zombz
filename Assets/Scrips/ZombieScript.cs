using UnityEngine;
using System.Collections;

public class ZombieScript : MonoBehaviour {

	public Material zombieMat;
	public GameObject gun;

	void OnEnable() {
		TurnZomb ();
	}

	void TurnZomb(){
		gun.SetActive (false);
		GetComponent<Renderer> ().material = zombieMat;
		foreach (Renderer rend in GetComponentsInChildren<Renderer>())
			rend.material = zombieMat;
	}
	// Update is called once per frame
	void Update () {
	
	}
}
