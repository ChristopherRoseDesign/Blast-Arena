using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementUpgrade : MonoBehaviour {
//Indicates player controller script
	public PlayerController player;
//Indicates original speed of the object
	private float defMoveSpeed; 
//Indicated new movement speed
	private float upgradeSpeed = 600f;

//---------------------------------------------------------------
//	OnTriggerEnter()
// Called when colliders intersect
//
// Param:
//		Collider other - other colliding object
//
// Return:
//		Void
//---------------------------------------------------------------
	private void OnTriggerEnter (Collider other) {
//saves original speed of the object
		defMoveSpeed = other.GetComponent<PlayerController> ().movementSpeed;
//upgrade speed
		other.GetComponent<PlayerController> ().movementSpeed = upgradeSpeed;
//Hides object
		gameObject.SetActive(false);
//Calls function after set time
		Invoke ("ResetSpeed", 7);
	}
		
//---------------------------------------------------------------
//	ResetSpeed()
// Called when Invoke is triggered
//
// Param:
//		
// Return:
//		Void
//---------------------------------------------------------------
	private void ResetSpeed(){
		//reset speed back to original
		player.movementSpeed = defMoveSpeed;
		//Destroys the object
		Destroy(gameObject);
	}
}