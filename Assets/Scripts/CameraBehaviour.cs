using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour {

	public Transform player1;
	public Transform player2;
	public PlayerController player;

	private const float distanceMargin = 1.0f;

	private Vector3 middlePoint;
	private float distanceFromMiddlePoint;
	private float distanceBetweenPlayers;
	private float cameraDistance;
	private float aspectRatio;
	private float fov;
	private float tanFov;

	//Calls on initialization
	void Start() {
		//Locks aspect ratio
		aspectRatio = Screen.width / Screen.height;
		tanFov = Mathf.Tan(Mathf.Deg2Rad * Camera.main.fieldOfView / 2.0f);
	}

	//Calls every new frame
	void Update () {
		//Positions the camera center of the scene
		Vector3 newCameraPos = Camera.main.transform.position;
		newCameraPos.x = middlePoint.x;
		Camera.main.transform.position = newCameraPos;

		//Finds the midpoint of the players
		Vector3 vectorBetweenPlayers = player2.position - player1.position;
		middlePoint = player1.position + 0.5f * vectorBetweenPlayers;

		//Calculates the new distance
		distanceBetweenPlayers = vectorBetweenPlayers.magnitude;
		cameraDistance = (distanceBetweenPlayers / 1.75f / aspectRatio) / tanFov;

		//Moves camera to the new position
		Vector3 focus = (Camera.main.transform.position - middlePoint).normalized;
		Camera.main.transform.position = middlePoint + focus * (cameraDistance + distanceMargin);
	}
}
