using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    static Animator anim;
    public float speed;
    public float jumpForce;
    private float moveInput;

    private Rigidbody2D rb;
    private bool isDead = false;

    private bool facingRight = true;

    private bool isGrounded; //boolean for is player on ground
    public Transform groundCheck; //transform object set to feet to check ground
    public float checkRadius; //check for ground collider in set radius
    public LayerMask whatIsGround; //which layer is ground

    public GameObject bulletPrefab;
    public Transform bulletSpawn;


	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>(); //get rigid body of player
        anim = GetComponent<Animator>(); //get animator of player
	}

    private void FixedUpdate()
    {
        //set isGrounded status
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");

        //set object animation to idle or moving
        if (moveInput > 0 || moveInput < 0)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        //Debug.Log(moveInput);
        if(!isDead)
        {
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        }

        //check if sprite is moving and set direction its facing accordingly
        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0) {
            Flip();
        }
    }

    private void Update()
    {

        //check for jump key and jump only if object is already on the ground
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && isGrounded && !isDead)
        {
            rb.velocity = Vector2.up * jumpForce;
        }

        if(Input.GetKeyDown(KeyCode.Space) && !isDead)
        {
            Fire();
        }

    }

    //Flip the sprite based on movement direction
    void Flip() {
        facingRight = !facingRight;

        transform.Rotate(0f, 180f, 0f);
    }

    //shoot gun
    void Fire()
    {
        // Create the Bullet from the prefab
        Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var hit = collision.gameObject;
        
        if(hit.CompareTag("Enemy"))
        {
            isDead = true;
            anim.Play("Dead");
            Destroy(gameObject,0.5f);
            GameObject.Find("Game Manager").GetComponent<FFManager>().livesAmount -= 1;
        }
        if(hit.CompareTag("Flying Enemy"))
        {
            isDead = true;
            anim.Play("Dead");
            Destroy(gameObject, 0.5f);
            GameObject.Find("Game Manager").GetComponent<FFManager>().livesAmount -= 1;
        }
    }
}
