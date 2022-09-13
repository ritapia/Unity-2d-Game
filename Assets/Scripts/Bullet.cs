using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed = 20f;
    public int damage = 40;
    public Rigidbody2D rb;

    // Use this for initialization
    void Start () {
        rb.velocity = transform.right * speed;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var hit = collision.gameObject;
        var enemy = hit.GetComponent<Enemy>();
        var enemyF = hit.GetComponent<FlyingEnemy>();

        if(enemy != null)
        {
            enemy.TakeDamage();
        }
        if(enemyF != null)
        {
            enemyF.TakeDamage();
        }
        Destroy(gameObject);
    }

    private void Update()
    {
        //destroy bullet after 3 seconds
        Destroy(gameObject, 3.0f);
    }
}
