using UnityEngine;
using UnityEngine.InputSystem;

public class ForcesTest : MonoBehaviour
{
    public float forceStrength;
    public Rigidbody2D rb;


    public enum ProjecttileType
    {
        Arrow, CannonBall, Fireball, AngryBird
    }

    public void SetProjectileType(ProjecttileType type)
    {

        
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector3 mousePosition = Mouse.current.position.ReadValue();
            Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            worldMousePosition.z = 0;

            Vector3 directionToApplyForce = worldMousePosition - transform.position;

            rb.AddForce(directionToApplyForce.normalized * forceStrength);

        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision enter");
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("Collision exit");
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("Collision stay");
    }

}

