using UnityEngine;

public class WinScript : MonoBehaviour
{
    private BoxCollider2D _boxCollider;
    private GameManager _gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();   
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
        _boxCollider.enabled = false;
        
        }   
        StartCoroutine(_gameManager.Victory());
    }
}
