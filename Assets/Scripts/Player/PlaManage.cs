using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaManage : MonoBehaviour
{
    public static PlaManage acc;

    public PlaClimb Climb;
    public PlaMove Move;
    public PlaDash Dash;
    public PlaJump Jump;
    public PlaCollision Collision;
    public PlaFear Fear;
    public PlaCollect Collect;
    public PlaTorch Torch;
    public PlaCam Cam;

    public Rigidbody rb;

    private void Awake()
    {
        acc = this;
    }

}
