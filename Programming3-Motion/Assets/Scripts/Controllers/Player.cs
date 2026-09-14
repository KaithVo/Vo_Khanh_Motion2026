using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;

    void Start()
    {
        Vector2 currentMousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        Vector3 upDirection = Vector3.up;

        float magnitudeOfUpDirection = upDirection.magnitude;//Gives us the size of the vector, which is 1 in this case
                                                             //magnitude is the distance from the origin to the point in space that the vector points to
        Vector2 normalizedUpDirection = upDirection.normalized;

        //Distance from origin to upDirection
        float distanceToUpDirection = Vector2.Distance(upDirection, Vector2.zero);
    }

    void Update()
    {

        if (Keyboard.current.aKey.wasPressedThisFrame)
        {

        }
        //if press B spawn the bomb prefab at the player's position with a random offset of -1 to 1 in both x and y axis
        if (Keyboard.current.bKey.wasPressedThisFrame)
        {
            SpawnBomb();
            Debug.Log("Bomb spawned at: " + transform.position);
        }

        if (Keyboard.current.wKey.wasPressedThisFrame)
        {
            Wrap();
            Debug.Log("Player wrapped to: " + transform.position);
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

}
