using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace CameraUtils
{
    public class CameraMast : CameraUnit
    {
        private RenderTexture renderTexture;

        private void CamCapture()
        {
            RenderTexture currentRT = RenderTexture.active;
            RenderTexture.active = Cam.targetTexture;

            Cam.Render();

            Texture2D Image = new Texture2D(Cam.targetTexture.width, Cam.targetTexture.height);
            Image.ReadPixels(new Rect(0, 0, Cam.targetTexture.width, Cam.targetTexture.height), 0, 0);
            Image.Apply();
            RenderTexture.active = currentRT;

            var Bytes = Image.EncodeToPNG();
            Destroy(Image);

            File.WriteAllBytes(Application.dataPath + "/output/capture.png", Bytes);
        }


        // Start is called before the first frame update
        void Start()
        {
            renderTexture = new RenderTexture(960, 480, 24);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && !GameController.Instance.IsPaused)
            {
                Debug.Log("Save capture");
                Cam.targetTexture = renderTexture;
                CamCapture();
                Cam.targetTexture = null;
            }
        }
    }
}
