using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    NavMeshPath path;
    Rigidbody rb;
    public float speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        path = new NavMeshPath();
    }

    public void MoveTo(Vector3 target)
    {
        NavMesh.CalculatePath(transform.position, target, NavMesh.AllAreas, path);

        if (path.corners.Length > 0)
        {
            transform.LookAt(new Vector3(path.corners[1].x, transform.position.y, path.corners[1].z));
            rb.velocity = transform.forward * Time.fixedDeltaTime * speed;
            Debug.DrawLine(transform.position, path.corners[1]);
        }

    }
}
