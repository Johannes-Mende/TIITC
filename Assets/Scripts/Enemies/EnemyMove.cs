using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    NavMeshPath path;
    Rigidbody rb;
    public float speed;
    public float jumpDistance;
    public float jumpHeight;

    bool jumped;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        path = new NavMeshPath();
    }

    public void MoveTo(Transform target)
    {
        NavMesh.CalculatePath(transform.position, target.position, NavMesh.AllAreas, path);

        if (path.corners.Length > 0)
        {
            transform.LookAt(new Vector3(path.corners[1].x, transform.position.y, path.corners[1].z));
            Vector3 moveDir = transform.forward * Time.fixedDeltaTime * speed;
            rb.velocity = new Vector3(moveDir.x, rb.velocity.y, moveDir.z);
            Debug.DrawLine(transform.position, path.corners[1]);

            if(Vector3.Distance(transform.position, target.position) < jumpDistance && !jumped)
            {
                rb.AddForce(new Vector3(0f, jumpHeight, 0f), ForceMode.Impulse);
                jumped = true;

                GameManager.acc.curState = plaState.attacked;
                GameManager.acc.GL.attacker = gameObject;
                StartCoroutine("ResetJump");
            }
        }

    }

    IEnumerator ResetJump()
    {
        yield return new WaitForSeconds(3f);
        jumped = false;

    }
}
