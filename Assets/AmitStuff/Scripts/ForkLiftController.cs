using UnityEngine;
using System.Collections;

public class ForkLiftController : MonoBehaviour {

	Animator forkliftAnimation;
	// Use this for initialization
	void Start () {
		forkliftAnimation = GameObject.Find ("ForkLift_Animated").GetComponent<Animator> ();
	//	forkliftAnimation.Play ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
