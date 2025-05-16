using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Déplacement")]
    public float speed = 5f;
    public float minX = -7.5f;
    public float maxX = 7.5f;

    [Header("Tir")]
    public GameObject projectilePrefab;
    public Transform firePoint;

    void Update()
    {
        Déplacer();
        GérerTir();
    }

    void Déplacer()
    {
        float move = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * move * speed * Time.deltaTime);

        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        transform.position = pos;
    }

    void GérerTir()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Tirer();
        }
    }

    void Tirer()
    {
        Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
    }
}
