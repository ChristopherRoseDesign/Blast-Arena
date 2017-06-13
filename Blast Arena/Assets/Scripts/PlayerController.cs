using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;
public class PlayerController : MonoBehaviour {
//Indicates a Rigidbody in the scene
	public Rigidbody rigidBody;
//Indicates controller in use
	public XboxController controller;
//Indicates the movement speed of the players
	public float movementSpeed = 180f;
//Indicates the players maximum speed
	public float maxSpeed = 30f;
//Set's rotation reference forward
	public Vector3 previousRotationDirection = Vector3.forward;
//Indicates bullet speed upon firing
	public float bulletSpeed = 20;
//Indicates a time limit between shots
	private float shootingTimer;
//Indicates how long the players need to wait until they can shoot again
	public float timeBetweenShots = 1f;
//Indicates the amount of health the players will have
	public int health = 99;
//Takes bullet prefab from speed
	public GameObject bulletPrefab;
//Indicates a moving object in scene
	public Transform bulletSpawnPoint;

//---------------------------------------------------------------
//	TakeDamage()
// Called when player is hit by a bullet
//
// Param:
//		int damageToTake - defines damage player will take
// Return:
//		Void
//---------------------------------------------------------------
	public void TakeDamage(int damageToTake){
		health = health - damageToTake;
	}

//---------------------------------------------------------------
//	Start()
// Called when the round begins
//
// Param:
//		
// Return:
//		Void
//---------------------------------------------------------------
	private void Start (){
		rigidBody = GetComponent<Rigidbody> ();
		shootingTimer = Time.time;
		}
		
//---------------------------------------------------------------
//	Update()
// Called on refresh
//
// Param:
//		
// Return:
//		Void
//---------------------------------------------------------------
	private void Update () {
		if (health <= 0) {
			Destroy (this.gameObject);
		}
		RotatePlayer ();
		FireGun ();
		MovePlayer ();
	}

//---------------------------------------------------------------
//	FireGun()
// Called when player uses relevant control, creating a bullet
//
// Param:
//		
// Return:
//		Void
//---------------------------------------------------------------
	private void FireGun (){
		if (XCI.GetAxis (XboxAxis.RightTrigger, controller) > 0.1) {
			if (Time.time - shootingTimer > timeBetweenShots) {
				GameObject GO = Instantiate (bulletPrefab, bulletSpawnPoint.position, Quaternion.identity) as GameObject;
				GO.GetComponent<Rigidbody> ().AddForce (transform.forward * 20, ForceMode.Impulse);
				Destroy (GO, 3);
				shootingTimer = Time.time;
				}
		}
	}

//---------------------------------------------------------------
//	MovePlayer()
// Called when player uses relevant control, moving the player
//
// Param:
//		
// Return:
//		Void
//---------------------------------------------------------------
	private void MovePlayer (){
		float axisX = XCI.GetAxis (XboxAxis.LeftStickX, controller);
		float axisZ = XCI.GetAxis (XboxAxis.LeftStickY, controller);
		Vector3 movement = new Vector3 (axisX, 0, axisZ);
		rigidBody.AddForce (movement * movementSpeed * Time.deltaTime);
		if (rigidBody.velocity.magnitude > maxSpeed) {
			rigidBody.velocity = rigidBody.velocity.normalized * maxSpeed;
		}
	}
//---------------------------------------------------------------
//	RotatePlayer()
// Called when player uses relevant control, rotating the player
//
// Param:
//		
// Return:
//		Void
//---------------------------------------------------------------
	private void RotatePlayer(){
		float rotateAxisX = XCI.GetAxis (XboxAxis.RightStickX, controller);
		float rotateAxisZ = XCI.GetAxis (XboxAxis.RightStickY, controller);

		Vector3 directionVector = new Vector3 (rotateAxisX, 0, rotateAxisZ);
		if (directionVector.magnitude < 0.1f) {
			directionVector = previousRotationDirection;
		}
		directionVector = directionVector.normalized;
		previousRotationDirection = directionVector;
		transform.rotation = Quaternion.LookRotation (directionVector);
	}
}