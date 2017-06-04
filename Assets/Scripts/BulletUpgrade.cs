using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletUpgrade : MonoBehaviour {

	public Bullet bullet;
	public PlayerController player;

	//Indicates new speed
	public float upgradeSpeed = 40;

	private float defMoveSpeed;

	//Calls on collision with another object
	void OnTriggerEnter (Collider other){

		//save original speed of the object
		defMoveSpeed = other.GetComponent<PlayerController> ().bulletSpeed;

		//upgrades speed to new value
		other.GetComponent<PlayerController> ().bulletSpeed = upgradeSpeed;

		//Hide object
		gameObject.SetActive (false);
	}
}

