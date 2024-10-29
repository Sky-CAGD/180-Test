using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject leftPoint;
    public GameObject rightPoint;
    private Vector3 leftPos;
    private Vector3 rightPos;
    public float speed;
    public bool movingRight;

    // Start is called before the first frame update
    void Start()
    {
        //Store the starting values in 3D space of our left/right points
        leftPos = leftPoint.transform.position;
        rightPos = rightPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
    }

    private void MoveEnemy()
    {
        if(movingRight)
        {
            //Check if reached the right Pos - if so, switch directions
            if(transform.position.x >= rightPos.x)
            {
                movingRight = false;
            }
            else //Not yet at right pos, Move Right
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
        }
        else
        {
            //Check if reached the left Pos - if so, switch directions
            if (transform.position.x <= leftPos.x)
            {
                movingRight = true;
            }
            else //Not yet at right pos, Move Right
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
        }
    }
}
