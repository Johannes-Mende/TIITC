using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TestUpdate : MonoBehaviour
{
    public GameObject[] enemies;
    public Camera cam;
    public GameObject testBall;
    public LayerMask ground_Msk;
    public GameObject rbAgent;
    public NavMeshPath path;
    public float distanceBuffer;
    RaycastHit hit;
    public float pathing;
    public float speed;

    private void Start()
    {
        path = new NavMeshPath();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            
            if(Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit, 1000f, ground_Msk))
            {
                NavMesh.CalculatePath(rbAgent.transform.position, hit.point, NavMesh.AllAreas, path);
            }

        }

        if(path.corners.Length > 0)
        {
            float dist = Vector3.Distance(rbAgent.transform.position, path.corners[1]);
            pathing = dist;

            if(dist > distanceBuffer)
            {
                rbAgent.transform.LookAt(new Vector3(path.corners[1].x, rbAgent.transform.position.y, path.corners[1].z));
                rbAgent.GetComponent<Rigidbody>().velocity = rbAgent.transform.forward * speed * Time.deltaTime;
            }

        }



        if (path.corners.Length > 0)
            for (int i = 0; i < path.corners.Length - 1; i++)
            {
                Debug.DrawLine(path.corners[i], path.corners[i + 1], Color.red);
            }


    }

    private void OnDrawGizmos()
    {
        Ray r = cam.ScreenPointToRay(Input.mousePosition);
        Gizmos.DrawRay(r.origin, r.direction * 100f);
        
    }
}
