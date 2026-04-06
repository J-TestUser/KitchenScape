using UnityEngine;

public class Bullets : MonoBehaviour

{
    private Rigidbody2D rBody;

    public float bulletSpeed = 15;

    void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rBody.AddForce(transform.right * bulletSpeed, ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            return;
        }
        Destroy(gameObject); 
    }


}
