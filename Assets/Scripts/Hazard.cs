using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Larsen, Sky
 * 10/22/24
 * handles things colliding with and damaging the player
 */

public class Hazard : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        //Check if collided with player
        if(collision.gameObject.GetComponent<PlayerController>())
        {
            collision.gameObject.GetComponent<PlayerController>().Respawn();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Check if overlapped with player
        if (other.gameObject.GetComponent<PlayerController>())
        {
            other.gameObject.GetComponent<PlayerController>().Respawn();
        }
    }
}
