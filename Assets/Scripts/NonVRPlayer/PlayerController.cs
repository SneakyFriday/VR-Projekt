using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

// Adds CharacterController automatically
[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float dashPower = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;

    private CharacterController _controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private Vector2 movementInput = Vector2.zero;
    private bool hasDashed;
    private bool isInteracting;
    public UnityEvent playerInteraction;
    

    private void Start()
    {
        _controller = gameObject.GetComponent<CharacterController>();
    }
    
    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    // Checkt, ob der Button für den Dash gedrückt wurde und setzt
    // hasDashed dementsprechend auf true (wurde gedrückt oder false (wurde nicht gedrückt)
    public void OnDash(InputAction.CallbackContext context)
    {
        hasDashed = context.action.triggered;
    }

    public void Interaction(InputAction.CallbackContext context)
    {
        isInteracting = context.action.triggered;
        if(isInteracting) playerInteraction.Invoke();
    }

    void Update()
    {
        groundedPlayer = _controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        
        Vector3 move = new Vector3(movementInput.x, 0, movementInput.y);
        _controller.Move(move * (Time.deltaTime * playerSpeed));

        // Jump Button for now...
        if (hasDashed && groundedPlayer)
        {
            // TODO: Change to Dash-Function
            //print("Dashing!");
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        _controller.Move(playerVelocity * Time.deltaTime);
    }
}