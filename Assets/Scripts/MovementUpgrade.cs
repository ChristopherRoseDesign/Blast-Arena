using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementUpgrade : MonoBehaviour {


	public PlayerController player;

	private float defMoveSpeed; 

	private float upgradeSpeed = 200f;

	void OnTriggerEnter (Collider other) {
		defMoveSpeed = other.GetComponent<PlayerController> ().movementSpeed; //save default speed
		other.GetComponent<PlayerController> ().movementSpeed = upgradeSpeed;  //upgrade speed

		//Hide object
		gameObject.SetActive(false);

		Invoke ("ResetSpeed", 2); //Function name, then delay time
	}



	void ResetSpeed(){
		player.movementSpeed = defMoveSpeed; //reset speed
		Destroy(gameObject);
	}
}
