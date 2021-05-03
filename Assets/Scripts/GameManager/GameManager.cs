using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum plaState {moving, climbing, inInv }
public class GameManager : MonoBehaviour
{
    public static GameManager acc;

    public InputManager Inp;
    public PlaManage PMng;
    public UIManage UIMng;

    public plaState curState;
    public plaState stateBeforeInv;

    //Debug

    //Debug

    private void Awake()
    {
        acc = this;
        curState = plaState.moving;

        
        
    }

    void Update()
    {
        PlaPreferences();
        DebugFunc();

        // Torch And Fear Behaviour
        TorchManager();

        // UI Behaviour
        UIManager();


        Debug.Log(curState);

        if(curState == plaState.moving)
        {
            #region While Moving
            PMng.rb.useGravity = true;

            // Look Around
            PMng.Cam.LookAround(Inp.MouseInput());

            // Jump
            PMng.Jump.Jump(PMng.rb);

            // Climb Ledge
            LedgeClimb();

            // Collect Item
            if (PMng.Collision.CheckForInteractable() != null)
                if (Inp.LetterInput() == "E")
                    PMng.Collect.CollectItem(PMng.Collision.CheckForInteractable());

            // Interact with Bonfire
            if(PMng.Collision.curBonfire != null)
                if(Inp.LetterInput() == "E")
                {
                    Debug.Log("Save Game");
                    PMng.Torch.torchIntesity = PMng.Torch.maxTorchIntesity;
                }
            #endregion
        }
        else if(curState == plaState.climbing)
        {
            #region While Climbing
            PMng.rb.useGravity = false;

            //Climb Ledge
            LedgeClimb();

            // Look Around
            PMng.Cam.LookAround(Inp.MouseInput());

            // Check If Player is On Ledge
            if (!PMng.Climb.isClimbing)
                if (!PMng.Collision.FrontLedgeCheck())
                {
                    curState = plaState.moving;
                }
            // Leave Ledge
            if (Inp.DashInput())
                curState = plaState.moving;

            // Ledge Jump
            if (Inp.JumpInput())
            {
                curState = plaState.moving;
                PMng.Jump.ClimbJump(PMng.rb, Inp.MovementInput().x);
            }
            #endregion
        }


    }

    void FixedUpdate()
    {
        if (curState == plaState.moving)
        {
            // Move
            PMng.Move.Move(PMng.rb, Inp.MovementInput());

            //Dash
            PMng.Dash.Dash(PMng.rb, Inp.MovementInput());
        }
        else if (curState == plaState.climbing)
        {
            // Ledge Move
            PMng.Move.ClimbMove(PMng.rb, Inp.MovementInput().x, PMng.Climb.curLedge);
        }

    }

    void LedgeClimb()
    {
        if (PMng.Collision.TopLedgeCheck() != null)
            if (Inp.LetterInput() == "C")
            {
                Debug.Log("Is Climbing");
                // LedgeCheck
                PMng.Climb.StartCoroutine("Climb", PMng.Collision.TopLedgeCheck());
                curState = plaState.climbing;
            }
    }

    void TorchManager()
    {
        PMng.Torch.SetTorchIntensity();
        PMng.Fear.UpdateFear();
    }

    void DebugFunc()
    {

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(PMng.transform.position, -Vector3.up * PMng.Jump.rayLength);
    }

    void PlaPreferences()
    {
        PMng.rb.angularVelocity = Vector3.zero;
    }

    void UIManager()
    {
        if (Inp.LetterInput() == "I")
        {
            if(curState != plaState.inInv)
                stateBeforeInv = curState;
            UIMng.StartCoroutine("HandelMap", false);
            UIMng.InvVisibility();
        }

        // Close Map
        if(UIMng.mapOpened)
            if(Inp.EscInput())
            {
                UIMng.StartCoroutine("HandelMap", false);
            }
            
    }


    





}
