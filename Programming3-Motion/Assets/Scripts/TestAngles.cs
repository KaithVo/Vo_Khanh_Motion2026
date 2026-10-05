//WEEK FIVE CLASS:
using UnityEngine;

public class TestAngles : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float firstAngle = 45f;
        float secondAngle = 225f;

        float firstVectorX = Mathf.Cos(45f * Mathf.Deg2Rad);
        float secondVectorX = Mathf.Cos(225f * Mathf.Deg2Rad);

        Debug.Log(firstVectorX);
        Debug.Log(secondVectorX);

    }

    // Update is called once per frame
    void Update()
    {

    }
}