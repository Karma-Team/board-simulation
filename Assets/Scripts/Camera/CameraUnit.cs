using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CameraUtils
{
    public abstract class CameraUnit : MonoBehaviour
    {
        protected Camera Cam;
        private bool _isActive;
        public void SwitchActivity(bool active)
        {
            _isActive = active;
            Cam.enabled = active;
        }

        protected void InitCamera()
        {
            Cam = gameObject.GetComponent<Camera>();
            if (Cam == null)
            {
                Debug.LogError("Can't find object Camera for CameraUnit...");
            }
        }
    }
}
