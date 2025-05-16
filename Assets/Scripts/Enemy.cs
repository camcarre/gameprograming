using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 1f;

    void Update()
    {
        // L'ennemi descend lentement
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
}
