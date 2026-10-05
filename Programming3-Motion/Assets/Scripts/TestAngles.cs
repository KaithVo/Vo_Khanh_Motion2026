using UnityEngine;

public class TestAngles : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //float firstAngle = 45f;
        //float secondAngle = 315f;

        //float firstVectorX = Mathf.Cos(45f * Mathf.Deg2Rad);
        //float secondVectorX = Mathf.Cos(315f * Mathf.Deg2Rad);

        //Debug.Log(firstVectorX);
        //Debug.Log(secondVectorX);

        //float firstAngleAgain = Mathf.Acos(firstVectorX) * Mathf.Rad2Deg;
        //float secondAngleAgain = Mathf.Acos(secondVectorX) * Mathf.Rad2Deg;

        //Debug.Log(firstAngleAgain);
        //Debug.Log(secondAngleAgain);

        //float x = 0.7f;
        //float y = -0.7f;

        //float angle = Mathf.Atan(y / x);

        //float x2 = -0.7f;
        //float y2 = 0.7f;
        //float angle2 = Mathf.Atan(y2 / x2);

        //Mathf.Atan2(0.7f, -0.7f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Convert from a vector to an angle based around the x-axis
    public static float VectorToAngle(Vector3 inVector)
    {
        float angle = Mathf.Atan2(inVector.y, inVector.x) * Mathf.Rad2Deg;

        return angle;
    }

}