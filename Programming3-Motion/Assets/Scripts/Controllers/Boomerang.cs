using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour
{
    //Reference to other element
    public Transform player;
    public List<Transform> stars;
    //Movement
    public float outwardDistance = 6f;
    public float outwardDuration = 1.5f;
    public float returnDuration = 1.2f;
      public float curveHeight = 2f;
    //Rotation
    public float rotationSpeed = 360f;
    private Vector2 startPosition;
    private Vector2 launchDirection;
    private float timer = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.position;

        // Use the player's upward direction to launch.
        launchDirection = player.up;
    }

    // Update is called once per frame
    void Update()
    {
        // Spin the boomerang while it moves.
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
        timer += Time.deltaTime;

        // Move forward while following a sine curve.
        Vector2 position = Vector2.Lerp(startPosition, endPosition, t);
        //
        float curve = Mathf.Sin(t * Mathf.PI) * curveHeight;
        //youtube.com/watch?v=XqjEB9ySUm0&time_continue=133&source_ve_path=NzY3NTg&embeds_referring_euri=https%3A%2F%2Fwww.google.com%2Fsearch%3Fq%3Dfloat%2Bcurve%2B%253D%2BMathf.Sin(t%2B*%2BMathf.PI)%2B*%2BcurveHeight%253B%26rlz%3D1C5CHFA_enCA1026CA1026%26oq%3Dfloat%2Bcur
        //https://discussions.unity.com/t/how-to-add-a-sine-curve/931575/7

        Vector2 perpendicular = new Vector2(-launchDirection.y, launchDirection.x);

        position += perpendicular * curve;

        transform.position = position;

        // Check whether the boomerang touches a star.
        CollectStars();

        if (t >= 1f)
        {
            returning = true;
            timer = 0f;
            startPosition = transform.position;
        }
        else
        {
            // Progress from 0 to 1 during return.
            float t = Mathf.Clamp01(timer / returnDuration);

        }
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
