using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
// Transforms to act as start and end markers for the journey.
{
    Animator anim;

    public int health;

    private Rigidbody2D rd;
    private SpriteRenderer sr;

    // Movement speed in units/sec.
    public float speed = 1.0F;

    void Start()
    {



        rd = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        anim = GetComponent<Animator>();
    }

    // Follows the target position like with a spring
    void Update()
    {
        rd.velocity = new Vector2(speed, 0);

        //THIS IS WHERE I LEFT OFF
        if (health <= 0)
        {
            anim.SetInteger("State", 1);
            Destroy(gameObject, 0.5f);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Flipping")
        {
            if (sr.flipX == false)
            {
                sr.flipX = true;
                speed = -2;
                return;
            }
            else sr.flipX = false;
            speed = 2;
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        anim.SetInteger("State", 2);
    }
}