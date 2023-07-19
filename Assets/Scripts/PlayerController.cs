using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController), typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float initialPlayerSpeed = 4f;
    [SerializeField]
    private float maximumPlayerSpeed = 30f;
    [SerializeField]
    private float playerSpeedIncreaseRade = .1f;
    [SerializeField]
    private float jumpHeight = 1.0f;
    [SerializeField]
    private float initialGravityValue = 9.81f;
    [SerializeField]
    private LayerMask groundLayer;

    private float playerSpeed;
    private float gravity;
    private Vector3 movementDirection = Vector3.forward;

    private PlayerInput playerInput;
    private InputAction turnAction;
    private InputAction jumpAction;
    private InputAction slideAction;


    private CharacterController controller;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        controller = GetComponent<CharacterController>();
        turnAction = playerInput.actions["Turn"];
        jumpAction = playerInput.actions["Jump"];
        slideAction = playerInput.actions["Slide"];

    }

    private void OnEnable()
    {
        turnAction.performed += PlayerTurn;
        slideAction.performed += PlayerSlide;
        jumpAction.performed += PlayerJump;

    }

    private void OnDisable()
    {
        turnAction.performed -= PlayerTurn;
        slideAction.performed -= PlayerSlide;
        jumpAction.performed -= PlayerJump;

    }

    private void Start()
    {
        playerSpeed = initialGravityValue;
        gravity = initialGravityValue;
    }

    private void PlayerTurn(InputAction.CallbackContext context)
    {
        
    }
    private void PlayerSlide(InputAction.CallbackContext context)
    {

    }
    private void PlayerJump(InputAction.CallbackContext context)
    {

    }

    private void Update()
    {
        controller.Move(transform.forward * playerSpeed * Time.deltaTime);
    }



    private bool IsGrounded(float lenght)
    {
        Vector3 raycastOriginFirst = transform.position;
        raycastOriginFirst.y -= controller.height / 2f;
        raycastOriginFirst.y += .1f;

        Vector3 raycastOriginSecond = raycastOriginFirst;
        raycastOriginFirst -= transform.forward * .2f;
        raycastOriginSecond += transform.forward * .2f;

        if (Physics.Raycast(raycastOriginFirst, Vector3.down, out RaycastHit hit, lenght, groundLayer) || Physics.Raycast(raycastOriginSecond, Vector3.down, out RaycastHit hit2, lenght, groundLayer))
        {
            return true;
        }
        return false;

    } 
}

  
