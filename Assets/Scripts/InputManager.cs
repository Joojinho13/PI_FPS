using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
  
     public InputAction fireAction;
    public InputAction lookAction;
    private static InputManager _instance;

   

    public static InputManager Instance {

        get
        {
            return _instance;
        }
    }
     private PlayerControls playerControls;
    void Awake()
    {
        
         //fireAction = playerControls.Player[3];    

        if(_instance != null && _instance !=this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        playerControls = new PlayerControls();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
    }

    private void OnEnable()
    {
            playerControls.Enable();

    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    public Vector2 GetPlayerMovement() // MOVIMENTO
    {
        return playerControls.Player.Movement.ReadValue<Vector2>();
    }
     public Vector2 GetMouseDelta()  // MOUSE
    {
        return playerControls.Player.Look.ReadValue<Vector2>();
    }
    public bool PlayerJumped()      // PULO
    {
        return playerControls.Player.Jump.triggered;
    }
    public bool PlayerAim()  // MIRA
    {
        return playerControls.Player.Aim.triggered;
    }
     public bool PlayerShoot()  //ATIRA
    {
        return playerControls.Player.Shoot.triggered;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
