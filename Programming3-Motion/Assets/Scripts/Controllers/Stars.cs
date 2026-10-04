using UnityEngine;
using System.Collections.Generic;

public class Stars : MonoBehaviour
{
    public List<Transform> starTransforms;
    public float drawingTime;
    public LineRenderer lineRenderer;

    // Update is called once per frame
    void Update()
    {
        DrawConstellation();

    }

    public void DrawConstellation()
    {
        Vector3 startPoint = starTransforms[0].position;
        Vector3 endPoint = starTransforms[1].position;

        for (int i = 0; i < starTransforms.Count - 1; i++)
        {
            startPoint = starTransforms[i].position;
            endPoint = starTransforms[i + 1].position;

            // Draw the line
            lineRenderer.SetPosition(0, startPoint);
            lineRenderer.SetPosition(1, endPoint);
        }
    }
}
