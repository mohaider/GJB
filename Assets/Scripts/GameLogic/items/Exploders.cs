using UnityEngine;
using System.Collections;

public class Exploders : MonoBehaviour {
	public float explosiveForce;
	public float explosiveRadius;
	private bool hasExploded =false;
	Rigidbody thisRigidBody;
	public GameObject explosionEffect;
	private LayerMask floorMask;
	public float sensitivity;
	private Vector3 velocity;

	void Awake()
	{
		Initialize ();
	}
	void Initialize()
	{
		thisRigidBody = GetComponent<Rigidbody> ();
		if (thisRigidBody == null) {
			thisRigidBody = gameObject.AddComponent<Rigidbody>();
		}
	}
	void Update()
	{
		velocity = thisRigidBody.velocity;
	}

	public void Explode()
	{
		if (!hasExploded) {
			var explosionPos =transform.position;
			var colliders = Physics.OverlapSphere(explosionPos,explosiveRadius);
			foreach(Collider col in colliders){
				var rb = col.GetComponent<Rigidbody>();
				if(rb != null)
				{	
					rb.AddExplosionForce(explosiveForce,explosionPos,explosiveRadius);
					Exploders xx =rb.GetComponent<Exploders>();
					if(xx !=null && rb != xx.GetComponent<Rigidbody>())
					{
						xx.SetToExplode();
					}
				}

			}
		

			hasExploded = true;
			Instantiate(explosionEffect,transform.position,Quaternion.identity);
			Invoke ("Despawn",0.5f);
		}
	
	}
	public void SetToExplode()
	{
		Initialize ();
		Explode ();
	}
	private void Despawn()
	{
		Destroy (gameObject);
	}

	void OnCollisionEnter(Collision col)
	{
		if (Vector3.Magnitude (velocity) > sensitivity) {
			Debug.Log(Vector3.Magnitude (velocity));
			Explode ();
		}

		else if (col.gameObject.layer == LayerMask.NameToLayer ("Floor")) {
			Debug.Log("boom goes the dynamite");

			Explode ();
		}
		Debug.Log (col.gameObject.layer);
		Debug.Log (col.gameObject.name);

	}
}
