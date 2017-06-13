using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSpawn : MonoBehaviour {
//Indicates spawn object
	public GameObject spawnObject;
//Time Between Spawns
	public float spawnTime = 15f;
//Selection of potential points
	public Transform[] spawnPoints;

//---------------------------------------------------------------
//	Start()
// Called when round starts
//
// Param:
//		
// Return:
//		Void
//---------------------------------------------------------------
	private void Start (){
//Calls the Spawn function after Spawn Time elapses, then repeats at set intervals of the spawn time
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
	}
//---------------------------------------------------------------
//	Spawn()
// Called upon intervals of the InvokeRepeating command
//
// Param:
//		
// Return:
//		Void
//---------------------------------------------------------------
	private void Spawn (){
//Finds a random index between zero and one less than the number of spawn points
		int spawnPointIndex = Random.Range (0, spawnPoints.Length);
//Creates an instance of a prefab object at a selected spawn point
		Instantiate (spawnObject, spawnPoints [spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
	}
}