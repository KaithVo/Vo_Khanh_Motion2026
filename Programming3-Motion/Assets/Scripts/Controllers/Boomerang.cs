
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Boomerang : MonoBehaviour
{
    // Reference to other elements
    public Transform player;
    public List<Transform> stars;

    // Movement
    public float outwardDistance = 6f;
    public float outwardDuration = 1.5f;
    public float returnDuration = 1.2f;
    public float curveHeight = 2f;
    private bool launched = false;

    // Rotation
    public float rotationSpeed = 360f;

    private Vector2 startPosition;
    private Vector2 endPosition;
    private Vector2 launchDirection;

    private float timer = 0f;
    private bool returning = false;

    void Start()
    {
        // Remember where the boomerang starts.
        startPosition = transform.position;

        // Use the player's upward direction to launch.
        launchDirection = player.up;

        // Calculate the destination of the outward movement.
        endPosition = startPosition + launchDirection * outwardDistance;
    }

    void Update()
    {
        // Spin the boomerang while it moves.
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);

        // Increase the timer.
        timer += Time.deltaTime;
        // Press B to launch the boomerang.
        if (Keyboard.current.bKey.wasPressedThisFrame && !launched)
        {
            launched = true;
            timer = 0f;
        }

       
            // Check whether the boomerang touches a star.
            CollectStars();
    }


    

    void CollectStars()
    {
        for (int i = stars.Count - 1; i >= 0; i--)
        {
            if (stars[i] == null)
            {
                stars.RemoveAt(i);
                continue;
            }

            float distance = Vector2.Distance(
                transform.position, stars[i].position
            );

            if (distance < 0.5f)
            {
                Destroy(stars[i].gameObject);
                stars.RemoveAt(i);
            }
        }
    }
}
