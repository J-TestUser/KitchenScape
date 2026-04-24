using UnityEngine;

public class Coleccionables : MonoBehaviour
{
    private BoxCollider2D _boxCollider;
    private SpriteRenderer _renderer;
    private AudioSource _audioSource;
    public AudioClip _coinSound;
    public AudioClip _collectableSound;
    private GameManager _gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       _boxCollider = GetComponent<BoxCollider2D>();
       _renderer = GetComponent<SpriteRenderer>();
       _audioSource = GetComponent<AudioSource>();
       _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void GetCoin()
    {
        _audioSource.PlayOneShot(_coinSound);
        _boxCollider.enabled = false;
        _renderer.enabled = false;
        Destroy(gameObject, 1);
        _gameManager.AddCoins();
    }

    public void GetChocolate()
    {
        _audioSource.PlayOneShot(_collectableSound);
        _boxCollider.enabled = false;
        _renderer.enabled = false;
        Destroy(gameObject, 1);
        _gameManager.AddChocolate();
    }

    public void GetDonut()
    {
        _audioSource.PlayOneShot(_collectableSound);
        _boxCollider.enabled = false;
        _renderer.enabled = false;
        Destroy(gameObject, 1);
        _gameManager.AddDonut();
    }

    public void GetSweet()
    {
        _audioSource.PlayOneShot(_collectableSound);
        _boxCollider.enabled = false;
        _renderer.enabled = false;
        Destroy(gameObject, 1);
        _gameManager.AddSweet();
    }
}
