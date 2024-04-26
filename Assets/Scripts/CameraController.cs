using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 offset; //FOV = Field of vision yes i know haha
    
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
            player.position.x + offset.x, 
            player.position.y + offset.y,
              offset.z);
    }
}
