using UnityEngine;

public class GroundSensor : MonoBehaviour
{

    public bool isGrounded;

    //public LayerMask layers;

    void OnTriggerEnter2D (Collider2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            isGrounded = true;
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


    void OnTriggerEnter2D (Collider2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            
        }
    }
 
}