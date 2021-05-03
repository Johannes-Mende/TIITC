using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UIManage : MonoBehaviour
{
    public TextBox Box;

    public GameObject inventory;
    public GameObject map;
    public GameObject[] invSlots;

    public float mapSmooth;
    public float mapMaxSmooth;

    public bool mapOpened;

    public void InvVisibility()
    {

        switch (inventory.activeSelf)
        {
            case true:
                CursorUpdate(false, CursorLockMode.Locked);
                GameManager.acc.curState = GameManager.acc.stateBeforeInv;
                ResetPositions();
                break;

            case false:
                CursorUpdate(true, CursorLockMode.Confined);
                GameManager.acc.curState = plaState.inInv;
                break;
        }
    }

    public IEnumerator HandelMap(bool mapState) // true = open, false = close
    {
        inventory.transform.GetChild(0).gameObject.SetActive(!mapState);
        map.SetActive(mapState);
        mapOpened = mapState;

        if(mapState)
        {
            mapSmooth = 0;
            while (map.GetComponent<RectTransform>().localScale != Vector3.one)
            {
                map.GetComponent<RectTransform>().localScale = Vector3.Lerp(Vector3.zero, Vector3.one, mapSmooth / mapMaxSmooth);
                mapSmooth++;
                yield return null;
            }
        }

        yield return null;
    }

    void CursorUpdate(bool state, CursorLockMode mode)
    {
        inventory.SetActive(state);
        Cursor.lockState = mode;
        Cursor.visible = state;
    }

    void ResetPositions()
    {
        for (int i = 0; i < invSlots.Length; i++)
        {
            invSlots[i].GetComponent<RectTransform>().anchoredPosition = invSlots[i].GetComponent<CollectableUI>().origin;
            invSlots[i].GetComponent<RectTransform>().sizeDelta = invSlots[i].GetComponent<CollectableUI>().originScale;
            invSlots[i].GetComponent<CollectableUI>().zoomed = false;
            invSlots[i].SetActive(true);
        }

        map.GetComponent<RectTransform>().localScale = Vector3.zero;
    }
}
