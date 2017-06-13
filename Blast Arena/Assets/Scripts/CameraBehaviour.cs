using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour {
//Indicates 1st object to follow
	public Transform player1;
//Indicates 2nd object to follow
	public Transform player2;
//Sets value of the margin on screen
	private const float distanceMargin = 2.0f;
//Middle point of the scene
	private Vector3 middlePoint;
//Sets reference of distance between players
	private float distanceBetweenPlayers;
//Sets reference to camera distance
	private float cameraDistance;
//Sets reference for aspect ratio
	private float aspectRatio;
//Sets reference for the tangent of the field of vision
	private float tanFov;

	//---------------------------------------------------------------
	//	Start()
	// Called when the round begins
	//
	// Param:
	//		
	// Return:
	//		Void
	//---------------------------------------------------------------
	void Start() {
		//Locks aspect ratio
		aspectRatio = Screen.width / Screen.height;
		tanFov = Mathf.Tan(Mathf.Deg2Rad * Camera.main.fieldOfView/ 2.0f);
	}

	//---------------------------------------------------------------
	//	Update()
	// Called every new frame
	//
	// Param:
	//		
	// Return:
	//		Void
	//---------------------------------------------------------------
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
		cameraDistance = (distanceBetweenPlayers / aspectRatio) / tanFov;

		//Moves camera to the new position
		Vector3 focus = (Camera.main.transform.position - middlePoint).normalized;
		Camera.main.transform.position = middlePoint + focus * (cameraDistance + distanceMargin);
	}
}