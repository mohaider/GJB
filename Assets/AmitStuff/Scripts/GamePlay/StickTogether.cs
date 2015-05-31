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
	float timer = 50.0f;
	void Update () {
		//if (stickedTogether && timer < Time.deltaTime * 2.1f) {
			//timer += Time.deltaTime;
		//}
	}

	FixedJoint temp;
	void OnTriggerEnter(Collider col) {
		//Debug.Log (col.name);

		if (stickedTogether) {
			if (col.name.Contains("Fork") || col.name.Contains("CrashBlocker")) {
				Debug.Log("Separate Sticked Together" + myJoint.ToString());
				if (myJoint != null) {
					Debug.Log("Separate Sticked Together2" + myJoint.ToString());
					Destroy(myJoint);
					//stickedTogether = false;
					//timer = 0.0f;
				}
			}
		} 
		else {
			if (/*timer > Time.deltaTime * 2.1f &&*/ col.name.Contains ("StickTop") && this.gameObject.name.Contains("StickBottom")) {

				if ((col.bounds.center - this.gameObject.GetComponent<Collider>().bounds.center).magnitude < 0.25f) {
					myJoint = parent.AddComponent<FixedJoint>();
					myJoint.connectedBody=col.transform.parent.gameObject.GetComponent<Rigidbody>();
					stickedTogether = true;
				}


			}
		}


	}
}
