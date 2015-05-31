using UnityEngine;
using System.Collections;

public class StickyGluePowerUp : MonoBehaviour {
	PowerUpController controller;
	
	void Start() {
		controller = GameObject.Find ("Car").GetComponent<PowerUpController> ();
	}
	
	void OnTriggerEnter(Collider col) {
		//		Debug.Log ("Collison");
		//		grow = true;
		
		Debug.Log ("Collision with STICKYGLUE");
		controller.AddPowerUp (PowerUpController.PowerUp.STICKYGLUE);
		
		//		col.gameObject.GetComponent<MeshRenderer> ().enabled = false;
		//		col.enabled = false;
	}
}
