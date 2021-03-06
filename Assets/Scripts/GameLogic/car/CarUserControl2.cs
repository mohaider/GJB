using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{

    [RequireComponent(typeof (CarController))]
    public class CarUserControl2 : MonoBehaviour
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
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float v = CrossPlatformInputManager.GetAxis("Vertical");
		
			float horizontalRightStick = CrossPlatformInputManager.GetAxis ("RT");
			float verticalRightStick = CrossPlatformInputManager.GetAxis ("LT")*-1f;
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
