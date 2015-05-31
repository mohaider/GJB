using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
	
	[RequireComponent(typeof (CarController))]
	public class CarUserControl2Player2 : MonoBehaviour
	{
		private ConfigurableJoint cj ;
		private CarController m_Car; // the car controller we want to use
		public bool UsingKeyboard;
		
		private void Awake()
		{
			// get the car controller
			m_Car = GetComponent<CarController>();
			cj = GetComponent<ConfigurableJoint> ();
			GameObject oj = GameObject.FindGameObjectWithTag ("Fork");
			cj.connectedBody = oj.GetComponent<Rigidbody> ();
		}
		
		
		private void FixedUpdate()
		{
			// pass the input to the car!
			float h = CrossPlatformInputManager.GetAxis("HorizontalPlayer2");
			float v = CrossPlatformInputManager.GetAxis("VerticalPlayer2");
			
			float horizontalRightStick = CrossPlatformInputManager.GetAxis ("Player2RT");
			float verticalRightStick = CrossPlatformInputManager.GetAxis ("Player2LT")*-1f;
			float output = horizontalRightStick + verticalRightStick;
			Debug.Log ("hv " +horizontalRightStick);
			Debug.Log ("vv "+verticalRightStick);
			#if !MOBILE_INPUT
			float handbrake = CrossPlatformInputManager.GetAxis("Jump");
			if(!UsingKeyboard)
				m_Car.Move(h, output, output, handbrake);
			else
				m_Car.Move(h, v, v, handbrake);
			#else
			m_Car.Move(h, v, v, 0f);
			#endif
		}
	}
}