using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShowMap : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData point)
    {
        GameManager.acc.UIMng.StartCoroutine("HandelMap", true);
    }
}
