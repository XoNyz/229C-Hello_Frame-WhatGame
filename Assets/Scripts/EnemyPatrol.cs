using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public GameObject poiotA;
    public GameObject poiotB;

    private Rigidbody2D rb2d;
    private Animator anim;
    private Transform currentPoint;
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentPoint = poiotB.transform;
        anim.SetBool("IsMove", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (speed >= 0.1f || speed <= -0.1f)
        {
            anim.SetBool("IsMove", true);
        }
        else
        {
            anim.SetBool("IsMove", false);
        }
        
        Vector2 point = currentPoint.position - transform.position;
        if (currentPoint == poiotB.transform)
        {
            rb2d.velocity = new Vector2(speed, 0);
        }
        else
        {
            rb2d.velocity = new Vector2(-speed, 0);
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == poiotB.transform)
        {
            flip();
            currentPoint = poiotA.transform;
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == poiotA.transform)
        {
            flip();
            currentPoint = poiotB.transform;
        }
    }

    private void flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(poiotA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(poiotB.transform.position, 0.5f);
        Gizmos.DrawLine(poiotA.transform.position, poiotB.transform.position);
    }
}
