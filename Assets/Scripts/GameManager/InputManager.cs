using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] KeyCode run;
    [SerializeField] KeyCode dash;
    [SerializeField] KeyCode jump;
    [SerializeField] KeyCode esc;

    public Vector3 MovementInput()
    {
        Vector3 moveVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")).normalized;
        return moveVector;
        
    }

    public Vector2 MouseInput()
    {
        Vector2 mouseVector = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        return mouseVector;
    }

    public string LetterInput()
    {
        string key = Input.inputString.ToUpper();
        return key;
    }

    public bool RunInput()
    {
        if (Input.GetKey(run))
            return true;
        return false;
    }

    public bool DashInput()
    {
        if (Input.GetKey(dash))
            return true;
        return false;
    }

    public bool JumpInput()
    {
        if (Input.GetKeyDown(jump))
            return true;
        return false;
    }

    public bool EscInput()
    {
        if (Input.GetKeyDown(esc))
            return true;
        return false;
    }

}