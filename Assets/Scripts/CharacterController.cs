using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{
    public Vector2 startPosition;
    public float movementSpeed = 5;
    public float jumpForce = 12;

    public Vector2 moveDirection;

    //InputActions
    private InputAction moveAction;
    private InputAction jumpAction;
    private InputAction shootAction;

    //Components
    private BoxCollider2D _boxCollider;
    public Rigidbody2D rBody2D;
    private SpriteRenderer renderer;
    private GroundSensor sensor;
    private Animator _animator;

    //Bullets 
    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    [SerializeField] bool _canShoot = false;
    [SerializeField] int _bulletAmount = 0;

    //WallJump
    /*private bool isWallSliding;
    private float wallSlidingSpeed = 1f;
    [SerializeField] private Transform wallChecker;
    [SerializeField] private LayerMask wallLayer;
    */

    //Others
    private BGMManager _bgmManager;

    void Awake()
    {
        rBody2D = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
        sensor = GetComponentInChildren<GroundSensor>();
        _animator = GetComponent<Animator>();
        _bgmManager = GameObject.Find("BGM Manager").GetComponent<BGMManager>();

        moveAction = InputSystem.actions["Move"];
        jumpAction = InputSystem.actions["Jump"];
        shootAction = InputSystem.actions["Attack"]; 
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
            transform.rotation = Quaternion.Euler(0,0,0);

            _animator.SetBool("IsWalking", true);
        }

        else if (moveDirection.x < 0 )
        {
            transform.rotation = Quaternion.Euler(0,180,0);

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

        if (shootAction.WasPressedThisFrame() && _canShoot)
        {
            Shoot();
        }
        //IsWallSliding();
        
        if(_canShoot)
        {
            ShootPowerUp();
        }

    void Shoot()
    {
        Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
    }

    void ShootPowerUp()
    {
        while(_bulletAmount > 0)
        {
            _bulletAmount--;
        }

        _canShoot = false;

            
    }
        

    }
    void FixedUpdate()
    {
        rBody2D.linearVelocity = new Vector2(moveDirection.x * movementSpeed, rBody2D.linearVelocity.y);
    }

    /*private bool IsWalled()
    {
        return Physics2D.OverlapCircle(wallChecker.position, 0.2f, wallLayer); //Creamos un criculo alrededor del wallchecker con un radio de 0.2 que devuleve true cuando si detecta el  layer Wall
    }
    */
    /*private void IsWallSliding()
    {
        if(IsWalled() && !sensor.isGrounded && moveDirection.x != 0f)
        {
            isWallSliding = true;
            rBody2D.linearVelocity = new Vector2(rBody2D.linearVelocity.x, Mathf.Clamp(rBody2D.linearVelocity.y, -wallSlidingSpeed, float.MaxValue));
        }
        else
        {
            isWallSliding = false;
        }
    }
    */
    public void Death()
    {
        
        movementSpeed = 0;
        rBody2D.constraints = RigidbodyConstraints2D.FreezePosition;
        _animator.SetTrigger("IsDead");
        sensor.enabled = false;
        _bgmManager.StopBGM();
        Destroy (gameObject,1f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Coin"))
        {
            Coleccionables _coin = collision.gameObject.GetComponent<Coleccionables>();
            _coin.GetCoin();
        }

        if(collision.gameObject.CompareTag("Chocolate"))
        {
            Coleccionables _chocolate = collision.gameObject.GetComponent<Coleccionables>();
            _chocolate.GetChocolate();
        }

        if(collision.gameObject.CompareTag("Donut"))
        {
            Coleccionables _donut = collision.gameObject.GetComponent<Coleccionables>();
            _donut.GetDonut();
        }

        if(collision.gameObject.CompareTag("Sweet"))
        {
            Coleccionables _sweet = collision.gameObject.GetComponent<Coleccionables>();
            _sweet.GetSweet();
        }
        
        if (collision.gameObject.CompareTag("PowerUp"))
        {
            _bulletAmount = 3;
            _canShoot = true;
        }
        

    }
}
