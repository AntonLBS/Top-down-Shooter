using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 moveInput;
    Vector2 screenBounduary;
    bool invinsible = false;
    int upgradeBullets = 0;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float bulletSpeed = 10f;
    [SerializeField] float rotationSpeed = 700f;
    [SerializeField] GameObject Bullet;
    [SerializeField] GameObject Gun;
    [SerializeField] int playerHealth = 5;
    [SerializeField] float invinsibleTime = 2.5f;
    [SerializeField] float upgradeShootTime = 0.1f;
    [SerializeField] bool gunCheat = false;
    [SerializeField] bool healthCheat = false;


    float targetAngle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        screenBounduary = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        if(gunCheat)
        {
            cheat();

        }
    }

    private void OnMove(InputValue Value)
    {
     moveInput = Value.Get<Vector2>();
    }

    void OnAttack()
    {
       Rigidbody2D playerBullet = Instantiate(Bullet, Gun.transform.position, transform.rotation).GetComponent<Rigidbody2D>();
        playerBullet.AddForce(transform.up * (bulletSpeed + moveSpeed), ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = moveInput*moveSpeed; 
        if (moveInput != Vector2.zero)
        {
            targetAngle = Mathf.Atan2(moveInput.y, moveInput.x) * Mathf.Rad2Deg;
        }
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -screenBounduary.x, screenBounduary.x)
                                       , Mathf.Clamp(transform.position.y, -screenBounduary.y, screenBounduary.y));

    }

    void FixedUpdate()
    {
        float rotation = Mathf.MoveTowardsAngle(rb.rotation, targetAngle - 90, rotationSpeed * Time.fixedDeltaTime);
        rb.MoveRotation(rotation);

    }

    void ResetInvinsibility()
    {
        invinsible = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
            if (collision.gameObject.CompareTag("Enemy") && !invinsible && !healthCheat)
            {
                if (playerHealth <= 1)
                {
                    Destroy(gameObject);
                }
                else
                {
                    playerHealth--;
                    invinsible = true;
                    Invoke("ResetInvinsibility", invinsibleTime);
                    Debug.Log("Player health: " + playerHealth);
                }

            }
            else if (collision.gameObject.CompareTag("Upgrade"))
            {
                Destroy(collision.gameObject);
                upgrade();
            }
    }

    void upgrade()
    {
        
        Rigidbody2D playerBullet = Instantiate(Bullet, Gun.transform.position, transform.rotation).GetComponent<Rigidbody2D>();
        playerBullet.AddForce(transform.up * (bulletSpeed + moveSpeed), ForceMode2D.Impulse);
        if (upgradeBullets != 100)
        {
            upgradeBullets++;
            Invoke("upgrade", upgradeShootTime);
        }
        else
        {
            upgradeBullets = 0;
        }

    }

    void cheat()
    {
        Rigidbody2D playerBullet = Instantiate(Bullet, Gun.transform.position, transform.rotation).GetComponent<Rigidbody2D>();
        playerBullet.AddForce(transform.up * (bulletSpeed + moveSpeed), ForceMode2D.Impulse);
        Invoke("cheat", 0.01f);
    }
}

