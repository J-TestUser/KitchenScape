using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{
    public Vector2 startPosition;
    public float movementSpeed = 5;
    public float jumpForce = 12;

    private BoxCollider2D _boxCollider;

    private InputAction moveAction;
    public Vector2 moveDirection;
    private InputAction jumpAction;
    private InputAction pauseAction;

    public Rigidbody2D rBody2D;
    private SpriteRenderer renderer;
    private GroundSensor sensor;

    void Awake()
    {
        rBody2D = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
        sensor = GetComponentInChildren<GroundSensor>();

        moveAction = InputSystem.actions["Move"];
        jumpAction = InputSystem.actions["Jump"]; 
    }
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = startPosition;
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = moveAction.ReadValue<Vector2>();

        if (moveDirection.x > 0 )
        {
            renderer.flipX = false;
        }

        if (moveDirection.x < 0 )
        {
            renderer.flipX = true;
        }

        if (jumpAction.WasPressedThisFrame() && sensor.isGrounded)
        {
            rBody2D.AddForce(Vector2.up* jumpForce, ForceMode2D.Impulse);
        }

    }
    void FixedUpdate()
    {
        rBody2D.linearVelocity = new Vector2(moveDirection.x * movementSpeed, rBody2D.linearVelocity.y);
    }
}
