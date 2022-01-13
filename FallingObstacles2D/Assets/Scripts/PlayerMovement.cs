using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed;
    public float horizontalInput;
    public float leftRightBounds;
    public int health;
    public float score;
    // Start is called before the first frame update
    void Start()
    {
        PrintHealth();
        InvokeRepeating("UpdateScore", 2f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        CheckHealth();
        Movement();
    }

    void Movement()
    {
        StayInbounds();
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * horizontalInput * Time.deltaTime * playerSpeed);
    }

    void StayInbounds()
    {
        if(transform.position.z < -leftRightBounds)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -leftRightBounds);
        }
        if (transform.position.z > leftRightBounds)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, leftRightBounds);
        }
        transform.rotation = new Quaternion(0, 0, 0, 0);
    }

    private void OnCollisionEnter(Collision other)
    {
        //Debug.Log("Collided");
        //Destroy(other.gameObject);
        health--;
        PrintHealth();
    }

    void CheckHealth()
    {
        if(health<1)
        {
            PrintHealth();
            Debug.Log("Game Over");
            Destroy(gameObject);
        }
    }

    void PrintHealth()
    {
        Debug.Log("Health: " + health);
    }

    void UpdateScore()
    {
        score++;
        Debug.Log("Score: " + score);
    }
}
