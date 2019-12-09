using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Robot
{
    public class Controller : MonoBehaviour
    {
        public WheelCollider FrontLeftWheel;
        public WheelCollider FrontRightWheel;
        public WheelCollider RearLeftWheel;
        public WheelCollider RearRightWheel;
        private Rigidbody body;

        private readonly float enginePower = 150.0f;
        private float power = 0.0f;
        private float brake = 0.0f;
        private float steer = 0.0f;
        private readonly float maxSteer = 25.0f;

        // Start is called before the first frame update
        void Start()
        {
            body = GetComponent<Rigidbody>();
            //body.centerOfMass = new Vector3(0, -0.5f, 0.3f);
        }

        // Update is called once per frame
        void Update()
        {
            power = Input.GetAxis("Vertical") * enginePower * Time.deltaTime * 250.0f;
            steer = Input.GetAxis("Horizontal") * maxSteer;
            brake = Input.GetKey("space") ? body.mass * 0.1f : 0.0f;

            FrontLeftWheel.steerAngle = steer;
            FrontRightWheel.steerAngle = steer;

            if (brake > 0.0)
            {
                FrontLeftWheel.brakeTorque = brake;
                FrontRightWheel.brakeTorque = brake;
                RearLeftWheel.brakeTorque = brake;
                RearRightWheel.brakeTorque = brake;
                RearLeftWheel.motorTorque = 0.0f;
                RearRightWheel.motorTorque = 0.0f;
            }
            else
            {
                FrontLeftWheel.brakeTorque = 0;
                FrontRightWheel.brakeTorque = 0;
                RearLeftWheel.brakeTorque = 0;
                RearRightWheel.brakeTorque = 0;
                RearLeftWheel.motorTorque = power;
                RearRightWheel.motorTorque = power;
            }

        }
}
}


