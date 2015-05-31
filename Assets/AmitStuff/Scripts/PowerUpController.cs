using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PowerUpController : MonoBehaviour {
	// variables START
	public enum PowerUp {HUGEWHEELS = 0, ACCELERATION = 1, STICKYGLUE = 2, EMPTY};

	[SerializeField] private PowerUp currentPowerUp;
	private bool[] powerUpsOn;

	// **** PowerUpSpecific Variables START
	// HUGEWHEELS
	public float lengthOfPowerUpHugeWheels = 5.0f;
	float HugeWheelsTimer;

	public GameObject[] otherPartsOfTheCar;
	private List<Vector3> OriginalPosoOtherPartsOfTheCar;
	private Vector3 lift;
	
	public GameObject LeftFrontWheel,LeftFrontMudGuard;
	private Vector3 OriginalPosLeftFrontWheel, OriginalScaleLeftFrontWheel, OriginalPosLeftFrontMudGuard, OriginalScaleLeftFrontMudGuard;
	public GameObject RightFrontWheel,RightFrontMudGuard;
	private Vector3 OriginalPosRightFrontWheel, OriginalScaleRightFrontWheel, OriginalPosRightFrontMudGuard, OriginalScaleRightFrontMudGuard;
	public GameObject LeftBackWheel;
	private Vector3 OriginalPosLeftBackWheel, OriginalScaleLeftBackWheel;
	public GameObject RightBackWheel;
	private Vector3 OriginalPosRightBackWheel, OriginalScaleRightBackWheel;
	
	private Vector3 originalScaleWheelLeft, originalScaleGuard;
	private Vector3 originalLocalPosWheel, originalLocalPosGuard;
	private Vector3 scaleTo;
	private Vector3 translateByLeftWheels;
	private Vector3 translateByRightWheels;
	bool grow, shrink;

	// ACCELERATION
	public float lengthOfPowerUpAcceleration = 5.0f;
	float AccelerationTimer;
	public float accelerationBoost = 1000.0f;

	// STICKYGLUE
	public float lengthOfPowerUpStickyGlue = 5.0f;
	float StickyGlueTimer;



	// **** PowerUpSpecific Variables END
	// variables END

	public void UseCurrentPowerUp() {
		switch (currentPowerUp) {
		case PowerUp.ACCELERATION:
			AccelerationTimer = 0.0f;
			powerUpsOn [(int)PowerUp.ACCELERATION] = true;
			break;
		case PowerUp.HUGEWHEELS:
			HugeWheelsTimer = 0.0f;
			powerUpsOn [(int)PowerUp.HUGEWHEELS] = true;
			break;
		case PowerUp.STICKYGLUE:
			StickyGlueTimer = 0.0f;
			powerUpsOn [(int)PowerUp.STICKYGLUE] = true;
			break;
		case PowerUp.EMPTY:
			// do nothing
			// TODO: maybe play a sound 
			break;
		}
		currentPowerUp = PowerUp.EMPTY;
	}
	
	public void AddPowerUp(PowerUp p) {
		currentPowerUp = p;
	}


	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.L)) {
			UseCurrentPowerUp();
		}
		DisplayCurrentPowerUp ();
		DoPowerUps ();
	}

	void DisplayCurrentPowerUp() {
		// TODO:
		switch (currentPowerUp) {
		case PowerUp.ACCELERATION:
			break;
		case PowerUp.HUGEWHEELS:
			break;
		case PowerUp.STICKYGLUE:
			break;
		case PowerUp.EMPTY:
			// do nothing
			// TODO: maybe play a sound 
			break;
		}
	}

	void DoPowerUps() {
		HugeWheelPowerUP ();
		AccelerationPowerUP ();
		StickyGluePowerUP ();
	}

	// HUGEWHEELS
	void HugeWheelPowerUP() {
		if (powerUpsOn [(int)PowerUp.HUGEWHEELS]) {

			Scale ();

			HugeWheelsTimer += Time.deltaTime;
			if (lengthOfPowerUpHugeWheels < HugeWheelsTimer) {
				HugeWheelsTimer = 1.0f;
				powerUpsOn [(int)PowerUp.HUGEWHEELS] = false;
			}
		} 
		else {
			if (HugeWheelsTimer != 0.0f) {
				Scale ();
				
				HugeWheelsTimer -= Time.deltaTime;
				if (0 > HugeWheelsTimer) {
					HugeWheelsTimer = 0.0f;
				}
			}
		}
	}

	void Scale() {
		ScaleWheel (LeftFrontWheel, translateByLeftWheels, OriginalPosLeftFrontWheel, scaleTo, OriginalScaleLeftFrontWheel);
		ScaleWheel (RightFrontWheel, translateByRightWheels, OriginalPosRightFrontWheel, scaleTo, OriginalScaleRightFrontWheel);
		ScaleMudGuard (LeftFrontMudGuard, translateByLeftWheels, OriginalPosLeftFrontMudGuard, scaleTo, OriginalScaleLeftFrontMudGuard);
		ScaleMudGuard (RightFrontMudGuard, translateByRightWheels, OriginalPosRightFrontMudGuard, scaleTo, OriginalScaleRightFrontMudGuard);
		
		ScaleWheel (LeftBackWheel, translateByLeftWheels, OriginalPosLeftBackWheel, scaleTo, OriginalScaleLeftBackWheel);
		ScaleWheel (RightBackWheel, translateByRightWheels, OriginalPosRightBackWheel, scaleTo, OriginalScaleRightBackWheel);
		
		int counter = 0;
		foreach (GameObject part in otherPartsOfTheCar) {
			LiftBody(part, lift, OriginalPosoOtherPartsOfTheCar[counter]);
			counter++;
		}
		
	}
	
	void LiftBody (GameObject body, Vector3 translateBy, Vector3 originalPosBody) {
		body.transform.localPosition = new Vector3 (
			Mathf.Lerp(originalPosBody.x, originalPosBody.x + translateBy.x, HugeWheelsTimer),
			Mathf.Lerp(originalPosBody.y, originalPosBody.y + translateBy.y, HugeWheelsTimer),
			Mathf.Lerp(originalPosBody.z, originalPosBody.z + translateBy.z, HugeWheelsTimer)
			);
	}
	
	
	void ScaleMudGuard(GameObject mudGuard, Vector3 translateBy, Vector3 originalPosGuard, Vector3 scaleBy, Vector3 originalScaleMudGuard) {
		mudGuard.transform.localScale = new Vector3 (
			Mathf.Lerp(originalScaleMudGuard.x, originalScaleMudGuard.x + scaleBy.x, HugeWheelsTimer),
			Mathf.Lerp(originalScaleMudGuard.y, originalScaleMudGuard.y + scaleBy.y, HugeWheelsTimer),
			Mathf.Lerp(originalScaleMudGuard.z, originalScaleMudGuard.z + scaleBy.z, HugeWheelsTimer)
			);
		mudGuard.transform.localPosition = new Vector3 (
			Mathf.Lerp(originalPosGuard.x, originalPosGuard.x + translateBy.x, HugeWheelsTimer),
			Mathf.Lerp(originalPosGuard.y, originalPosGuard.y + translateBy.y, HugeWheelsTimer),
			Mathf.Lerp(originalPosGuard.z, originalPosGuard.z + translateBy.z, HugeWheelsTimer)
			);
	}
	void ScaleWheel(GameObject wheel,  Vector3 translateBy, Vector3 originalPosWheel,  Vector3 scaleBy, Vector3 originalScaleWheel) {
		wheel.transform.localScale = new Vector3 (
			Mathf.Lerp(originalScaleWheel.x, originalScaleWheel.x + scaleBy.x, HugeWheelsTimer),
			Mathf.Lerp(originalScaleWheel.y, originalScaleWheel.y + scaleBy.y, HugeWheelsTimer),
			Mathf.Lerp(originalScaleWheel.z, originalScaleWheel.z + scaleBy.z, HugeWheelsTimer)
			);
		wheel.transform.localPosition = new Vector3 (
			Mathf.Lerp(originalPosWheel.x, originalPosWheel.x + translateBy.x, HugeWheelsTimer),
			Mathf.Lerp(originalPosWheel.y, originalPosWheel.y + translateBy.y, HugeWheelsTimer),
			Mathf.Lerp(originalPosWheel.z, originalPosWheel.z + translateBy.z, HugeWheelsTimer)
			);
		
	}

	// ACCELERATION
	void AccelerationPowerUP() {
		if (powerUpsOn [(int)PowerUp.ACCELERATION]) {
			UnityStandardAssets.Vehicles.Car.CarController.AccelerationPowerUp = accelerationBoost;
			AccelerationTimer += Time.deltaTime;
			if (lengthOfPowerUpAcceleration < AccelerationTimer) {
				powerUpsOn [(int)PowerUp.ACCELERATION] = false;
				UnityStandardAssets.Vehicles.Car.CarController.AccelerationPowerUp = 1.0f;
			}
		}
	}

	// STICKYGLUE
	void StickyGluePowerUP() {
		if (powerUpsOn [(int)PowerUp.STICKYGLUE]) {

			Debug.Log("IMPLEMENT STICKY GLUE");
			// TODO: set all objects on the lift to kinematic

			StickyGlueTimer += Time.deltaTime;
			if (lengthOfPowerUpStickyGlue < StickyGlueTimer) {
				powerUpsOn [(int)PowerUp.STICKYGLUE] = false;
			}
		}
	}


	// Initialize
	// Use this for initialization
	void Start () {
		currentPowerUp = PowerUp.EMPTY;

		powerUpsOn = new bool[3];
		for (int i = 0; i < 3; ++i) {
			powerUpsOn[i] = false;
		}
		
		InitializeHugeWheelVariables ();
		InitializeAccelerationVariables ();
		InitializeStickyGlueVariables ();
	}

	void InitializeHugeWheelVariables() {
		grow = shrink = false;
		
		OriginalPosoOtherPartsOfTheCar = new List<Vector3> ();
		foreach (GameObject part in otherPartsOfTheCar) {
			OriginalPosoOtherPartsOfTheCar.Add(part.transform.localPosition);
		}
		
		OriginalPosLeftFrontWheel = LeftFrontWheel.transform.localPosition;
		OriginalScaleLeftFrontWheel = LeftFrontWheel.transform.localScale;
		
		OriginalPosLeftFrontMudGuard = LeftFrontMudGuard.transform.localPosition;
		OriginalScaleLeftFrontMudGuard = LeftFrontMudGuard.transform.localScale;
		
		OriginalPosRightFrontWheel = RightFrontWheel.transform.localPosition;
		OriginalScaleRightFrontWheel = RightFrontWheel.transform.localScale;
		
		OriginalPosRightFrontMudGuard = RightFrontMudGuard.transform.localPosition;
		OriginalScaleRightFrontMudGuard = RightFrontMudGuard.transform.localScale;
		
		OriginalPosLeftBackWheel = LeftBackWheel.transform.localPosition;
		OriginalScaleLeftBackWheel = LeftBackWheel.transform.localScale;
		
		OriginalPosRightBackWheel = RightBackWheel.transform.localPosition;
		OriginalScaleRightBackWheel = RightBackWheel.transform.localScale;
		
		scaleTo = new Vector3 (3.0f, 3.0f, 3.0f);
		translateByLeftWheels = new Vector3 (-0.5f, 0.9f, 0.0f);
		translateByRightWheels = new Vector3 (0.5f, 0.9f, 0.0f);
		lift = new Vector3 (0.0f, 0.9f, 0.0f);
	}

	void InitializeAccelerationVariables() {
	}

	void InitializeStickyGlueVariables() {
	}
}
