using UnityEngine;
using System.Collections;

public class SetPhysicsMaterial : MonoBehaviour {
	public PhysicMaterial wood;
	public PhysicMaterial Cardboard;
	// Use this for initialization
	void Start () {
		GameObject[] moveableGO = GameObject.FindGameObjectsWithTag("Moveable");
		if (moveableGO != null) {	
			BoxCollider[] colliders;
			foreach (GameObject g in moveableGO) {
				if (g.name.Contains ("Wood")) {
					colliders = g.GetComponentsInChildren<BoxCollider> ();
					foreach (BoxCollider c in colliders) {
						c.material = wood;
					}
				} else if (g.name.Contains ("carton_small")) {
					colliders = g.GetComponentsInChildren<BoxCollider> ();
					foreach (BoxCollider c in colliders) {
						c.material = Cardboard;
					}
				}
			}
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
