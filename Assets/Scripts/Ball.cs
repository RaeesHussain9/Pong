using System;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

// to do list bounce just continues along the same path -> fix that
// make it so id the ball hits the net it restarts the scene again or destroys ball and reinstantiates the players in the original position
// add a score board

public class Ball : MonoBehaviour
{
    private const string PLAYER_TAG = "Player";
    private const string BOUNDARY_TAG = "Boundary";

    private Rigidbody2D rigidBody;

    private readonly int speed = 12;

    private readonly float speedMultiplier = 2f;

    private Vector2 invertXAxis = new Vector2(-1, 1);

    private Vector2 currentDirection;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();

        currentDirection = new Vector2(RandomStartDirection(), RandomStartDirection()).normalized;

        rigidBody.velocity = currentDirection * speed;

        //startDirection = new Vector2(1, 0).normalized; //-> direction test code
    }

    // Update is called once per frame
    private void Update()
    {

    }

    private void PlayerBounce(Transform collidedObject)
    {
        Vector2 ballPosition = transform.position;
        Vector2 playerPosition = collidedObject.position;

        float xDirection;
        float yDirection = 0;

        if (ballPosition.y > 0) 
        {
            yDirection = -1;
        }
        else if (ballPosition.y < 0) 
        {
            yDirection = 1;
        }

        xDirection = (ballPosition.x - playerPosition.x) / collidedObject.GetComponent<Collider2D>().bounds.size.x;

        currentDirection = new Vector2(xDirection, yDirection);

        rigidBody.velocity = currentDirection * speed * speedMultiplier;
    }

    private void WallBounce()
    {
        currentDirection *= invertXAxis;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(PLAYER_TAG))
        {
            PlayerBounce(other.transform);
        }
        else if (other.gameObject.CompareTag(BOUNDARY_TAG)) 
        {
            WallBounce();
        }
    }

    private float RandomStartDirection()
    {
        float randomDirection = Random.Range(0.1f, 0.9f);

        float randomNegative = Random.Range(0,2);

        if (randomNegative == 0) 
        {
            randomDirection *= -1;
        }

        return randomDirection;
    }

    // vector.reflect code to go over later and try to figure out why it was not working
    //if (other.gameObject.CompareTag("Player"))
    //    {
    //        //Vector2 inNormal = other.contacts[0].normal;
    //        //Debug.Log(other.contacts[0]);
    //        //Debug.Log(other.contacts[0].normal);
    //        //startDirection = Vector2.Reflect(rigidBody.velocity, inNormal).normalized;
    //        //Debug.Log(startDirection);

    //        //rigidBody.velocity = Vector2.down * speed;

    //        startDirection *= invertYAxis;
    //        //startDirection *= invertYAxis.magnitude;
    //    }
}
