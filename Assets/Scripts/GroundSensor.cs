using UnityEngine;

public class GroundSensor : MonoBehaviour
{

    public bool isGrounded;

    public LayerMask layers;

    void OnTriggerEnter2D (Collider2D collision)
    {
        if(collision.gameObject.layer == layers)
        {
            isGrounded = true;
        }
        }

    void OnTriggerStay2D (Collider2D collision)
    {
        if(collision.gameObject.layer == layers)
        {
            isGrounded = true;
        }
    }
    void OnTriggerExit2D (Collider2D collision)
    {
        if(collision.gameObject.layer == layers)
        {
        isGrounded = false;
        }
    }
 
}