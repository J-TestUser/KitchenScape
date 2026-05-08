using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

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
    private AudioSource _audioSource;
    private GameManager _gameManager;

    public AudioClip jump;
    public AudioClip deathSFX;
    public AudioClip shootSound;

    //Bullets 
    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    [SerializeField] bool _canShoot = false;
    [SerializeField] float _bulletAmount = 10;
    [SerializeField] float _powerUpTimer;

    //WallJump
    /*private bool isWallSliding;
    private float wallSlidingSpeed = 1f;
    [SerializeField] private Transform wallChecker;
    [SerializeField] private LayerMask wallLayer;
    */

    //Others
    private BGMManager _bgmManager;

    public ParticleSystem _walkParticles;

    void Awake()
    {
        rBody2D = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
        sensor = GetComponentInChildren<GroundSensor>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();

        _bgmManager = GameObject.Find("BGM Manager").GetComponent<BGMManager>();
        _gameManager = GameObject.Find ("GameManager").GetComponent<GameManager>();



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
            _walkParticles.Play();
            if(!_walkParticles.isPlaying && sensor.isGrounded)
            {
                _walkParticles.Play();
            }
        }

        else if (moveDirection.x < 0 )
        {
            transform.rotation = Quaternion.Euler(0,180,0);
            _animator.SetBool("IsWalking", true);
            _walkParticles.Play();
            if(!_walkParticles.isPlaying && sensor.isGrounded)
            {
                _walkParticles.Play();
            }
        }

        else
        {
            _animator.SetBool("IsWalking", false);
            if(_walkParticles.isPlaying && sensor.isGrounded)
            {
                _walkParticles.Stop();
            }
        }

        if (jumpAction.WasPressedThisFrame() && sensor.isGrounded)
        {
            rBody2D.AddForce(Vector2.up* jumpForce, ForceMode2D.Impulse);
            _audioSource.PlayOneShot(jump);
        }
        _animator.SetBool("IsJumping", !sensor.isGrounded);

        if (shootAction.WasPressedThisFrame() && _canShoot)
        {
            Shoot();
            StartCoroutine(StopShootAnimation());       
        }
        //IsWallSliding();
        

    void Shoot()
    {
        Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        ShootPowerUp();
    }

    /*void ShootPowerUp()
    {
        _powerUpTimer += Time.deltaTime;

        if(_powerUpTimer >= _bulletAmount)
        {
            _canShoot = false;
        }       
    }*/
    void ShootPowerUp()
    {
        _powerUpTimer ++;
        _audioSource.PlayOneShot(shootSound);


        if(_powerUpTimer >= _bulletAmount)
        {
            _canShoot = false;
        }       
    }
    IEnumerator StopShootAnimation()
    {
        _animator.SetBool("IsShooting", true);
        yield return new WaitForSeconds(0.1f);
        _animator.SetBool("IsShooting", false);
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
        _audioSource.PlayOneShot(deathSFX);
        rBody2D.constraints = RigidbodyConstraints2D.FreezePosition;
        _animator.SetTrigger("IsDead");
        sensor.enabled = false;
        _bgmManager.StopBGM();
        StartCoroutine(_gameManager.GameOver());
        Destroy (gameObject,4f);
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
            _powerUpTimer = 0;
            _canShoot = true;
        }
        

    }
}
