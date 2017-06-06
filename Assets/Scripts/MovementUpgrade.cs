using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementUpgrade : MonoBehaviour {


	public PlayerController player;

	private float defMoveSpeed; 

	//Indicated new movement speed
	private float upgradeSpeed = 600f;

	//Calls on collision with another object
	void OnTriggerEnter (Collider other) {
		
		//saves original speed of the object
		defMoveSpeed = other.GetComponent<PlayerController> ().movementSpeed;

		//upgrade speed
		other.GetComponent<PlayerController> ().movementSpeed = upgradeSpeed;

		//Hides object
		gameObject.SetActive(false);

		//Calls function after set time
		Invoke ("ResetSpeed", 7);
	}


	//Calls upon Invoke
	void ResetSpeed(){
		
		//reset speed back to original
		player.movementSpeed = defMoveSpeed;

		//Destroys the object
		Destroy(gameObject);
	}
}
