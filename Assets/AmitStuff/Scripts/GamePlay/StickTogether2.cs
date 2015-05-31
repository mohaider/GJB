using UnityEngine;
using System.Collections;

public class StickTogether2 : MonoBehaviour {
	
	GameObject parent;
	bool stickedTogether;
	FixedJoint myJoint;
	// Use this for initialization
	void Start () {
		parent = this.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	FixedJoint temp;
	void OnCollisionEnter(Collision col) {

			if (col.gameObject.name.Contains ("carton")) {

				parent.GetComponent<Rigidbody>().velocity = Vector3.zero;
				parent.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
				col.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
				col.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
				
			}
			else if (col.gameObject.name.Contains ("StickTop") || col.gameObject.name.Contains ("StickBottom")) {

				parent.GetComponent<Rigidbody>().velocity = Vector3.zero;
				parent.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
				col.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
				col.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
			}

		
		
	}
}
