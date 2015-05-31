using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float h = Input.GetAxisRaw ("RT");
		Debug.Log ("RT " + h);
		float b = Input.GetAxisRaw ("LT");
		Debug.Log ("LT " + b);
	}
}
