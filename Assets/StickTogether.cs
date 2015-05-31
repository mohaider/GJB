using UnityEngine;
using System.Collections;

public class StickTogether : MonoBehaviour {

	GameObject parent;
	bool stickedTogether;
	FixedJoint myJoint;
	// Use this for initialization
	void Start () {
		parent = this.transform.parent.gameObject;
		stickedTogether = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	FixedJoint temp;
	void OnTriggerEnter(Collider col) {
		Debug.Log (col.name);

		if (stickedTogether) {
			if (col.name.Contains("Fork") || col.name.Contains("CrashBlocker")) {
				if (myJoint != null) {
					Destroy(temp);
					stickedTogether = false;
				}
			}
		} 
		else {
			if (col.name.Contains ("StickTop") && this.gameObject.name.Contains("StickBottom")) {
				Debug.Log((col.bounds.center - this.gameObject.GetComponent<Collider>().bounds.center).magnitude);
				if ((col.bounds.center - this.gameObject.GetComponent<Collider>().bounds.center).magnitude < 0.25f) {
					myJoint = parent.AddComponent<FixedJoint>();
					myJoint.connectedBody=col.transform.parent.gameObject.GetComponent<Rigidbody>();
					stickedTogether = true;
				}


			}
		}


	}
}
