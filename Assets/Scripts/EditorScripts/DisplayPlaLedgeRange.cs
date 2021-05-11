using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayPlaLedgeRange : MonoBehaviour
{
    [SerializeField] float rayLength;

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, Vector3.up * rayLength);
    }
}
