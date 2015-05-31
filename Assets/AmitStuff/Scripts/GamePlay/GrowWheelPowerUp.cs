using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GrowWheelPowerUp : MonoBehaviour {

	
//	public GameObject[] otherPartsOfTheCar;
//	private List<Vector3> OriginalPosoOtherPartsOfTheCar;
//	private Vector3 lift;
//
//	public GameObject LeftFrontWheel,LeftFrontMudGuard;
//	private Vector3 OriginalPosLeftFrontWheel, OriginalScaleLeftFrontWheel, OriginalPosLeftFrontMudGuard, OriginalScaleLeftFrontMudGuard;
//	public GameObject RightFrontWheel,RightFrontMudGuard;
//	private Vector3 OriginalPosRightFrontWheel, OriginalScaleRightFrontWheel, OriginalPosRightFrontMudGuard, OriginalScaleRightFrontMudGuard;
//	public GameObject LeftBackWheel;
//	private Vector3 OriginalPosLeftBackWheel, OriginalScaleLeftBackWheel;
//	public GameObject RightBackWheel;
//	private Vector3 OriginalPosRightBackWheel, OriginalScaleRightBackWheel;
//	
//	private Vector3 originalScaleWheelLeft, originalScaleGuard;
//	private Vector3 originalLocalPosWheel, originalLocalPosGuard;
//	private Vector3 scaleTo;
//	private Vector3 translateByLeftWheels;
//	private Vector3 translateByRightWheels;
//	bool grow, shrink;
//
//	// Use this for initialization
//	void Start () {
//		grow = shrink = false;
//
//		OriginalPosoOtherPartsOfTheCar = new List<Vector3> ();
//		foreach (GameObject part in otherPartsOfTheCar) {
//			OriginalPosoOtherPartsOfTheCar.Add(part.transform.localPosition);
//		}
//
//		OriginalPosLeftFrontWheel = LeftFrontWheel.transform.localPosition;
//		OriginalScaleLeftFrontWheel = LeftFrontWheel.transform.localScale;
//
//		OriginalPosLeftFrontMudGuard = LeftFrontMudGuard.transform.localPosition;
//		OriginalScaleLeftFrontMudGuard = LeftFrontMudGuard.transform.localScale;
//
//		OriginalPosRightFrontWheel = RightFrontWheel.transform.localPosition;
//		OriginalScaleRightFrontWheel = RightFrontWheel.transform.localScale;
//		
//		OriginalPosRightFrontMudGuard = RightFrontMudGuard.transform.localPosition;
//		OriginalScaleRightFrontMudGuard = RightFrontMudGuard.transform.localScale;
//
//		OriginalPosLeftBackWheel = LeftBackWheel.transform.localPosition;
//		OriginalScaleLeftBackWheel = LeftBackWheel.transform.localScale;
//
//		OriginalPosRightBackWheel = RightBackWheel.transform.localPosition;
//		OriginalScaleRightBackWheel = RightBackWheel.transform.localScale;
//
//		scaleTo = new Vector3 (3.0f, 3.0f, 3.0f);
//		translateByLeftWheels = new Vector3 (-0.5f, 0.9f, 0.0f);
//		translateByRightWheels = new Vector3 (0.5f, 0.9f, 0.0f);
//		lift = new Vector3 (0.0f, 0.9f, 0.0f);
//	}
//	
//	// Update is called once per frame
//	float timer = 0.0f;
//	void Update () {
//		if (grow || shrink) {
//			Scale();
//		}
//
//		if (grow) {
//			timer += Time.deltaTime / 3.0f;
//			if (timer > 1.0f) {
//				timer = 1.0f;
//				shrink = true;
//				grow = false;
//			}
//		} 
//		else if (shrink) {
//			timer -= Time.deltaTime / 3.0f;
//			if (timer < 0.0f) {
//				timer = 0.0f;
//				shrink = false;
//				grow = true;
//			}
//		} 
//		else {
//		}
//
//	}
//
//	void Scale() {
//		ScaleWheel (LeftFrontWheel, translateByLeftWheels, OriginalPosLeftFrontWheel, scaleTo, OriginalScaleLeftFrontWheel);
//		ScaleWheel (RightFrontWheel, translateByRightWheels, OriginalPosRightFrontWheel, scaleTo, OriginalScaleRightFrontWheel);
//		ScaleMudGuard (LeftFrontMudGuard, translateByLeftWheels, OriginalPosLeftFrontMudGuard, scaleTo, OriginalScaleLeftFrontMudGuard);
//		ScaleMudGuard (RightFrontMudGuard, translateByRightWheels, OriginalPosRightFrontMudGuard, scaleTo, OriginalScaleRightFrontMudGuard);
//
//		ScaleWheel (LeftBackWheel, translateByLeftWheels, OriginalPosLeftBackWheel, scaleTo, OriginalScaleLeftBackWheel);
//		ScaleWheel (RightBackWheel, translateByRightWheels, OriginalPosRightBackWheel, scaleTo, OriginalScaleRightBackWheel);
//
//		int counter = 0;
//		foreach (GameObject part in otherPartsOfTheCar) {
//			LiftBody(part, lift, OriginalPosoOtherPartsOfTheCar[counter]);
//			counter++;
//		}
//
//	}
//
//	void LiftBody (GameObject body, Vector3 translateBy, Vector3 originalPosBody) {
//		body.transform.localPosition = new Vector3 (
//			Mathf.Lerp(originalPosBody.x, originalPosBody.x + translateBy.x, timer),
//			Mathf.Lerp(originalPosBody.y, originalPosBody.y + translateBy.y, timer),
//			Mathf.Lerp(originalPosBody.z, originalPosBody.z + translateBy.z, timer)
//		);
//	}
//
//
//	void ScaleMudGuard(GameObject mudGuard, Vector3 translateBy, Vector3 originalPosGuard, Vector3 scaleBy, Vector3 originalScaleMudGuard) {
//		mudGuard.transform.localScale = new Vector3 (
//			Mathf.Lerp(originalScaleMudGuard.x, originalScaleMudGuard.x + scaleBy.x, timer),
//			Mathf.Lerp(originalScaleMudGuard.y, originalScaleMudGuard.y + scaleBy.y, timer),
//			Mathf.Lerp(originalScaleMudGuard.z, originalScaleMudGuard.z + scaleBy.z, timer)
//			);
//		mudGuard.transform.localPosition = new Vector3 (
//			Mathf.Lerp(originalPosGuard.x, originalPosGuard.x + translateBy.x, timer),
//			Mathf.Lerp(originalPosGuard.y, originalPosGuard.y + translateBy.y, timer),
//			Mathf.Lerp(originalPosGuard.z, originalPosGuard.z + translateBy.z, timer)
//			);
//	}
//	void ScaleWheel(GameObject wheel,  Vector3 translateBy, Vector3 originalPosWheel,  Vector3 scaleBy, Vector3 originalScaleWheel) {
//		wheel.transform.localScale = new Vector3 (
//			Mathf.Lerp(originalScaleWheel.x, originalScaleWheel.x + scaleBy.x, timer),
//			Mathf.Lerp(originalScaleWheel.y, originalScaleWheel.y + scaleBy.y, timer),
//			Mathf.Lerp(originalScaleWheel.z, originalScaleWheel.z + scaleBy.z, timer)
//		);
//		wheel.transform.localPosition = new Vector3 (
//			Mathf.Lerp(originalPosWheel.x, originalPosWheel.x + translateBy.x, timer),
//			Mathf.Lerp(originalPosWheel.y, originalPosWheel.y + translateBy.y, timer),
//			Mathf.Lerp(originalPosWheel.z, originalPosWheel.z + translateBy.z, timer)
//		);
//
//	}

	PowerUpController controller;

	void Start() {
		controller = GameObject.Find ("Car").GetComponent<PowerUpController> ();
	}

	void OnTriggerEnter(Collider col) {
//		Debug.Log ("Collison");
//		grow = true;

		Debug.Log ("Collision with HUGEWHEELS");
		controller.AddPowerUp (PowerUpController.PowerUp.HUGEWHEELS);

//		col.gameObject.GetComponent<MeshRenderer> ().enabled = false;
//		col.enabled = false;
	}
}
