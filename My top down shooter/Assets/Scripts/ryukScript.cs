using UnityEngine;

public class ryukScript : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float ryukSpeed = 1.0f;
    [SerializeField] int ryukHealth = 10;
    Transform player;
    [SerializeField] float bulletSpeed = 10f;
    [SerializeField] GameObject Gun;
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
            rb.MovePosition(rb.position + dir * ryukSpeed * Time.fixedDeltaTime);
        }

        Rigidbody2D playerBullet = Instantiate(rb, Gun.transform.position, transform.rotation).GetComponent<Rigidbody2D>();
        playerBullet.AddForce(transform.up * (bulletSpeed + ryukSpeed), ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Bullet"))
        {
            if (ryukHealth <= 1)
            {
                Destroy(gameObject);
            }
            else
            {
                ryukHealth--;
                Debug.Log("Ryuk health: " + ryukHealth);
            }
        }
    }
}

