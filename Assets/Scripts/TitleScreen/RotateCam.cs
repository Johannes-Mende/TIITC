using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCam : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(0f, .2f, 0f);
    }
}
