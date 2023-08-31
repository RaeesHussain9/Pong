using UnityEngine;

// to do list bounce just continues along the same path -> fix that
// make it so id the ball hits the net it restarts the scene again or destroys ball and reinstantiates the players in the original position
// add a score board

public class Ball : MonoBehaviour
{
    private const string PLAYER_TAG = "Player";
    private const string BOUNDARY_TAG = "Boundary";

    private Rigidbody2D rigidBody;

    private readonly int speed = 12;

    private Vector2 invertYAxis= new Vector2(1,-1);
    private Vector2 invertXAxis = new Vector2(-1, 1);

    private Vector2 zeroXAxis = new Vector2(0, 1);
    private Vector2 negativeZeroXAxis = new Vector2(0, -1);

    private Vector2 zeroYAxis = new Vector2(1, 0);
    private Vector2 negativeZeroYAxis = new Vector2(-1, 0);




    private Vector2 startDirection;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();

        startDirection = new Vector2(RandomStartDirection(), RandomStartDirection()).normalized;
        //startDirection = new Vector2(1, 0).normalized; //-> direction test code
    }

    // Update is called once per frame
    private void Update()
    {
        rigidBody.velocity = startDirection * speed;

        //RandomDirection();

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.gameObject);

        if (other.gameObject.CompareTag(PLAYER_TAG))
        {
            if (startDirection == zeroXAxis || startDirection == negativeZeroXAxis)
            {
                startDirection += new Vector2(0.25f, 0);
                startDirection *= invertYAxis;
            }
            else
            {
                startDirection *= invertYAxis;
            }
        }
        else if (other.gameObject.CompareTag(BOUNDARY_TAG))
        {
            if (startDirection == zeroYAxis || startDirection == negativeZeroYAxis)
            {
                startDirection += new Vector2(0f, 0.25f);
                startDirection *= invertXAxis;
            }
            else 
            {
                startDirection *= invertXAxis;
            }
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
