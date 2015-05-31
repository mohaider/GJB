using UnityEngine;
using System.Collections;

public class GoalController : MonoBehaviour {

	public string tagOfScoreableObjects = "Moveable";
	public string[] tags = {"5", "10", "15", "20", "25"};
	float lengthX, lengthZ;
	int score = 0;
	GameObject[] moveables;
	GameObject[] score5;
	GameObject[] score10;
	GameObject[] score15;
	GameObject[] score20;
	GameObject[] score25;
	bool first = true;

	public string nextMap;
	public int nextMapInt;

	float nextMapTimer = 0.0f;
	bool nextmap = false;

	void Start() {
		moveables = GameObject.FindGameObjectsWithTag(tagOfScoreableObjects);

		score5 = GameObject.FindGameObjectsWithTag (tags [0]);
		score10 = GameObject.FindGameObjectsWithTag (tags [1]);
		score15 = GameObject.FindGameObjectsWithTag (tags [2]);
		score20 = GameObject.FindGameObjectsWithTag (tags [3]);
		score25 = GameObject.FindGameObjectsWithTag (tags [4]);

		lengthX = this.gameObject.GetComponent<Renderer> ().bounds.extents.x;
		lengthZ = this.gameObject.GetComponent<Renderer> ().bounds.extents.z;
	}

	void OnTriggerEnter(Collider col) {
		Debug.Log (col.name);
		if ((col.name.Contains ("Fork") || col.name.Contains("CrashBlocker")) && first) {
			Debug.Log("SCOREING");
			if (moveables.Length != 0) {
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
			}
			if (score5.Length != 0) {
				foreach(GameObject m in score5) {
					if ((m.transform.position.x > this.transform.position.x - lengthX)
					    &&
					    (m.transform.position.x < this.transform.position.x + lengthX)
					    &&
					    (m.transform.position.z > this.transform.position.z - lengthZ)
					    &&
					    (m.transform.position.z < this.transform.position.z + lengthZ)
					    ) {
						score+=5;
					}
				}
			}
			if (score10.Length != 0) {
				foreach(GameObject m in score10) {
					if ((m.transform.position.x > this.transform.position.x - lengthX)
					    &&
					    (m.transform.position.x < this.transform.position.x + lengthX)
					    &&
					    (m.transform.position.z > this.transform.position.z - lengthZ)
					    &&
					    (m.transform.position.z < this.transform.position.z + lengthZ)
					    ) {
						score+=10;
					}
				}
			}
			if (score15.Length != 0) {
				foreach(GameObject m in score15) {
					if ((m.transform.position.x > this.transform.position.x - lengthX)
					    &&
					    (m.transform.position.x < this.transform.position.x + lengthX)
					    &&
					    (m.transform.position.z > this.transform.position.z - lengthZ)
					    &&
					    (m.transform.position.z < this.transform.position.z + lengthZ)
					    ) {
						score+=15;
					}
				}
			}
			if (score20.Length != 0) {
				foreach(GameObject m in score20) {
					if ((m.transform.position.x > this.transform.position.x - lengthX)
					    &&
					    (m.transform.position.x < this.transform.position.x + lengthX)
					    &&
					    (m.transform.position.z > this.transform.position.z - lengthZ)
					    &&
					    (m.transform.position.z < this.transform.position.z + lengthZ)
					    ) {
						score+=20;
					}
				}
			}
			if (score25.Length != 0) {
				foreach(GameObject m in score25) {
					if ((m.transform.position.x > this.transform.position.x - lengthX)
					    &&
					    (m.transform.position.x < this.transform.position.x + lengthX)
					    &&
					    (m.transform.position.z > this.transform.position.z - lengthZ)
					    &&
					    (m.transform.position.z < this.transform.position.z + lengthZ)
					    ) {
						score+=25;
					}
				}
			}


			nextmap = true;
			first = false;
		}

		if (nextmap) {
			nextMapTimer += Time.deltaTime;
			if (nextMapTimer > 5.0f) {
				Application.LoadLevel(nextMapInt);
			}
		}
	}

	void OnGUI() {
		GUI.Box (new Rect (10.0f, 10.0f, 50.0f, 50.0f), score.ToString ());
	}
}
