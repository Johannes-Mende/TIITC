using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTrigger : MonoBehaviour
{
    public float trapDuration;

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            GameManager.acc.curState = plaState.trapped;
            StartCoroutine("TrapActivated");
        }
    }

    IEnumerator TrapActivated()
    {
        // Close Animation

        yield return new WaitForSeconds(trapDuration);

        GameManager.acc.curState = plaState.moving;
    }
}
