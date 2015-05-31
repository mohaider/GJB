using UnityEngine;
using System.Collections;

public class Despawner : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		Invoke ("Despawn", 1.5f);
	}
	
	void Despawn()
	{
		Destroy (gameObject);
	}
}
