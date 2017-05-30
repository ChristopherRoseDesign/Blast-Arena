using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;
public class PlayerController : MonoBehaviour {

	public Rigidbody rigidBody;
	public XboxController controller;

	public float movementSpeed = 30f;
	public float maxSpeed = 5f;
	public Vector3 previousRotationDirection = Vector3.forward;
	public float bulletSpeed = 20;
	private float shootingTimer;
	public float timeBetweenShots = 1f;

	public int health = 99;

	public GameObject bulletPrefab;
	public Transform bulletSpawnPoint;

	public void TakeDamage(int damageToTake){
		health = health - damageToTake;
	}
	void Start (){
		rigidBody = GetComponent<Rigidbody> ();
		shootingTimer = Time.time;
		}
		
	void Update () {
		if (health <= 0) {
			Destroy (this.gameObject);
		}
		RotatePlayer ();
		FireGun ();
		MovePlayer ();
	}

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

	private void MovePlayer (){
		float axisX = XCI.GetAxis (XboxAxis.LeftStickX, controller);
		float axisZ = XCI.GetAxis (XboxAxis.LeftStickY, controller);
		Vector3 movement = new Vector3 (axisX, 0, axisZ);
		rigidBody.AddForce (movement * movementSpeed);
		if (rigidBody.velocity.magnitude > maxSpeed) {
			rigidBody.velocity = rigidBody.velocity.normalized * maxSpeed;
		}
	}

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
	void OnTriggerEnter(Collider other){
//		Destroy (other.gameObject);
	}
}