using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 1f;

    void Update()
    {
        // enemy moves downwards
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
}
