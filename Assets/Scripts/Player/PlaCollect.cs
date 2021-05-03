using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaCollect : MonoBehaviour
{
    GameObject[] invSlots;
    public void CollectItem(GameObject item)
    {
        invSlots = GameManager.acc.UIMng.invSlots;

        for (int i = 0; i < invSlots.Length; i++)
        {
            if(invSlots[i].GetComponent<Image>().sprite == null)
            {
                GameManager.acc.UIMng.invSlots[i].GetComponent<Image>().sprite = item.GetComponent<CollectablesProperties>().col_Img;
                Destroy(item);
                break;
            }
        }
        
    }
}
