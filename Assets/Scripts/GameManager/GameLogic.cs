using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public List<GameObject> activeEnemies;
    public GameObject attacker;


    public void LedgeClimb()
    {
        if (GameManager.acc.PMng.Collision.TopLedgeCheck() != null)
            if (GameManager.acc.Inp.LetterInput() == "C")
            {
                Debug.Log("Is Climbing");
                // LedgeCheck
                GameManager.acc.PMng.Climb.StartCoroutine("Climb", GameManager.acc.PMng.Collision.TopLedgeCheck());
                GameManager.acc.curState = plaState.climbing;
            }
    }

    public void WhileMoving()
    {
        GameManager.acc.PMng.rb.useGravity = true;

        // Look Around
        GameManager.acc.PMng.Cam.LookAround(GameManager.acc.Inp.MouseInput());

        // Jump
        GameManager.acc.PMng.Jump.Jump(GameManager.acc.PMng.rb);

        // Climb Ledge
        LedgeClimb();

        // Collect Item
        if (GameManager.acc.PMng.Collision.CheckForInteractable() != null)
            if (GameManager.acc.Inp.LetterInput() == "E")
                GameManager.acc.PMng.Collect.CollectItem(GameManager.acc.PMng.Collision.CheckForInteractable());

        // Interact with Bonfire
        if (GameManager.acc.PMng.Collision.curBonfire != null)
            if (GameManager.acc.Inp.LetterInput() == "E")
            {
                Debug.Log("Save Game");
                GameManager.acc.PMng.Torch.torchIntesity = GameManager.acc.PMng.Torch.maxTorchIntesity;
            }
    }

    public  void WhileClimbing()
    {
        GameManager.acc.PMng.rb.useGravity = false;

        //Climb Ledge
        LedgeClimb();

        // Look Around
        GameManager.acc.PMng.Cam.LookAround(GameManager.acc.Inp.MouseInput());

        // Check If Player is On Ledge
        if (!GameManager.acc.PMng.Climb.isClimbing)
            if (!GameManager.acc.PMng.Collision.FrontLedgeCheck())
            {
                GameManager.acc.curState = plaState.moving;
            }
        // Leave Ledge
        if (GameManager.acc.Inp.DashInput())
            GameManager.acc.curState = plaState.moving;

        // Ledge Jump
        if (GameManager.acc.Inp.JumpInput())
        {
            GameManager.acc.curState = plaState.moving;
            GameManager.acc.PMng.Jump.ClimbJump(GameManager.acc.PMng.rb, GameManager.acc.Inp.MovementInput().x);
        }
    }

    public void FixedWhileMoving()
    {
        // Move
        GameManager.acc.PMng.Move.Move(GameManager.acc.PMng.rb, GameManager.acc.Inp.MovementInput());

        //Dash
        GameManager.acc.PMng.Dash.Dash(GameManager.acc.PMng.rb, GameManager.acc.Inp.MovementInput());
    }

    public void FixedWhileClimbing()
    {
        // Ledge Move
        GameManager.acc.PMng.Move.ClimbMove(GameManager.acc.PMng.rb, GameManager.acc.Inp.MovementInput().x, GameManager.acc.PMng.Climb.curLedge);
    }

    public void WhileAttacked()
    {
        GameManager.acc.PMng.Cam.cam.LookAt(attacker.transform);
    }

    public void MoveActiveEnemies(Transform player)
    {
        for (int i = 0; i < activeEnemies.Count; i++)
        {
            activeEnemies[i].GetComponent<EnemyMove>().MoveTo(player);
        }
    }
}
