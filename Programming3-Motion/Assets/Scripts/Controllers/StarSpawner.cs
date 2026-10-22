
using UnityEngine;

public class StarSpawner : MonoBehaviour
{
   //stars setting
    public GameObject starPrefab;
    public int starCount = 10;

//random stars
    public Vector2 spawnMin = new Vector2(-7f, -3f);
    public Vector2 spawnMax = new Vector2(7f, 4f);
//Boomerang reference
    public Boomerang boomerang;

    void Start()
    {
        // Spawn stars when the game begins
        for (int i = 0; i < starCount; i++)
        {
            // Pick a random position
            float randomX = Random.Range(spawnMin.x, spawnMax.x);
            float randomY = Random.Range(spawnMin.y, spawnMax.y);

            Vector2 spawnPosition = new Vector2(randomX, randomY);

            // Create a star at that position
            GameObject newStar = Instantiate(
                starPrefab,
                spawnPosition,
                Quaternion.identity
            );

            // Add the new star to the boomerang's list
            boomerang.stars.Add(newStar.transform);
        }
    }
}
