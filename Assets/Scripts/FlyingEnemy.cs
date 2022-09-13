using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour {

    public float speed;
    public int health = 100;
    public int damage;

    public Transform target;

    void Start()
    {   
        if(GameObject.FindWithTag("Player") != null)
            target = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        if (GameObject.FindWithTag("Player") != null)
        {
            target = GameObject.FindWithTag("Player").GetComponent<Transform>();
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        }
    }

    public void TakeDamage()
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}
