using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thwomp : MonoBehaviour
{
    public float movingDownSpeed = 5;
    public float movingUpSpeed = 2;
    public float waitTime = 1.5f;

    private Vector3 raycastLeftOrigin;
    private Vector3 raycastRightOrigin;
    private float maxHeight;
    private bool isMovingDown = false;
    private bool waiting = false;

    // Start is called before the first frame update
    void Start()
    {
        float halfWidth = (transform.localScale.x / 2) + 0.1f;

        raycastLeftOrigin = transform.position - new Vector3(halfWidth, 0, 0);
        raycastRightOrigin = transform.position + new Vector3(halfWidth, 0, 0);

        maxHeight = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hitInfo;

        if(!isMovingDown && waiting && Physics.Raycast(raycastLeftOrigin, Vector3.down, out hitInfo))
        {
            //Check if raycast hit the player
            if(hitInfo.collider.GetComponent<PlayerController>())
            {
                isMovingDown = true;             
            }
        }

        Debug.DrawRay(raycastLeftOrigin, Vector3.down * 100, Color.red);

        if (!isMovingDown && waiting && Physics.Raycast(raycastRightOrigin, Vector3.down, out hitInfo))
        {
            //Check if raycast hit the player
            if (hitInfo.collider.GetComponent<PlayerController>())
            {
                isMovingDown = true;
            }
        }

        Debug.DrawRay(raycastRightOrigin, Vector3.down * 100, Color.red);

        if (isMovingDown)
        {
            MoveDownward();
        }
        else if (!waiting && !isMovingDown)
        {
            MoveUpward();
        }
    }

    private void MoveDownward()
    {
        waiting = false;
        transform.position += Vector3.down * movingDownSpeed * Time.deltaTime;
    }

    private void MoveUpward()
    {
        transform.position += Vector3.up * movingUpSpeed * Time.deltaTime;

        if(transform.position.y >= maxHeight)
        {
            waiting = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(!collision.gameObject.GetComponent<PlayerController>())
        {
            //Starts the WaitToMoveUp coroutine
            StartCoroutine(WaitToMoveUp());
        }
    }

    private IEnumerator WaitToMoveUp()
    {
        //code here happens instantly when this coroutine is called
        isMovingDown = false;
        waiting = true;

        yield return new WaitForSeconds(waitTime);

        //code here happens after waiting
        waiting = false;
    }
}
