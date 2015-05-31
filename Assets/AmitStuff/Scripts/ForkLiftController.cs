using UnityEngine;
using System.Collections;

public class ForkLiftController : MonoBehaviour {

	private Vector3 botPos = new Vector3(0.0f, 0.1f, 1.16f);
	private Vector3 topPos = new Vector3(0.0f, 2.7f, 1.16f);
	private float distanceBetweenTopBot;
	private float ratio;

	private Vector3 currentPos;
	private float liftMoveTimer;

	private Rigidbody forkLiftRigidBody;

	bool upPressed, downPressed;
	// Use this for initialization
	void Start () {
		forkLiftRigidBody = this.gameObject.GetComponent<Rigidbody> ();

		distanceBetweenTopBot = (topPos - botPos).magnitude;
		upPressed = downPressed = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.P) && Input.GetKey (KeyCode.O)) {
			upPressed = downPressed = false;
			return;
		}
		if (upPressed || downPressed) {
			forkLiftRigidBody.constraints = ~RigidbodyConstraints.FreezePosition;// | RigidbodyConstraints.FreezeRotation;

		} else {
			forkLiftRigidBody.constraints = RigidbodyConstraints.FreezePositionY;// | RigidbodyConstraints.FreezeRotation;
		}
		if (Input.GetButton("ForkliftUp")) {

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
		else if (Input.GetButtonUp("ForkliftUp")) {
			upPressed = false;
		}
<<<<<<< HEAD
		if (allowedDownMovement && Input.GetKey (KeyCode.O)) {
=======

		if (allowedDownMovement && Input.GetButton("ForkliftDown")) {
>>>>>>> origin/master
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
		else if (Input.GetButtonUp ("ForkliftDown")) {
			downPressed = false;
		}
	}

	void MoveForkUp() {
		allowedDownMovement = true;
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

	bool allowedDownMovement = false;
	public void StopDownMovement() {
		MoveForkUp ();
		allowedDownMovement = false;

	}
}
