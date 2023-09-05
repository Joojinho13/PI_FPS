using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class CameraSwitch : MonoBehaviour
{   
    [SerializeField]
    private PlayerInput playerInput;
    [SerializeField]
    private int PrioridadeDaCamera = 10;



    private CinemachineVirtualCamera virtualCamera;
    private InputAction aimAction;
    // Start is called before the first frame update
    void Awake()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        aimAction = playerInput.actions["Aim"];
    }

    private void OnEnable()
    {
        aimAction.performed += _  => StartAim();
        aimAction.canceled += _ => CancelAim();
    }
     private void OnDisable()
    {
        aimAction.performed -= _  => StartAim();
        aimAction.canceled -= _ => CancelAim();
    }

    private void StartAim()
    {
        virtualCamera.Priority += PrioridadeDaCamera;
    }

    private void CancelAim()
    {
        virtualCamera.Priority -= PrioridadeDaCamera;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
