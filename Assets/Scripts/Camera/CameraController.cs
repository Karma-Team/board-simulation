using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CameraUtils
{
    public class CameraController : MonoBehaviour
    {
        public CameraUnit[] cameras;
        private int cameraPointer;

        public
        // Start is called before the first frame update
        void Start()
        {
            cameraPointer = 0;
            if (cameras.Length == 0)
            {
                Debug.LogError("No camera found in CameraController");
            }

            foreach (CameraUnit cam in cameras)
            {
                cam.SwitchActivity(false);
            }
            cameras[cameraPointer].SwitchActivity(true);

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                cameras[cameraPointer].SwitchActivity(false);
                cameraPointer = (cameraPointer + 1) % cameras.Length;
                cameras[cameraPointer].SwitchActivity(true);
            }
        }
    }
}
