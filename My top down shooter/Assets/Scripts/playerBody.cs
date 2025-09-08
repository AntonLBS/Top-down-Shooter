using UnityEngine;

public class platerBody : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] Transform player;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = (player.position - transform.position);
        rb.MovePosition(rb.position + dir);
    }
}

