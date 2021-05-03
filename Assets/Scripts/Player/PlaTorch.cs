using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaTorch : MonoBehaviour
{
    public Light torch;
    public float torchIntesity;
    public float maxTorchIntesity;

    public float fadeVal;

    private void Start()
    {
        torchIntesity = maxTorchIntesity;
    }
    public void SetTorchIntensity()
    {
        if (torchIntesity > 200f)
            torchIntesity -= fadeVal;
        torch.intensity = torchIntesity;
    }
}
