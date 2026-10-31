using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player; 
    public float speed = 3f; 
    private Rigidbody2D rb;
 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (player != null)
        {
            Vector2 newPosition = Vector2.MoveTowards(rb.position, player.position, speed * Time.fixedDeltaTime);
            rb.MovePosition(newPosition);
        }
    }
}
