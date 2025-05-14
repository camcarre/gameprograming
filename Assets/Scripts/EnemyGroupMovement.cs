using UnityEngine;

public class EnemyGroupMovement : MonoBehaviour
{
    public float speed = 2f;
    public float moveDistance = 6f;
    public float descendAmount = 0.5f;

    private float direction = 1f;
    private float startX;

    void Start()
    {
        startX = transform.position.x;
    }

    void Update()
    {
        transform.Translate(Vector3.right * direction * speed * Time.deltaTime);

        if (Mathf.Abs(transform.position.x - startX) >= moveDistance)
        {
            direction *= -1f;
            transform.position += Vector3.down * descendAmount;
            startX = transform.position.x;
        }
    }
}