using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletUpgrade : MonoBehaviour {

	public Bullet bullet;
	public PlayerController player;
	public float upgradeSpeed = 40;
	private float defMoveSpeed;


	void OnTriggerEnter (Collider other)
	{
		defMoveSpeed = other.GetComponent<PlayerController> ().bulletSpeed; //save default speed
		other.GetComponent<PlayerController> ().bulletSpeed = upgradeSpeed;  //upgrade speed

		//Hide object
		gameObject.SetActive (false);
	}
}

