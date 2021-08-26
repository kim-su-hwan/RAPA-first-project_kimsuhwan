using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {
        private CarController m_Car; // the car controller we want to use

        float save_h;
        float save_v;

        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
        }


        private void FixedUpdate()
        {
            // pass the input to the car!
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float v = CrossPlatformInputManager.GetAxis("Vertical");

            if(Input.GetKey(KeyCode.LeftShift))
            {
                h *= 2;
                v *= 2;
            }

            /////////////////////////
            /*
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                
                v = save * 2;
            }
            else if(Input.GetKeyUp(KeyCode.LeftShift))
            {
                v = save;
            }
            */
            
#if !MOBILE_INPUT
            float handbrake = CrossPlatformInputManager.GetAxis("Jump");
            m_Car.Move(h, v, v, handbrake);
#else
            m_Car.Move(h, v, v, 0f);
#endif
        }
    }
}
