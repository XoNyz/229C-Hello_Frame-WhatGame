using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject enemy;
    public GameObject target;

    public float speed = 10f;

    private float enemyX;
    private float targetX;

    private float dist;
    private float nextX;
    private float baseY;
    private float height;
    
    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        target = GameObject.FindGameObjectWithTag("Player");
    }
    
    // Update is called once per frame
    void Update()
    {
        enemyX = enemy.transform.position.x;
        targetX = target.transform.position.x;

        dist = targetX - enemyX;
        nextX = Mathf.MoveTowards(transform.position.x, targetX, speed * Time.deltaTime);
        baseY = Mathf.Lerp(enemy.transform.position.y, target.transform.position.y, (nextX - enemyX) / dist); //Realistic curve effect
        height = 2 * (nextX - enemyX) * (nextX - targetX) / (-0.25f * dist * dist);

        Vector3 movePosition = new Vector3(nextX, baseY + height, transform.position.z);
        transform.rotation = LookAtTarget(movePosition - transform.position);
        transform.position = movePosition;
        
        if (transform.position == target.transform.position)
        {
            Destroy(gameObject);
        }
    }

    public static Quaternion LookAtTarget(Vector2 rotation)
    {
        return Quaternion.Euler(0, 0, Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg);
    }
}
