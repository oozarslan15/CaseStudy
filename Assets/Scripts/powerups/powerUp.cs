using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUp : MonoBehaviour
{
    private bool isDestroyed;
    Vector3 powerUp_location;
public GameObject particle;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(pickUp(collision));
        }

     


    }

    IEnumerator pickUp(Collider player)
    {
        Instantiate(particle, transform.position, transform.rotation);
        player.GetComponent<Rigidbody>().mass *= 2.0f;
        player.GetComponent<CarController>().motorTorqueForce*= 5.0f;
        player.GetComponent<Transform>().localScale*=3.0f;
        GetComponent<MeshRenderer>().enabled=false;
        GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(10);
        player.GetComponent<Rigidbody>().mass /= 2.0f;
        player.GetComponent<CarController>().motorTorqueForce /= 5.0f;
        player.GetComponent<Transform>().localScale /= 3.0f;
        GetComponent<MeshRenderer>().enabled = true;
        GetComponent<Collider>().enabled = true;
        


    }
}

