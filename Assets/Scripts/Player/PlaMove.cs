using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaMove : MonoBehaviour
{
    public float curSpeed;
    public float moveSpeed;
    public float runSpeed;

    public void Move(Rigidbody rb, Vector3 dir)
    {
        
        if (dir.magnitude != 0)
        {
            Run();
            Vector3 dirOut = (transform.forward * dir.z + transform.right * dir.x) * curSpeed * Time.fixedDeltaTime;
            rb.velocity = new Vector3(dirOut.x, rb.velocity.y, dirOut.z);
        }
        else
            rb.velocity = new Vector3(0f, rb.velocity.y, 0f);
    }

    public void ClimbMove(Rigidbody rb, float horDir, Transform ledge)
    {
        // Get Orientation of current ledge
        rb.velocity = ledge.right * horDir * curSpeed * Time.fixedDeltaTime;
    }

    void Run()
    {
        switch (GameManager.acc.Inp.RunInput())
        {
            case true:
                curSpeed = runSpeed;
                break;
            case false:
                curSpeed = moveSpeed;
                break;
        }
        
    }
}
