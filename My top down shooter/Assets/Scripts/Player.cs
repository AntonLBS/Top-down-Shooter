using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 moveInput;
    [SerializeField] float moveSpeed = 5;
    [SerializeField] float bulletSpeed = 10;
    [SerializeField] GameObject Bullet;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnMove(InputValue Value)
    {
     moveInput = Value.Get<Vector2>();
    }

    void OnAttack()
    {
       Rigidbody2D playerBullet = Instantiate(Bullet, transform.position, Quaternion.identity).GetComponent<Rigidbody2D>();
        playerBullet.AddForce(transform.up * (bulletSpeed + moveSpeed), ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = moveInput*moveSpeed;  
    }
}
