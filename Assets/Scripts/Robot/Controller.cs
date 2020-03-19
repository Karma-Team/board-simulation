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
        private Rigidbody _body;
        public Rigidbody Body
        {
            get => _body;
        }

        private readonly float enginePower = 150.0f;
        private float power = 0.0f;
        private float _accelerator = 0.0f;
        public float Accelerator
        {
            get
            {
                return _accelerator;
            }
            set
            {
                _accelerator = value;
                power = _accelerator * enginePower * Time.deltaTime * 250.0f;
            }
        }
        private float brake = 0.0f;
        private bool _brake = false;
        public bool Brake
        {
            get
            {
                return _brake;
            }
            set
            {
                _brake = value;
                brake = _brake ? _body.mass * 0.1f : 0.0f;
            }
        }
        private float steer = 0.0f;
        private float _wheel = 0.0f;
        public float Wheel
        {
            get
            {
                return _wheel;
            }
            set
            {
                _wheel = value;
                steer = _wheel * maxSteer;
            }
        }

        private readonly float maxSteer = 25.0f;

        // Start is called before the first frame update
        void Start()
        {
            _body = GetComponent<Rigidbody>();
            //body.centerOfMass = new Vector3(0, -0.5f, 0.3f);

            // Load Aruco Code
            int ArucoSelected = Random.Range(1, 10);
            string ArucoPath = string.Format("ArucoCodes/aruco{0:d2}", ArucoSelected);
            Debug.Log("Selected Aruco code " + ArucoSelected + ", path: " + ArucoPath);
            Texture2D ArucoTex = Resources.Load<Texture2D>(ArucoPath);

            // Apply to Material
            Material ArucoRen = GetComponent<Renderer>().materials[0];
            ArucoRen.mainTexture = ArucoTex;

        }

        // Update is called once per frame
        void Update()
        {
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


