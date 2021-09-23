using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int speed;
    private Rigidbody2D rb;
    public int damage;
    public GameObject HitEffect;


    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = transform.right * speed;
    }

    private void OnHit() {

    }
    
    void OnTriggerEnter2D(Collider2D coll) {
        switch (coll.tag) {
            case var _ when coll.tag.Equals("Enemy"):
                Debug.Log("wowo");
                break;
            default:
                Debug.Log("Default");
                break;
        }

        Instantiate(HitEffect, transform.position, transform.rotation);

        Destroy(gameObject);
    }


    // Se sair da visão do personagem, destruir
    void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
