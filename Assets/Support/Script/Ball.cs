using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public Rigidbody2D rb;

    public int damage = 30;

    public float moveSpeed = 20f;
    
    Vector3 lastVelocity;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up * moveSpeed;
        Physics2D.IgnoreLayerCollision(9, 9, true);
    }

    // Update is called once per frame
    void Update()
    {
        lastVelocity = rb.velocity;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Wall"))
        {
            var speed = lastVelocity.magnitude;
            var direction = Vector3.Reflect(lastVelocity.normalized, coll.contacts[0].normal);
            rb.velocity = direction * Mathf.Max(speed, 0f);
        } else {
            InCollision(coll.gameObject);
        }
    }
     
    private void OnTriggerEnter2D(Collider2D coll)
    {
        InCollision(coll.gameObject);
    }

    void InCollision (GameObject collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            Enemy enemy = collider.GetComponent<Enemy>();
            enemy.TakeDamage(damage);
            Destroy(gameObject);
            Debug.Log(collider.tag);
        } else if (collider.CompareTag("Player"))
        {
            PlayerController player = collider.GetComponent<PlayerController>();
            player.TakeDamage(damage);
            Destroy(gameObject);
            Debug.Log(collider.tag); // TER LIMITE DE BOLAS E DAR DANO NO PLAYER
        }
    }
}
