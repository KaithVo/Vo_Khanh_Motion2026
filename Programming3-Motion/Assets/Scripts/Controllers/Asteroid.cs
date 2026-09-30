
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed;
    public float arrivalDistance;
    public float maxFloatDistance;

    public Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        ChooseNewSpot();
    }

    // Update is called once per frame
    void Update()
    {
        AsteroidMovement();
    }

    void ChooseNewSpot()
    {
        //Starting from the asteroid, travel maxFloatDistance in the random direction.
        Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0 );

        targetPosition = transform.position+ randomDirection * maxFloatDistance;
    }

    public void AsteroidMovement()
    {//moving toawrd the target
        Vector3 direction = targetPosition - transform.position;

        direction = direction.normalized;//normalized it so make it just the direction


        transform.position += direction* moveSpeed* Time.deltaTime;

        float distance = Vector3.Distance(transform.position,targetPosition);

        if (distance <= arrivalDistance) //Once its close enough, consider itself there.
        {
            ChooseNewSpot();//then create a new spot
        }
    }
}
