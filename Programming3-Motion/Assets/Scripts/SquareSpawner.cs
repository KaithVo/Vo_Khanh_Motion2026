
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SquareSpawner : MonoBehaviour
{
    //square setup
    public float squareSize = 1f;
    public float scrollSpeed = 0.5f;

    public Color color = Color.white;


    private List<Vector2> spawnedSquares = new List<Vector2>();

    void Update()
    {
        // Mouse wheel that changes the size
        float scroll = Mouse.current.scroll.ReadValue().y;

        if (scroll != 0) //if scroll isnt zero
        {
            squareSize += scroll * scrollSpeed;

            if (squareSize < 0.1f)
            {
                squareSize = 0.1f;
            }
        }


        // Left click to spawn the aquare at it's mouse postito
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            spawnedSquares.Add(mousePosition);
        }

        // Draw and keep update all spawned squares information
        for (int i = 0; i < spawnedSquares.Count; i++)
        {
            DrawSquare(spawnedSquares[i], squareSize);
        }
    }

    void DrawSquare(Vector2 position, float size)
    {
        //vector size
        Vector2 topLeft = position + new Vector2(-size, size);
        Vector2 topRight = position + new Vector2(size, size);
        Vector2 bottomLeft = position + new Vector2(-size, -size);
        Vector2 bottomRight = position + new Vector2(size, -size);

    //drawing line
        Debug.DrawLine(topLeft, topRight, color);
        Debug.DrawLine(topRight, bottomRight, color);
        Debug.DrawLine(bottomRight, bottomLeft, color);
        Debug.DrawLine(bottomLeft, topLeft, color);
    }
}