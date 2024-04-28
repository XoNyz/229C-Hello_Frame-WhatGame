using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndGame : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("End"))
        {
            SceneManager.LoadScene("EndGame");
        }

        if (collision.gameObject.CompareTag("Die"))
        {
            SceneManager.LoadScene("MainGame");
        }
    }
}
