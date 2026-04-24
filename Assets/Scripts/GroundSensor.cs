using UnityEngine;

public class GroundSensor : MonoBehaviour
{

    public bool isGrounded;
    public CharacterController _playerController;
    public BoxCollider2D[] _deathZone;


    //public LayerMask layers;

    void Awake()
    {
        _playerController = GetComponentInParent<CharacterController>();
        _deathZone = GameObject.Find("DeathZones").GetComponentsInChildren<BoxCollider2D>();
    }

    void OnTriggerEnter2D (Collider2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            isGrounded = true;
        }
        if(collision.gameObject.CompareTag("DeathZone"))
        {
            _playerController.Death();
            foreach (BoxCollider2D item in _deathZone)
            {
                item.enabled = false;
            }
        }
    }

    void OnTriggerStay2D (Collider2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            isGrounded = true;
        }
    }
    void OnTriggerExit2D (Collider2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
        isGrounded = false;
        }
    }
 
}
