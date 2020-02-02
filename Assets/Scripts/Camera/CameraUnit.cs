using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CameraUtils
{
    public abstract class CameraUnit : MonoBehaviour
    {
        private Camera cam;
        private bool _isActive;
        public void SwitchActivity(bool active)
        {
            _isActive = active;
            cam.enabled = active;
        }

        protected void InitCamera()
        {
            cam = gameObject.GetComponent<Camera>();
            if (cam == null)
            {
                Debug.LogError("Can't find object Camera for CameraUnit...");
            }
        }
    }
}
