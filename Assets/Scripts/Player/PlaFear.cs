using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlaFear : MonoBehaviour
{
    public float curFear;
    public float maxFear = 100f;

    public float addFear;
    public TextMeshProUGUI fear_txt;

    public PlaTorch Torch;

    public void UpdateFear()
    {

        if(Torch.torchIntesity > 800)
        {
            curFear -= addFear;
        }
        else if(Torch.torchIntesity > 600 && Torch.torchIntesity <= 800)
        {
            curFear += addFear;
        }
        else if (Torch.torchIntesity > 400 && Torch.torchIntesity <= 600)
        {
            curFear += addFear * 1.5f;
        }
        else if (Torch.torchIntesity > 200 && Torch.torchIntesity <= 400)
        {
            curFear += addFear * 2f;
        }
        else if(Torch.torchIntesity <= 200)
        {
            curFear += addFear * 3f;
        }
        curFear = Mathf.Clamp(curFear, 0f, 100f);
        fear_txt.text = ((int)curFear).ToString();
    }

    public void ResetFear()
    {

    }
}
