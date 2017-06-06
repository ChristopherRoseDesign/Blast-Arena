using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;
public class PlayerController : MonoBehaviour {

	public Rigidbody rigidBody;
	public XboxController controller;

	//Indicates the movement speed of the players
	public float movementSpeed = 90f;

	//Indicates the players maximum speed
	public float maxSpeed = 15f;


	public Vector3 previousRotationDirection = Vector3.forward;

	//Indicates bullet speed upon firing
	public float bulletSpeed = 20;

	private float shootingTimer;

	//Indicates how long the players need to wait until they can shoot again
	public float timeBetweenShots = 1f;

	//Indicates the amount of health the players will have
	public int health = 99;

	public GameObject bulletPrefab;
	public Transform bulletSpawnPoint;

	//Called whenever the player takes damage
	public void TakeDamage(int damageToTake){
		health = health - damageToTake;
	}

	//Called on initialization
	void Start (){
		rigidBody = GetComponent<Rigidbody> ();
		shootingTimer = Time.time;
		}
		
	//Called on new frame
	void Update () {
		if (health <= 0) {
			Destroy (this.gameObject);
		}
		RotatePlayer ();
		FireGun ();
		MovePlayer ();
	}

	//Called when player fires weapon
	//XCI and XboxAxis calls from XboxCtrrInput
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

	//Calls whenever the player moves
	private void MovePlayer (){
		float axisX = XCI.GetAxis (XboxAxis.LeftStickX, controller);
		float axisZ = XCI.GetAxis (XboxAxis.LeftStickY, controller);
		Vector3 movement = new Vector3 (axisX, 0, axisZ);
		rigidBody.AddForce (movement * movementSpeed * Time.deltaTime);
		if (rigidBody.velocity.magnitude > maxSpeed) {
			rigidBody.velocity = rigidBody.velocity.normalized * maxSpeed;
		}
	}

	//Calls whenever player turns
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