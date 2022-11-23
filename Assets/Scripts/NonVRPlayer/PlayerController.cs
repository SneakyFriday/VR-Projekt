using UnityEngine;
using UnityEngine.InputSystem;

// Adds CharacterController automatically
[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float dashPower = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;
    
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private Vector2 movementInput = Vector2.zero;
    private bool hasDashed = false;
    

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    // Liest über den context aus, in welche Richtung gedrückt wird
    // (hier Vector 2, also hoch/runter bzw. WASD wie in der Action-Map festgelegt)
    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    // Checkt, ob der Button für den Dash gedrückt wurde und setzt
    // hasDashed dementsprechend auf true (wurde gedrückt oder false (wurde nicht gedrückt)
    public void OnDash(InputAction.CallbackContext context)
    {
        //hasDashed = context.ReadValue<bool>();
        //hasDashed = context.action.triggered;
        //print("Is Dashing");
    }

    void Update()
    {
        // Checks if Player is on the Ground and allow to jump
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        // Setzt move je nach Richtung, in die gedrückt wird.
        // movementInput.y ist hier in den z-Vektor übergeben,
        // da in Unity die Z-Achse für Bewegungen nach links/rechts da ist.
        Vector3 move = new Vector3(movementInput.x, 0, movementInput.y);
        controller.Move(move * (Time.deltaTime * playerSpeed));

        // Jump Button for now...
        if (hasDashed && groundedPlayer)
        {
            // TODO: Change to Dash-Function
            print("Dashing!");
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}