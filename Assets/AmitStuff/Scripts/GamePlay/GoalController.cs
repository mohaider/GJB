using UnityEngine;
using System.Collections;

public class GoalController : MonoBehaviour {

	public string tagOfScoreableObjects = "Moveable";
	float lengthX, lengthZ;
	int score = 0;
	GameObject[] moveables;
	bool first = true;

	public string nextMap;

	float nextMapTimer = 0.0f;
	bool nextmap = false;

	void Start() {
		moveables = GameObject.FindGameObjectsWithTag(tagOfScoreableObjects);
		lengthX = this.gameObject.GetComponent<Renderer> ().bounds.extents.x;
		lengthZ = this.gameObject.GetComponent<Renderer> ().bounds.extents.z;
	}

	void OnTriggerEnter(Collider col) {
		Debug.Log (col.name);
		if ((col.name.Contains ("Fork") || col.name.Contains("CrashBlocker")) && first) {
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
			nextmap = true;
			first = false;
		}

		if (nextmap) {
			nextMapTimer += Time.deltaTime;
			if (nextMapTimer > 5.0f) {
				Application.LoadLevel(nextMap);
			}
		}
	}

	void OnGUI() {
		GUI.Box (new Rect (10.0f, 10.0f, 50.0f, 50.0f), score.ToString ());
	}
}
