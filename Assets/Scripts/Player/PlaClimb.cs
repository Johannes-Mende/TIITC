using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaClimb : MonoBehaviour
{
    public float smooth;
    public float maxSmooth;

    public Transform curLedge;
    Vector3 startPos;

    public bool isClimbing;
    public IEnumerator Climb(Transform ledge)
    {
        isClimbing = true;
        ResetClimb();
        curLedge = ledge;
        while(smooth < maxSmooth)
        {

            transform.position = Vector3.Lerp(startPos, ledge.position, smooth / maxSmooth);
            smooth++;
            yield return null;
        }

        if(curLedge.parent.gameObject.layer == 7)
        {
            Debug.Log("ClimbTop");
            
            for (int i = 0; i < ledge.childCount; i++)
            {
                ResetClimb();
                while (smooth < maxSmooth)
                {

                    transform.position = Vector3.Slerp(startPos, ledge.GetChild(i).position, smooth / maxSmooth);
                    smooth++;
                    yield return null;
                }

            }

            GameManager.acc.curState = plaState.moving;
        }

        isClimbing = false;
        yield return null;
    }

    

    void ResetClimb()
    {
        smooth = 0;
        startPos = transform.position;
    }
}
