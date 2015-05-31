using UnityEngine;
using System.Collections;

public class SpeedPowerUp : MonoBehaviour {
	PowerUpController controller;
	
	void Start() {
		controller = GameObject.Find ("Car").GetComponent<PowerUpController> ();
	}
	
	void OnTriggerEnter(Collider col) {
		//		Debug.Log ("Collison");
		//		grow = true;
		
		Debug.Log ("Collision with ACCELERATION");
		controller.AddPowerUp (PowerUpController.PowerUp.ACCELERATION);
		
		//		col.gameObject.GetComponent<MeshRenderer> ().enabled = false;
		//		col.enabled = false;
	}
}
