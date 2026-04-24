using UnityEngine;

public class Pizza : MonoBehaviour
{

    private Rigidbody2D _rigidBody;
    private BoxCollider2D _boxCollider;
    private AudioSource _audioSource;

    public AudioClip _deathSFX;

    public float movementSpeed = 4;
    public int direction = 1;
    private Animator _animator;

    private GameManager _gameManager;

    public Transform[] patrolPoints;
    public int patrolIndex = 0;

    private Transform playerPosition;
    public float detectionRange = 5;
    public float attackRange = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _boxCollider = GetComponent<BoxCollider2D>();
        _audioSource = GetComponent<AudioSource>();
        _animator = GetComponent<Animator>();
        
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distanceToPlayer = Vector3.Distance(playerPosition.position, transform.position);
        if(distanceToPlayer > detectionRange) // Condición que se ejecuta cuando la distancia hasta el jugador es mayor que el area de detección
        {
            Patrol(); //ejecutamos funcion Patrol
        }
        else if(distanceToPlayer < detectionRange && distanceToPlayer > attackRange)
        {
            FollowPlayer();
        }
        else if (distanceToPlayer < attackRange)
        {
            Attack();
        }
    }
    void Patrol()
    {
        float distanceToPoint = Vector3. Distance(transform.position, patrolPoints[patrolIndex].position);
        if (distanceToPoint <1f)
        {
            if (patrolIndex==0)
            {
                patrolIndex = 1;
            }
            else
            {
                patrolIndex = 0;
            }
        }
        Vector3 moveDirection = patrolPoints[patrolIndex].position - transform.position;
        Movement (moveDirection);
    }

    void FollowPlayer()
    {
        Vector3 moveDirection = playerPosition.position - transform.position;
        Movement(moveDirection);
    }

    void Movement(Vector3 moveDirection)
    {
        if (moveDirection.x < 0)
        {
            direction = -1;
            transform.rotation = Quaternion.Euler(0,180,0);
        }
        else if (moveDirection.x > 0)
        {
            direction = 1;
            transform.rotation = Quaternion.Euler(0,0,0);
        }

        _rigidBody.linearVelocity = new Vector2(direction * movementSpeed, _rigidBody.linearVelocity.y);

        _animator.SetBool("Is Walking", true);
    }
    void Attack()
    {
        direction = 0;

    Debug.Log("Atacando");
    }


}
