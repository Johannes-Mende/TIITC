using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum plaState {moving, climbing, inInv }
public class GameManager : MonoBehaviour
{
    public static GameManager acc;

    public GameObject player;

    public InputManager Inp;
    public PlaManage PMng;
    public UIManage UIMng;
    public GameLogic GL;
    public SceneManager SM;

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

        if(curState == plaState.moving)
        {
            GL.WhileMoving();
        }
        else if(curState == plaState.climbing)
        {
            GL.WhileClimbing();
        }


    }

    void FixedUpdate()
    {
        if (curState == plaState.moving)
        {
            GL.FixedWhileMoving();
        }
        else if (curState == plaState.climbing)
        {
            GL.FixedWhileClimbing();
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
