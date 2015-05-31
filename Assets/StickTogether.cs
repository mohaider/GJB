using UnityEngine;
using System.Collections;

public class StickTogether : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.name.Contains ("WoodenPallet") || col.gameObject.name.Contains ("carton_small")) {
			gameObject.AddComponent<FixedJoint>();
			gameObject.GetComponent<FixedJoint>().connectedBody=col.rigidbody;

		}
	}
}
