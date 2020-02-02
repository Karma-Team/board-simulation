using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CameraUtils
{
    public abstract class CameraUnit : MonoBehaviour
    {
        private Camera _Cam;
        protected Camera Cam
        {
            get
            {
                if (_Cam == null)
                {
                    _Cam = gameObject.GetComponent<Camera>();
                    if (_Cam == null)
                    {
                        Debug.LogError("Can't find object Camera for CameraUnit.");
                        return null;
                    }
                }
                return _Cam;
            }
        }

        private bool _isActive;
        public void SwitchActivity(bool active)
        {
            _isActive = active;
            Cam.enabled = active;
        }
    }
}
