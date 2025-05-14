using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;

    void Start()
    {
        Destroy(gameObject, 3f);
    }

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            if (scoreManager != null)
            {
                scoreManager.AddScore(10);
            }

            Destroy(other.gameObject); 
            Destroy(gameObject);     
        }
    }
}


