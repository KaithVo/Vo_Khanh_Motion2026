
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

    // Rotation
    public float rotationSpeed = 360f;

    private Vector2 startPosition;
    private Vector2 endPosition;
    private Vector2 launchDirection;

    private float timer = 0f;
    private bool returning = false;

    private bool launched = false;

    void Start()
    {
        // Remember where the boomerang starts
        startPosition = transform.position;

        // Use the player's upward direction to launch
        launchDirection = player.up;

        // Calculate the destination of the outward movement
        endPosition = startPosition + launchDirection * outwardDistance;
    }

    void Update()
    {
        // Press D to launch the boomerang
        if (Keyboard.current.dKey.wasPressedThisFrame && !launched)
        {
            launched = true;
            timer = 0f;
        }
        // Only run the boomerang movement after it has been launched
        // use "launched" so the boomerang does not move before
        // the player activates it by pressing d

        // Rotate the boomerang around its Z axis to make it spin
        if (launched)
        {
            // Spin the boomerang while it moves
            transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);

            // Increase the timer.
            timer += Time.deltaTime;

            // Check whether the boomerang is still flying outward
            // If returning is false, it follows the outward movement
            if (!returning)
            {
                // Dividing timer by outwardDuration tells me how much of
                // the outward trip has finished
                // Clamp01 keeps the value between 0 and 1
                float t = Mathf.Clamp01(timer / outwardDuration);

                // LErp to move between the starting position and the destination
                Vector2 position = Vector2.Lerp(startPosition, endPosition, t);

                //youtube.com/watch?v=XqjEB9ySUm0&time_continue=133&source_ve_path=NzY3NTg&embeds_referring_euri=https%3A%2F%2Fwww.google.com%2Fsearch%3Fq%3Dfloat%2Bcurve%2B%253D%2BMathf.Sin(t%2B*%2BMathf.PI)%2B*%2BcurveHeight%253B%26rlz%3D1C5CHFA_enCA1026CA1026%26oq%3Dfloat%2Bcur
                //https://discussions.unity.com/t/how-to-add-a-sine-curve/931575/7
                // Calculate the sideways curve using a sine function
                // Multiplying t by PI makes the sine value rise and fall once during the outward trip
                // Multiplying by curveHeight controls how far the boomerang moves sideways from its straight path
                float curve = Mathf.Sin(t * Mathf.PI) * curveHeight;

                Vector2 perpendicular = new Vector2(-launchDirection.y, launchDirection.x);
                // Calculate a perpendicular direction to the launch direction
                // This lets me move the boomerang sideways to create an arc, the negative Y and X components give a 90-degree
                position += perpendicular * curve;
                transform.position = position;

                // Start returning when the outward movement ends
                if (t >= 1f)
                {
                    returning = true;
                    // Reset the timer so the return trip starts at t = 0, otherwise, the return progress would already be finished
                    timer = 0f;
                    startPosition = transform.position;
                }
            }
            else
            {
                // The boomerang is now returning to the player, calculate the return progress from 0 to 1.
                float t = Mathf.Clamp01(timer / returnDuration);

                Vector2 position = Vector2.Lerp(startPosition, player.position, t);

                transform.position = position;

                // Destroy the boomerang when it returns
                if (t >= 1f)
                {
                    Destroy(gameObject);
                }
            }

            // Check whether the boomerang touches a star
            CollectStars();
        }
    }

    void CollectStars()
    {
        for (int i = stars.Count - 1; i >= 0; i--)
        {
            // Calculate the distance between the boomerang and this star, Vector2.Distance measures the space between two positions.
   
            if (stars[i] == null)
            {
                stars.RemoveAt(i);
               
            }

            float distance = Vector2.Distance(transform.position, stars[i].position);
            // If the distance is less than 0.5 Unity units, boomerang is close enough to collect the star
            if (distance < 0.5f)
            {
                Destroy(stars[i].gameObject);
                stars.RemoveAt(i);
            }
        }
    }
}
