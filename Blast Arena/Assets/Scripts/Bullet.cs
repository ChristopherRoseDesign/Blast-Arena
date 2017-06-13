using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

//damage indicates how much health will be lost off the player, health found in PlayerController script
	public int damage = 33;

//---------------------------------------------------------------
//	Start()
// Called when game starts
//
// Param:
//	
//
// Return:
//		Void
//---------------------------------------------------------------
	 private void Start () {
//Destroys object after set time
		Destroy (this.gameObject, 4f);
	}

//---------------------------------------------------------------
//	OnTriggerEnter()
// Called when colliders intersect
// Param:
//		Collider other - upon collision with another collider
//
// Return:
//		Void
//---------------------------------------------------------------
	private void OnTriggerEnter (Collider other) {
//Deals damage to object if it has the correct tag
		if (other.tag == "Player") {
			other.GetComponent<PlayerController> ().TakeDamage (damage);
		}
//Destroys object on collision
		Destroy (this.gameObject);
	}
}