using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //Monolithic
    private static GameController _instance;
    public static GameController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameController>();
                if (_instance == null)
                {
                    Debug.LogError("Can't find GameController instance.");
                    return null;
                }
            }
            return _instance;
        }
    }

    private bool _isPaused;
    public bool IsPaused
    {
        get => _isPaused;
        set => _isPaused = value;
    }

    private void SwitchPause()
    {
        IsPaused = !(IsPaused);
        if (IsPaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        Directory.CreateDirectory(Application.dataPath + "/../output");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("End application.");
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SwitchPause();
        }
    }
}
