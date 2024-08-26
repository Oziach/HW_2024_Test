using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//'new' input system might be overkill for this project, but its technically better

public class GameInput : MonoBehaviour 
{
    public static GameInput Instance { get; private set; } //singleton

    PlayerInputActions playerInputActions;

    private void Awake() {

        //create singleton
        if (Instance) { 
            Destroy(gameObject); 
        }
        else {
            Instance = this; 
        }

        playerInputActions = new PlayerInputActions();
        playerInputActions.Enable();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public Vector2 GetMovementInputVector() {
        return playerInputActions.Default.Movement.ReadValue<Vector2>();
    }
}
