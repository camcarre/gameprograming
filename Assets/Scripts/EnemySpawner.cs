using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Paramètres de spawn")]
    public GameObject enemyPrefab;
    public float spawnInterval = 2f;
    public float spawnXMin = -7f;
    public float spawnXMax = 7f;
    public float spawnY = 5f;

    void Start()
    {
        // Répète la fonction SpawnEnemy à intervalle régulier
        InvokeRepeating(nameof(SpawnEnemy), 1f, spawnInterval);
    }

    void SpawnEnemy()
    {
        // Position X aléatoire entre spawnXMin et spawnXMax
        float randomX = Random.Range(spawnXMin, spawnXMax);
        Vector2 spawnPosition = new Vector2(randomX, spawnY);

        // Crée un nouvel ennemi
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
