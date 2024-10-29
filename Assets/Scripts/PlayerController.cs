using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Larsen, Sky
 * 10/22/24
 * handles player movement & behaviors
 */

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10;
    public float jumpForce = 10;
    public float raycastDist = 1.2f;
    public float deathY = -2f;
    public GameObject respawnPoint;
    public int lives = 3;

    private Vector3 moveDir;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // FixedUpdate is called on a fixed interval of 0.02 sec (called 50 times per seconds)
    void FixedUpdate()
    {
        //Check for left input
        if (Input.GetKey(KeyCode.A))
        {
            moveDir = Vector3.left;
            //transform.position += moveDir * moveSpeed * Time.deltaTime; //World Space
            rb.MovePosition(transform.position + moveDir * moveSpeed * Time.deltaTime);
        }

        //Check for right input
        if (Input.GetKey(KeyCode.D))
        {
            moveDir = Vector3.right;
            //transform.Translate(moveDir * moveSpeed * Time.deltaTime); // Local Space
            rb.MovePosition(transform.position + moveDir * moveSpeed * Time.deltaTime);
        }
    }

    private void Update()
    {
        //Check for jump input
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            print("Jumped");
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        
        //This is for Editor ONLY to visualize our raycast
        Debug.DrawRay(transform.position, Vector3.down * raycastDist, Color.red);

        //Check if player is below a cetain y value in the world
        if(transform.position.y  <= deathY)
        {
            Respawn();
        }
    }

    /// <summary>
    /// Reduce lives and teleport the player to a respawn point if lives remain
    /// </summary>
    public void Respawn()
    {
        lives--;

        //Check if still alive
        if(lives <= 0)
        {
            //Game Over
            print("Game Over!");
            //gameObject.SetActive(false);\

            //Disable the renderer (visual mesh) and this script of the player
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            this.enabled = false;
        }
        else
        {
            //Teleport to respawn point
            transform.position = respawnPoint.transform.position;
        }
    }

    private bool IsGrounded()
    {
        bool isGrounded = false;       

        //perform a raycast to check if player is on the ground
        if(Physics.Raycast(transform.position, Vector3.down, raycastDist))
        {
            isGrounded = true;
        }

        return isGrounded;
    }
}
