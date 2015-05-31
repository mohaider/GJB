using UnityEngine;
using System.Collections;

public class StopDownSpeed : MonoBehaviour {
	ForkLiftController controller;
	void Start() {
		controller = GameObject.Find ("Fork").GetComponent<ForkLiftController> ();
	}
	
	void OnTriggerEnter(Collider col) {
		Debug.Log (col.name);
		if (col.tag.Equals ("Moveable") || col.transform.parent.tag.Equals("Moveable")) {
			Debug.Log("Stop Message Sent");
			controller.StopDownMovement();
		}
	}
}
