using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	//damage indicates how much health will be lost off the player, health found in PlayerController script
	public int damage = 33;

	//Called on initialization
	//Destroy - deletes object from scene
	void Start () {
		Destroy (this.gameObject, 4f);
	}
	//---------------------------------------------------------------------------------------------------------
	//Called on hitting another Collider
	void OnTriggerEnter (Collider other) {
		if (other.tag == "Player") {
			other.GetComponent<PlayerController> ().TakeDamage (damage);
		}
		Destroy (this.gameObject);
	}
}
