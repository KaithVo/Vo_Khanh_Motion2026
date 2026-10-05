
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;

    //class variable values stores on the player
    public Vector3 bombOffSet;
    public float bombTrailSpacing;
    public int numberOfTrailBombs;

    //Accelerator
    public float speed;
    public float accelerationTime;

    public float currentAcceleration;
    public Vector3 currentVelocity;

    //Decellarator
    public float decelerationTime;
    public float currentDeceleration;


    void Start()
    {
        Vector2 currentMousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        Vector3 upDirection = Vector3.up;

        float magnitudeOfUpDirection = upDirection.magnitude;//Gives us the size of the vector, which is 1 in this case
                                                             //magnitude is the distance from the origin to the point in space that the vector points to
        Vector2 normalizedUpDirection = upDirection.normalized;

        //Distance from origin to upDirection
        float distanceToUpDirection = Vector2.Distance(upDirection, Vector2.zero);

        currentAcceleration = speed / accelerationTime;
        currentDeceleration = speed / decelerationTime;
        //transform.position = warpPoint * Time.deltaTime;
    }

    void Update()
    {
        EnemyRadar(2f, 8);
        PlayerMovement();

        if (Keyboard.current.aKey.wasPressedThisFrame)
        {

        }


        //if press B spawn the bomb prefab at the player's position with a random offset of -1 to 1 in both x and y axis
        if (Keyboard.current.bKey.wasPressedThisFrame)
        {
            SpawnBomb();
            Debug.Log("Bomb spawned at: " + transform.position);
        }

        if (Keyboard.current.tKey.wasPressedThisFrame)
        {
            SpawnBombTrail(bombTrailSpacing, numberOfTrailBombs); 
        }

        if (Keyboard.current.wKey.wasPressedThisFrame)
        {
            Wrap();
            Debug.Log("Player wrapped to: " + transform.position);
        }
    }

    public void SpawnBombTrail(float inBombSpacing, int inNumberOfBombs)// a parameter method that can accept different values
                                                                        // the name is arbitrary anyway// tuy y
    {
        for (int i = 0; i < inNumberOfBombs; i++)
        {
            Vector3 offset = Vector3.up * inBombSpacing * (i + 1);

            GameObject bomb = Instantiate(bombPrefab, bombsTransform);

            bomb.transform.position = transform.position + offset;
        }
    }


    void SpawnBomb()
    {
        //random offset of -1 to 1 in both x and y axis by calling vector2
        Vector2 inOffset = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 5f));

        GameObject bomb = Instantiate(bombPrefab, bombsTransform); //Instantiates the bombPrefab as a child of bombsTransform

        bomb.transform.position = transform.position + (Vector3)inOffset;//so bomb position = the player's position + the random offset
    }  

    void Wrap()
    {
        // allow the player's spaceship to instantly jump some amount of distance towards the enemy
        Vector2 directionToEnemy = (enemyTransform.position - transform.position).normalized;
        transform.position += (Vector3)directionToEnemy * 1f; //move the player 5 units towards the enemy


    }


    public void PlayerMovement()
    {

        //BASIC ACCELERATION
        Vector3 accelerationDirection = Vector3.zero;
        if (Keyboard.current.leftArrowKey.isPressed)
        {
        accelerationDirection += Vector3.left;
        }
        if (Keyboard.current.rightArrowKey.isPressed)
        {
        accelerationDirection += Vector3.right;
        }
        if (Keyboard.current.upArrowKey.isPressed)
        {
        accelerationDirection += Vector3.up;
        }
        if (Keyboard.current.downArrowKey.isPressed)
        {
        accelerationDirection += Vector3.down;
        }

        //accelerate while button is down
        if (accelerationDirection != Vector3.zero)//if the direction is not at the reset position
        {
            currentVelocity += accelerationDirection.normalized * currentAcceleration * Time.deltaTime;
            currentVelocity = Vector3.ClampMagnitude(currentVelocity, speed);

        }
        else
        {//trying lerp interpolation, moving the current velocity toward zero
            currentVelocity = Vector3.Lerp(currentVelocity, Vector3.zero, Time.deltaTime* decelerationTime);
        }

        //ACCELERATION DIRECTION REPRESENTS THE DIRECTION WE ARE ACCELERATING
        //WE NORMALIZE IT 
        //AND THEN SET THE AMOUNT TO ACCELERATE BY

        transform.position += currentVelocity * Time.deltaTime;
    }

    public void EnemyRadar(float radius,int circlePoints)
    {
        float angle = 45f;

        float enemyDistance = Vector3.Distance(transform.position,enemyTransform.position);

        Color circleColor;

        if (enemyDistance <= radius)
        {
            circleColor = Color.red;
        }
        else
        {
            circleColor = Color.green;
        }

        Vector3 previousPoint = transform.position + new Vector3(Mathf.Cos(0) * radius, Mathf.Sin(0) * radius, 0);


        for (int i = 0; i <= circlePoints; i++)
        {
            float currentAngle = angle* i * Mathf.Deg2Rad;
            Vector3 currentPoint = transform.position + new Vector3(Mathf.Cos(currentAngle) * radius, Mathf.Sin(currentAngle) * radius, 0);
            Debug.DrawLine(previousPoint, currentPoint, circleColor);
            previousPoint = currentPoint;
        }

    }


}
