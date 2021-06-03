using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum plaState {moving, climbing, inInv, attacked, trapped }
public class GameManager : MonoBehaviour
{
    public static GameManager acc;

    public GameObject player;

    public InputManager Inp;
    public PlaManage PMng;
    public UIManage UIMng;
    public GameLogic GL;

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

        // Torch And Fear Behaviour
        TorchManager();

        // UI Behaviour
        UIMng.UIManager();


        Debug.Log(curState);

        switch (curState)
        {
            case plaState.moving:
                GL.WhileMoving();
                break;

            case plaState.climbing:
                GL.WhileClimbing();
                break;

            case plaState.inInv:
                break;

            case plaState.attacked:
                GL.WhileAttacked();
                break;

            case plaState.trapped:
                break;
        }
    }

    void FixedUpdate()
    {
        switch (curState)
        {
            case plaState.moving:
                GL.FixedWhileMoving();
                break;
            case plaState.climbing:
                GL.FixedWhileClimbing();
                break;
            case plaState.inInv:
                break;
            case plaState.attacked:
                break;
            case plaState.trapped:
                break;
            default:
                break;
        }

        // Move Enemies
        GL.MoveActiveEnemies(player.transform);

    }

    void TorchManager()
    {
        PMng.Torch.SetTorchIntensity();
        PMng.Fear.UpdateFear();
    }

    void PlaPreferences()
    {
        PMng.rb.angularVelocity = Vector3.zero;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(PMng.transform.position, -Vector3.up * PMng.Jump.rayLength);
    }

}
