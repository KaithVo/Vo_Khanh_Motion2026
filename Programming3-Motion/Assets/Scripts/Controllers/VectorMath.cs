using UnityEngine;
using UnityEngine.InputSystem;

public class VectorMath : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentMousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        DrawSquare(currentMousePosition, 0.5f, Color.red, 5f);
    }

    public float GetMagnitude(Vector2 vector)
    {
        return Mathf.Sqrt(vector.x * vector.x + vector.y * vector.y);
    }

    public static void DrawSquare(Vector2 centerPoint, float size, Color colour, float duration)
    //static method can be called anywhere without creating an instance of the class, like VectorMath.DrawSquare() in the Update method above
    //instance method can only be called on an instance of the class, as in GetMagnitude() above, which is called on an instance of the class,
    //like VectorMath vectorMath = new VectorMath(); float magnitude = vectorMath.GetMagnitude(vector);
    {
        //VectorMath.DrawSquare();

        //EXAMPLES OF STATIC METHODS THAT WE CAN CALL ANYWHERE:
        //Vector2.Distance();
        //Debug.Log();
        //Mathf.Sqrt()

        //Center point & the size

        //Color

        //Duration how long to show

        //TOP LINE:
        Vector2 startPoint = centerPoint + new Vector2(-size, size);
        Vector2 endPoint = centerPoint + new Vector2(size, size);

        Debug.DrawLine(startPoint, endPoint, colour, duration);

        //LEFT LINE:
        startPoint = centerPoint + new Vector2(-size, size);
        endPoint = centerPoint + new Vector2(-size, -size);

        Debug.DrawLine(startPoint, endPoint, colour, duration);

        //BOTTOM LINE:
        startPoint = centerPoint + new Vector2(-size, -size);
        endPoint = centerPoint + new Vector2(size, -size);

        Debug.DrawLine(startPoint, endPoint, colour, duration);

        //RIGHT LINE:
        startPoint = centerPoint + new Vector2(size, -size);
        endPoint = centerPoint + new Vector2(size, size);

        Debug.DrawLine(startPoint, endPoint, colour, duration);

    }

}


