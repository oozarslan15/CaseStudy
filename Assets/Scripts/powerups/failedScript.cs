using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class failedScript : MonoBehaviour
{
    int destroyed ;
    private void OnTriggerEnter(Collider collision)
    {
        
        
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<CarController>().userDestroyed = true;
            Destroy(collision.gameObject);
            SceneManager.LoadScene("gameOverScene");
        } 
        if (collision.gameObject.CompareTag("Enemy1"))
        {
            collision.gameObject.GetComponent<latestAI>().enemy1destroyed = true;
            Destroy(collision.gameObject);
            destroyed += 1; 

        }
        if (collision.gameObject.CompareTag("Enemy2"))
        {
            collision.gameObject.GetComponent<latestAI>().enemy2destroyed= true;
            Destroy(collision.gameObject);
            destroyed += 1;
        }
        if (collision.gameObject.CompareTag("Enemy3"))
        {
            collision.gameObject.GetComponent<latestAI>().enemy3destroyed = true;
            Destroy(collision.gameObject);
            destroyed += 1;
        }
        if (collision.gameObject.CompareTag("Enemy4"))
        {
            collision.gameObject.GetComponent<latestAI>().enemy4destroyed= true;
            Destroy(collision.gameObject);
            destroyed += 1;
        }
        if (collision.gameObject.CompareTag("Enemy5"))
        {
            collision.gameObject.GetComponent<latestAI>().enemy5destroyed = true;
            Destroy(collision.gameObject);
            destroyed += 1;
        }
        if (collision.gameObject.CompareTag("Enemy6"))
        {
            collision.gameObject.GetComponent<latestAI>().enemy6destroyed = true;
            Destroy(collision.gameObject);
            destroyed += 1;
        }
        if (collision.gameObject.CompareTag("Enemy7"))
        {
            collision.gameObject.GetComponent<latestAI>().enemy7destroyed = true;
            Destroy(collision.gameObject);
            destroyed += 1;
        }
        if (collision.gameObject.CompareTag("Enemy8"))
        {
            collision.gameObject.GetComponent<latestAI>().enemy8destroyed = true;
            Destroy(collision.gameObject);
            destroyed += 1;
        }
        if (collision.gameObject.CompareTag("Enemy9"))
        {
            collision.gameObject.GetComponent<latestAI>().enemy9destroyed = true;
            Destroy(collision.gameObject);
            destroyed += 1;
        }
        if (collision.gameObject.CompareTag("Enemy10"))
        {
            collision.gameObject.GetComponent<latestAI>().enemy10destroyed = true;
            Destroy(collision.gameObject);
            destroyed += 1;
        }

        if (destroyed == 10)
        {
            SceneManager.LoadScene("win");
        }


    }
}
