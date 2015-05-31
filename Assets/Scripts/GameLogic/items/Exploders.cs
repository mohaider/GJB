using UnityEngine;
using System.Collections;

public class Exploders : MonoBehaviour {
	public float explosiveForce;
	Rigidbody thisRigidBody;

	void Awake()
	{
		thisRigidBody = GetComponent<Rigidbody> ();
		if (thisRigidBody == null) {
			thisRigidBody = gameObject.AddComponent<Rigidbody>();
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void Explode()
	{

	}
}
