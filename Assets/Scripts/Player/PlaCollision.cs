using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaCollision : MonoBehaviour
{
    public Vector3 offset;
    public float climbRay;
    public float frontClimbRay;
    public LayerMask ledge_Msk;

    public LayerMask collectable_Msk;
    public float interactableScanRange;

    public GameObject curBonfire;

    public Transform TopLedgeCheck()
    {
        RaycastHit hit;
        bool isHit = Physics.Raycast(transform.position + transform.forward * .8f + offset, transform.up + offset, out hit, climbRay, ledge_Msk);

        if (isHit)
        {
            
            ClimbingPoint(hit);
            return hit.transform.GetChild(0).transform;
        }
            
        return null;
    }

    public bool FrontLedgeCheck()
    {
        return Physics.Raycast(transform.position + new Vector3(0f, .1f, 0f), transform.forward, frontClimbRay, ledge_Msk);
    }

    void ClimbingPoint(RaycastHit hit)
    {
        float climbPos = hit.point.x;
        Vector3 climbPoint = hit.transform.GetChild(0).position;
        hit.transform.GetChild(0).position = new Vector3(climbPos, climbPoint.y, climbPoint.z);



    }

    public GameObject CheckForInteractable()
    {
        Collider[] col = Physics.OverlapSphere(transform.position, interactableScanRange, collectable_Msk);
        if(col.Length > 0)
            return col[0].gameObject;
        return null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position + transform.forward * .8f + offset, transform.up * climbRay);
        Gizmos.DrawRay(transform.position + new Vector3(0f, .1f, 0f), transform.forward * frontClimbRay);
        Gizmos.DrawWireSphere(transform.position, interactableScanRange);
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("TextTrigger"))
            GameManager.acc.UIMng.Box.StartCoroutine("WriteTextLetters", col.GetComponent<TextTrigger>().textToWrite);
        else if(col.CompareTag("Bonfire"))
        {
            curBonfire = col.gameObject;
            col.GetComponent<Bonfire>().inRange = true;
        }
            
    }

    private void OnTriggerExit(Collider col)
    {
        if(col.CompareTag("Bonfire"))
        {
            curBonfire = null;
            col.GetComponent<Bonfire>().inRange = false;
        }

    }
}
