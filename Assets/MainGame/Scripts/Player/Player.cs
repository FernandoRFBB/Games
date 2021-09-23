using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed = 10;
    Animator anim;
    Rigidbody2D rb;
    private float move;
    private bool facingRight = true;

    public GameObject bullet;
    public Transform weapon;

    public float jumpForce = 15;

    public LayerMask groundLayer;
    public bool onGround;
    public float groundLength = 2.2f;

    public int gravity;

    void Start() {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {

        // Input de movimentação do jogador;
        move = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Fire1")) {
            Shot();
        } else {
            anim.SetBool("isShooting", false);
        }
        

        onGround = Physics2D.Raycast(transform.position, Vector2.down, groundLength, groundLayer);

        // Resetando a gravidade para quando o jogador estiver no chao
        if (onGround) {
            rb.gravityScale = 1;
        }

        if (Input.GetButtonDown("Jump") && onGround) {
            Jump();
        }
    }

    void FixedUpdate() {

        // Movimentar o jogador
        rb.velocity = new Vector2(move * speed, rb.velocity.y);
        
        // Setando a animação de andar
        if (Mathf.Abs(rb.velocity.x) > 0) {
            anim.SetBool("isWalking", true);
        } else {
            anim.SetBool("isWalking", false);
        }

        // Mudando a direcao do sprite dependendo da direcao que ele vai andar
        if ((rb.velocity.x > 0 && !facingRight) || (rb.velocity.x < 0 && facingRight)) {
            facingRight = !facingRight;
            transform.rotation = Quaternion.Euler(0, facingRight ? 0 : 180, 0); // Se tiver virado pra direita, deixa na posicao padrao do sprite, se não gira 180
        }

        
        if (rb.velocity.y < 0) { // Se o cara estiver caindo, deixar a gravidade que a gnt setou
            rb.gravityScale = gravity;
        } else { // Se o cara estiver subindo, diminuir a gravidade, para ir mais alto
            rb.gravityScale = gravity / 2;
        }
    }

    void Jump() {
        rb.velocity = Vector2.up * jumpForce;
    }


    // Fazendo isso para conseguir ver se está perto do chão ou não, para poder pular
    private void OnDrawGizmos() {
        Gizmos.color = Color.black;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundLength);
    }

    // Se o mouse for pressionado, atirar
    private void Shot() {
        anim.SetBool("isShooting", true);
        Instantiate(bullet, weapon.position, weapon.rotation);
    }
    

    // [Header("Movement")]
    // public float speed = 10;
    // Vector2 direction;
    // private bool facingRight = true;

    // [Header("Components")]
    // public Animator anim;
    // public Rigidbody2D rb;

    // [Header("Physics")]
    // public float maxSpeed = 7f;
    // public float linearDrag = 4f;

    // // Start is called before the first frame update
    // void Start() {
    //     rb = GetComponent<Rigidbody2D>();
    // }

    // // Update is called once per frame
    // void Update() {
    //     direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    // }

    // void FixedUpdate() {
    //     MoveCharacter(direction.x);
    //     ModifyPhysics();
    // }

    // void MoveCharacter(float horizontal) {

    //     rb.AddForce(Vector2.right * horizontal * speed);

    //     anim.SetFloat("horizontal", Mathf.Abs(rb.velocity.x));

    //     if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight) {
    //         Flip();
    //     }

    //     if (Mathf.Abs(rb.velocity.x) > maxSpeed) {
    //         rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxSpeed, rb.velocity.y); // Colocando Mathf.Sign que ela pega o sinal que esta o rb.velocity.x, funcionando assim a velocidade maxima pra esquerda ou direita
    //     }
    // }

    // void ModifyPhysics() {

    //     bool changingDirection = (direction.x > 0 && rb.velocity.x < 0) || (direction.x < 0f && rb.velocity.x > 0);

    //     if (Mathf.Abs(direction.x) < 0.4f || changingDirection) {
    //         rb.drag = linearDrag;
    //     } else {
    //         rb.drag = 0f;
    //     }
    // }

    // void Flip() {
    //     facingRight = !facingRight;
    //     transform.rotation = Quaternion.Euler(0, facingRight ? 0 : 180, 0); // Se tiver virado pra direita, deixa na posicao padrao do sprite, se não gira 180
    // }
}
