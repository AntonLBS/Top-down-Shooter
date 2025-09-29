using UnityEngine;

public class olleEnemyScript : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float olleSpeed = 1.0f;
    [SerializeField] int olleHealth = 5;
    Transform player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Vector2 dir = (player.position - transform.position).normalized;
            rb.MovePosition(rb.position + dir * olleSpeed * Time.fixedDeltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Bullet"))
        {
            if (olleHealth <= 1)
            {
                Destroy(gameObject);
            }
            else
            {
                olleHealth--;
                Debug.Log("olle health: " + olleHealth);
            }
        }
    }
}
