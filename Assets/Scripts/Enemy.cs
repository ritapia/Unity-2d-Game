using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int health = 100;
    public int damage;
    public float speed;

    public LayerMask groundMask;
    private Transform enemyTrans;
    private Rigidbody2D enemyBody;
    private float enemyWidth;
    private float enemyHeight;

    private void Start()
    {
        enemyTrans = gameObject.transform;
        enemyBody = gameObject.GetComponent<Rigidbody2D>();
        enemyWidth = gameObject.GetComponent<SpriteRenderer>().bounds.extents.x;
        enemyHeight = gameObject.GetComponent<SpriteRenderer>().bounds.extents.y;
    }
    private void FixedUpdate()
    {
        Vector2 lineCastPos = enemyTrans.position + enemyTrans.right * enemyWidth - enemyTrans.up * enemyHeight;
        Debug.DrawLine(lineCastPos, lineCastPos + Vector2.down);
        bool isGrounded = Physics2D.Linecast(lineCastPos, lineCastPos + Vector2.down, groundMask);

        if(!isGrounded)
        {
            //Debug.Assert(isGrounded);
            transform.Rotate(0f, 180f, 0f);
        }

        Vector2 enemyVelocity = enemyBody.velocity;
        enemyVelocity = transform.right * speed;
        enemyBody.velocity = enemyVelocity;
    }
    public void TakeDamage ()
    {
        health -= damage;

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var hitInfo = collision.gameObject;
        var friendly = hitInfo.GetComponent<Enemy>();
        var friendlyF = hitInfo.GetComponent<FlyingEnemy>();
        if(friendly != null || friendlyF != null)
        {
            transform.Rotate(0f, 180f, 0f);
        }
    }
}
