using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 1f;

    void Update()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Projectile"))
        {
            Destroy(gameObject);
        }
    }
}