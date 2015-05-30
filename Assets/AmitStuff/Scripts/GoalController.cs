using UnityEngine;
using System.Collections;

public class GoalController : MonoBehaviour {

	public string tagOfScoreableObjects = "Moveable";
	float lengthX, lengthZ;
	int score = 0;
	GameObject[] moveables;
	bool first = true;

	void Start() {
		moveables = GameObject.FindGameObjectsWithTag(tagOfScoreableObjects);
		lengthX = this.gameObject.GetComponent<Renderer> ().bounds.extents.x;
		lengthZ = this.gameObject.GetComponent<Renderer> ().bounds.extents.z;
	}

	void OnTriggerEnter(Collider col) {
		if (col.name.Contains ("Fork") && first) {
			Debug.Log("SCOREING");
			foreach(GameObject m in moveables) {
				if ((m.transform.position.x > this.transform.position.x - lengthX)
				    &&
				    (m.transform.position.x < this.transform.position.x + lengthX)
				    &&
				    (m.transform.position.z > this.transform.position.z - lengthZ)
				    &&
				    (m.transform.position.z < this.transform.position.z + lengthZ)
				   ) {
					score++;
				}
			}

			first = false;
		}
	}

	void OnGUI() {
		GUI.Box (new Rect (10.0f, 10.0f, 50.0f, 50.0f), score.ToString ());
	}
}
