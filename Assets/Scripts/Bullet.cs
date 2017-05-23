using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public int damage = 33;

	void Start () {
		Destroy (this.gameObject, 4f);
	}

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Player") {
			other.GetComponent<PlayerController> ().TakeDamage (damage);
		}
		Destroy (this.gameObject);
	}
}
