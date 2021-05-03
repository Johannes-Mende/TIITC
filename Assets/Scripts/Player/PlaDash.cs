using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaDash : MonoBehaviour
{
    public float dashForce;
    public float dashCooldown;
    public float dashTimer;
    public void Dash(Rigidbody rb, Vector3 dir)
    {
        if (dashTimer <= 0 && GameManager.acc.Inp.DashInput() && dir.magnitude != 0)
        {
            Vector3 dashVector = transform.forward * dir.z + transform.right * dir.x;
            rb.AddForce(dashVector * dashForce, ForceMode.Impulse);
            dashTimer = dashCooldown;
        }
        else if(dashTimer > 0)
            dashTimer -= Time.deltaTime;
        
    }
}
