using UnityEngine;
using System.Collections;

public class Exploders : MonoBehaviour {
	public float explosiveForce;
	public float explosiveRadius;
	Rigidbody thisRigidBody;
	public GameObject explosionEffect;

	void Awake()
	{
		thisRigidBody = GetComponent<Rigidbody> ();
		if (thisRigidBody == null) {
			thisRigidBody = gameObject.AddComponent<Rigidbody>();
		}
	}


	public void Explode()
	{
		thisRigidBody.AddExplosionForce (explosiveForce, transform.position, explosiveRadius);
		Destroy (gameObject);
	}
}
