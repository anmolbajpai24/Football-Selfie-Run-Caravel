using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private FloatingJoystick joystick;
    
    
    [SerializeField] private PlayerMover playerMover;
    [SerializeField] private bool guester;
    private Vector2 _joystickInputValue;


    private void Update()
    {
        if (guester == false)
        {
            playerMover.SetInputVector(joystick.Direction);
            
        }
        else
        {
            //playerMover.SetInputVector(GuesterInput());
        }
    }

    Vector2 GuesterInput()
    {
        if (Input.touchCount <= 0) return Vector2.zero;
        else
        {
            
            Vector2 gesterInputValue = Input.GetTouch(0).deltaPosition;
            if (gesterInputValue.x > 1) return new Vector2(1,  0);
            else if (gesterInputValue.x < 1) return new Vector2(1,  0);
            else return Vector2.zero;
            
        }
    }
}