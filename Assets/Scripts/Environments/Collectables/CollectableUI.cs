using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CollectableUI : MonoBehaviour, IPointerClickHandler
{
    public Vector2 origin;
    public Vector2 originScale;
    public bool zoomed;

    public float smooth;
    public float maxSmooth;

    void Awake()
    {
        origin = GetComponent<RectTransform>().anchoredPosition;
        originScale = GetComponent<RectTransform>().sizeDelta;
    }
    public void OnPointerClick(PointerEventData pointer)
    {

        switch (zoomed)
        {
            case false:
                
                HideInvSlots(true);
                break;

            case true:
                HideInvSlots(false);
                break;
        }

    }

    

    void HideInvSlots(bool zoom)
    {
        for (int i = 0; i < GameManager.acc.UIMng.invSlots.Length; i++)
        {
            if (GameManager.acc.UIMng.invSlots[i] != this.gameObject)
            {
                GameManager.acc.UIMng.invSlots[i].SetActive(!zoom);
            }
        }
        ZoomInvSlot(zoom);
        zoomed = zoom;
    }

    void ZoomInvSlot(bool zoom)
    {
        switch (zoom)
        {
            case true:
                StartCoroutine(LerpSlot(origin, originScale, Vector2.zero, originScale * 2));
                break;

            case false:
                StartCoroutine(LerpSlot(Vector2.zero, originScale * 2, origin, originScale));
                break;
        }

    }

    public IEnumerator LerpSlot(Vector2 orgPos, Vector2 orgScale, Vector2 targPos, Vector2 targScale)
    {
        smooth = 0;
        if(zoomed)
        {
            while (GetComponent<RectTransform>().anchoredPosition != targPos || GetComponent<RectTransform>().sizeDelta != targScale)
            {
                GetComponent<RectTransform>().anchoredPosition = Vector2.Lerp(orgPos, targPos, smooth / maxSmooth);
                GetComponent<RectTransform>().sizeDelta = Vector2.Lerp(orgScale, targScale, smooth / maxSmooth);
                smooth++;
                yield return null;
            }
        }
        else if(!zoomed)
        {
            while (GetComponent<RectTransform>().anchoredPosition != targPos || GetComponent<RectTransform>().sizeDelta != targScale)
            {
                GetComponent<RectTransform>().anchoredPosition = Vector2.Lerp(orgPos, targPos, smooth / maxSmooth);
                GetComponent<RectTransform>().sizeDelta = Vector2.Lerp(orgScale, targScale, smooth / maxSmooth);
                smooth++;
                yield return null;
            }
        }
        

        yield return null;
    }

}
