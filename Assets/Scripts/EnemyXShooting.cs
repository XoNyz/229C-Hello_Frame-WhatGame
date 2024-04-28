using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyXShooting : MonoBehaviour
{
    [SerializeField] private Transform ProjectilePrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private LineRenderer lineRenderer;

    [SerializeField] private float force = 1.5f;
    [SerializeField] private float trajectoryTimeStep = 0.05f;
    [SerializeField] private int trajectoryTimeStepCount = 10;

    private float timer;
    private GameObject player;
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject target;
    
    private Vector3 velocity, targetX, enemyX;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        enemyX = new Vector2 (enemy.transform.position.x, enemy.transform.position.y);
        targetX = new Vector2 (target.transform.position.x, target.transform.position.y);
        
        float distance = Vector2.Distance(transform.position, player.transform.position);
        
        if (distance < 10)
        {
            velocity = (targetX - enemyX ) * force;
            timer += Time.deltaTime;
            
            if (timer > 2)
            {
                timer = 0;
                
                DrawTrajectory();
                ProjectileShoot();
            }
        }
    }

    void DrawTrajectory()
    {
        Vector3[] positions = new Vector3[trajectoryTimeStepCount];
        for (int i = 0; i < trajectoryTimeStepCount; i++)
        {
            float t = i * trajectoryTimeStep;
            Vector3 pos = spawnPoint.position + velocity * t + 0.5f * Physics.gravity * t * t;

            positions[i] = pos;
        }
 
        /*lineRenderer.positionCount = trajectoryTimeStepCount;
        lineRenderer.SetPositions(positions);*/
    }
    
    void ProjectileShoot()
    {
        Transform pr = Instantiate(ProjectilePrefab, spawnPoint.position, Quaternion.identity);

        pr.GetComponent<Rigidbody2D>().velocity = velocity;
    }
    
}
