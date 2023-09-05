using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; //novo

[RequireComponent(typeof(CharacterController))]
public class CharController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity; //vetor para controlar nossa velocidade
    private bool groundedPlayer; //retorna se o jogador está no chão
    private Transform cameraTransform;


    [SerializeField]
    private float playerSpeed = 2.0f; // velocidade em si
     [SerializeField]
    private float jumpHeight = 1.0f; //altura do pulo
     [SerializeField]
    private float gravityValue = -9.81f; //gravidade

    private PlayerInput playerInput;  //novo
    private InputAction AimAction;    //novo
    private InputAction ShootAction;   //novo


    public GameObject CameraZoom;

    private InputManager inputManager;
    public int ray_distance;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        inputManager = InputManager.Instance;
        cameraTransform = Camera.main.transform;
        
        playerInput = GetComponent<PlayerInput>();  //novo
        AimAction = playerInput.actions["Aim"];    //novo
        ShootAction = playerInput.actions["Shoot"];     //novo

    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray,out hit, ray_distance))
            {
                Debug.Log(hit.transform.name);
                if(inputManager.PlayerShoot())
                {
                    if(hit.transform.gameObject.tag == "Enemy")
                    {
                        Debug.Log("Atirou");
                        Destroy(hit.transform.gameObject);
                    }
                }
            }

        groundedPlayer = controller.isGrounded;           //verificando se está no chão
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector2 movement = inputManager.GetPlayerMovement();
        Vector3 move = new Vector3(movement.x,0f,movement.y);
        move =  cameraTransform.forward * move.z + cameraTransform.right * move.x;  //rotação do jogador
        move.y = 0f;
        controller.Move(move * Time.deltaTime * playerSpeed);    //fazendo a movimentação do jogador

     

        // faz nosso jogador pular, movendo no eixo Y
        if (inputManager.PlayerJumped() && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);


        
    }
}