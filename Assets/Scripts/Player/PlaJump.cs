using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaJump : MonoBehaviour
{
    public float rayLength;
    public float jumpForce;
    public LayerMask ground_Msk;

    public void Jump(Rigidbody rb)
    {
        if (GameManager.acc.Inp.JumpInput() && IsGrounded())
            rb.AddForce(new Vector3(0f, jumpForce, 0f), ForceMode.Impulse);
    }

    public void ClimbJump(Rigidbody rb, float horDir)
    {
        Vector3 ledgeLeap = new Vector3(PlaManage.acc.Climb.curLedge.right.x * horDir, jumpForce, PlaManage.acc.Climb.curLedge.right.z * horDir);
        rb.AddForce(ledgeLeap, ForceMode.Impulse);
    }

    bool IsGrounded()
    {
        if (Physics.Raycast(transform.position, -Vector3.up, rayLength, ground_Msk))
            return true;
        return false;
    }
}
