using UnityEngine;
using System.Collections;

public class ForkLiftController : MonoBehaviour {

	private Vector3 botPos = new Vector3(0.0f, 0.1f, 1.16f);
	private Vector3 topPos = new Vector3(0.0f, 2.7f, 1.16f);
	private float distanceBetweenTopBot;
	private float ratio;

	private Vector3 currentPos;
	private float liftMoveTimer;
//	private int gear;
//	private float powerUpwards, powerDownwards;

	private Rigidbody forkLiftRigidBody;

	bool upPressed, downPressed;
	// Use this for initialization
	void Start () {
		forkLiftRigidBody = this.gameObject.GetComponent<Rigidbody> ();

		distanceBetweenTopBot = (topPos - botPos).magnitude;
		upPressed = downPressed = false;

//		gear = 0;
//		shiftGearUp ();
	}

	// Update is called once per frame
	void FixedUpdate () {
//		if (Input.GetKeyDown (KeyCode.K)) {
//			shiftGearDown();
//		} else if (Input.GetKeyDown (KeyCode.L)) {
//			shiftGearUp();
//		}

		if (Input.GetKey (KeyCode.P) && Input.GetKey (KeyCode.O)) {
			upPressed = downPressed = false;
			return;
		}
		if (upPressed || downPressed) {
			forkLiftRigidBody.constraints = ~RigidbodyConstraints.FreezePosition;// | RigidbodyConstraints.FreezeRotation;

		} else {
			forkLiftRigidBody.constraints = RigidbodyConstraints.FreezePositionY;// | RigidbodyConstraints.FreezeRotation;
		}
		if (Input.GetKey(KeyCode.P)) {

			if (!upPressed) {
				upPressed = true;
				liftMoveTimer = 0.0f;
				currentPos = this.transform.localPosition;
				ratio = (topPos - currentPos).magnitude / distanceBetweenTopBot;
				ratio *= 5.0f;
			}
			MoveForkUp();

			liftMoveTimer += Time.deltaTime / ratio;
		}
		else if (Input.GetKeyUp(KeyCode.P)) {
			upPressed = false;
		}
		if (Input.GetKey (KeyCode.O)) {
			if (!downPressed) {
				downPressed = true;
				liftMoveTimer = 0.0f;
				currentPos = this.transform.localPosition;
				ratio =  (botPos - currentPos).magnitude / distanceBetweenTopBot;
				ratio *= 5.0f;
			}
			MoveForkDown();

			liftMoveTimer += Time.deltaTime / ratio;
		}
		else if (Input.GetKeyUp (KeyCode.O)) {
			downPressed = false;
		}
	}

//	void shiftGearDown() {
//		gear--;
//		if (gear < 1) {
//			gear = 1;
//		}
//		powerUpwards = 20.0f - Physics.gravity;
//		powerDownwards = 20.0f;
//	}
//
//	void shiftGearUp() {
//		gear++;
//
//		powerUpwards = 20.0f + Physics.gravity;
//		powerDownwards = 20.0f;
//	}

	void MoveForkUp() {
		forkLiftRigidBody.AddForce(Vector3.up * 20.0f, ForceMode.Acceleration);
		forkLiftRigidBody.velocity = Vector3.zero;
		forkLiftRigidBody.angularVelocity = Vector3.zero;
		
		//this.transform.localPosition = new Vector3(0.0f, Mathf.Lerp(currentPos.y, topPos.y, liftMoveTimer), 1.16f);
	}
	void MoveForkDown() {
		forkLiftRigidBody.AddForce(-Vector3.up * 20.0f);
		forkLiftRigidBody.velocity = Vector3.zero;
		forkLiftRigidBody.angularVelocity = Vector3.zero;

		//this.transform.localPosition = new Vector3(0.0f, Mathf.Lerp(currentPos.y, botPos.y, liftMoveTimer), 1.16f);
	}
}
