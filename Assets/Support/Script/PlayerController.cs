using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D rb;
   
    public GameObject Death;

    public float speed = 5f;

    public int health = 100;

    Vector2 movement;
    
    // Start is called before the first frame update
    void Start()
    {
        // Caso precise ignorar colisões com as balas
        // Physics2D.IgnoreLayerCollision(10, 9, true);
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    public void TakeDamage(int damage)
    {
        health = health - damage;

        if (health <= 0)
        {
            // Qualquer coisa posso colocar numa outra funcao Die()
            Die();
        }
    }

    void Die()
    {
        Death.SetActive(true);
        Time.timeScale = 0;
        PauseMenu.isPaused = true;
    }
}
