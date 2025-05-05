using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int rows = 3;
    public int columns = 5;
    public float spacing = 1.5f;

    void Start()
    {
        SpawnEnemies();
    }

    void SpawnEnemies()
    {
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                Vector3 position = new Vector3(transform.position.x + col * spacing, transform.position.y - row * spacing, 0);
                Instantiate(enemyPrefab, position, Quaternion.identity);
            }
        }
    }
}