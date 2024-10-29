using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Larsen, Sky
 * 10/22/24
 * handles teleporting things to a new point in space
 */


public class Portal : MonoBehaviour
{
    public GameObject teleportPoint;
    
    private void OnTriggerEnter(Collider other)
    {
        other.transform.position = teleportPoint.transform.position;
    }
}
