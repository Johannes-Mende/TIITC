using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaCam : MonoBehaviour
{
    public Transform cam;
    [SerializeField] float mouseSensitivity;
    public void LookAround(Vector2 mouseInput)
    {
        Vector2 mouseOutput = mouseInput * mouseSensitivity * Time.deltaTime;
        cam.Rotate(-mouseOutput.y, 0f, 0f);
        transform.Rotate(0f, mouseOutput.x, 0f);
    }
}
