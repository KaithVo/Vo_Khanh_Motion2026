using UnityEngine;

public class CannonballController : MonoBehaviour
{
    public float lifespan;

    // Start is called before the first frame update
    void Start()
    {
        //After lifespan seconds, this object will be destroyed
        Destroy(gameObject, lifespan);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //collision.gameObject is the object that the cannonball collided with
        //in this case we want to check if the object that the cannonball collided with has a CannonballController script attached to it
        //so it's only destroyed when it collides with another cannonball
        if (collision.gameObject.GetComponent<CannonballController>() != null)
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
