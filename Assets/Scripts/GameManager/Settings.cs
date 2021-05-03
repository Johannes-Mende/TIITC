using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    [SerializeField] int fps = 30;
    [SerializeField] bool runsInBack;
    private void Awake()
    {
        Application.targetFrameRate = fps;
        Application.runInBackground = runsInBack;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
