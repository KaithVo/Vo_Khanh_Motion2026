using UnityEngine;
using UnityEngine.InputSystem;

public class GunshipController : MonoBehaviour
{
    public Transform leftCannon;
    public Transform rightCannon;

    public GameObject cannonballPrefab;
    public float cannonballForce = 150f;

    void Update()
    {
        //Takes the mouse position in screen coordinates (pixels) and converts it to world coordinates
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        
        //These methods aim the cannons based on where the mouse is in the 2D space
        Vector3 leftDirection = AimCannon(mousePosition, leftCannon);
        Vector3 rightDirection = AimCannon(mousePosition, rightCannon);

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            //If the left mouse button was pressed this frame, we want to fire a cannonball from the left cannon
            GameObject cannonball = Instantiate(cannonballPrefab, leftCannon.position, Quaternion.identity);
            // add force to the cannonball in the direction that the cannon is facing
            Rigidbody2D rb = cannonball.GetComponent<Rigidbody2D>();
            rb.AddForce(leftDirection.normalized * cannonballForce);
        }

        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            //If the right mouse button was pressed this frame, we want to fire a cannonball from the right cannon
            GameObject cannonball = Instantiate(cannonballPrefab, rightCannon.position, Quaternion.identity);
            // add force to the cannonball in the direction that the cannon is facing
            Rigidbody2D rb = cannonball.GetComponent<Rigidbody2D>();
            rb.AddForce(rightDirection.normalized * cannonballForce);
        }
    }

    //Given a target position and the transform of a cannon, aims that cannon at that target
    private Vector3 AimCannon(Vector3 target, Transform cannon)
    {
        Vector3 direction = target - cannon.position;
        //If the z-valids are offset from each other, we don't want the cannons to rotate based on that
        direction.z = 0;

        //Converts the direction that we want to face into an angle
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        
        cannon.eulerAngles = new Vector3(0, 0, angle);

        //We also then finally return the direction that we want to aim based on the target
        return direction;
    }

    //if the canon ball collides with something, destroy it
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision enter");
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("Collision exit");
        Destroy(collision.gameObject);
    }

}
