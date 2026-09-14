using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ROwSpawner : MonoBehaviour
{

    public TMP_InputField NumberInput;
    //square information
    public float squareSize = 1f;

    //row position in the middle of the sxreen
    public Vector2 rowPosition = new Vector2(0f, 0f);

    public Color color = Color.white;

    void Start()
    {

    }
    void Update()
    {
        
    }

    public void GenerateRow()
    {
        //trnaslate the text input into square
        int squareNumber= int.Parse(NumberInput.text);

        // Generate the row of squares
        for (int i = 0; i < squareNumber; i++)
        {
            float xPosition = rowPosition.x + i * squareSize;

            Vector2 squarePosition = new Vector2(xPosition,rowPosition.y);

            DrawSquare(squarePosition, squareSize);
        }
    }

    void DrawSquare(Vector2 position, float size)
    {
        //vector size
        Vector2 topLeft = position + new Vector2(-size, size);
        Vector2 topRight = position + new Vector2(size, size);
        Vector2 bottomLeft = position + new Vector2(-size, -size);
        Vector2 bottomRight = position + new Vector2(size, -size);


        Debug.DrawLine(topLeft, topRight, color,100f);
        Debug.DrawLine(topRight, bottomRight, color, 100f);
        Debug.DrawLine(bottomRight, bottomLeft, color, 100f);
        Debug.DrawLine(bottomLeft, topLeft, color, 100f);
    }
}