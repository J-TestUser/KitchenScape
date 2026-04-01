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

    private Animator _animator;

    void Awake()
    {
        rBody2D = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
        sensor = GetComponentInChildren<GroundSensor>();
        _animator = GetComponent<Animator>();

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

            _animator.SetBool("IsWalking", true);
        }

        else if (moveDirection.x < 0 )
        {
            renderer.flipX = true;

            _animator.SetBool("IsWalking", true);
        }

        else
        {
            _animator.SetBool("IsWalking", false);
        }

        if (jumpAction.WasPressedThisFrame() && sensor.isGrounded)
        {
            rBody2D.AddForce(Vector2.up* jumpForce, ForceMode2D.Impulse);
        }
        _animator.SetBool("IsJumping", !sensor.isGrounded);
        

    }
    void FixedUpdate()
    {
        rBody2D.linearVelocity = new Vector2(moveDirection.x * movementSpeed, rBody2D.linearVelocity.y);
    }
}
