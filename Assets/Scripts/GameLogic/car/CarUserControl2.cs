using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using Assets.Scripts.GameLogic.Controls;

namespace UnityStandardAssets.Vehicles.Car
{

    [RequireComponent(typeof (CarController))]
    public class CarUserControl2 : MonoBehaviour, IPausable
    {

        private CarController m_Car; // the car controller we want to use
		public bool UsingKeyboard;
		bool isPaused;

        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
			isPaused = false;
        }
		public void PauseSignal()
		{
			isPaused = !isPaused;
		}

        private void FixedUpdate()
        {
			if(!isPaused){
            // pass the input to the car!
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float v = CrossPlatformInputManager.GetAxis("Vertical");


			float horizontalRightStick = CrossPlatformInputManager.GetAxis ("RT");
			float verticalRightStick = CrossPlatformInputManager.GetAxis ("LT")*-1f;

			//Debug.Log (horizontalRightStick);
			//Debug.Log (verticalRightStick);
#if !MOBILE_INPUT
            float handbrake = CrossPlatformInputManager.GetAxis("Jump");
			if(!UsingKeyboard)
				m_Car.Move(h, verticalRightStick, verticalRightStick, handbrake);
			else
				m_Car.Move(h, v, v, handbrake);
#else
            m_Car.Move(h, v, v, 0f);
#endif
		}
        }

		public bool IsPaused{
			get{
				return isPaused;	
			}
			set {
				isPaused = value;
			}
		}
    }
}
