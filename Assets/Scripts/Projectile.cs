using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        // Déplace le projectile vers le haut
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        // Le détruire s’il sort de l’écran
        if (transform.position.y > 10f)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null && other.CompareTag("Enemy"))
        {
            // Ajoute le score
            GameObject gm = GameObject.Find("GameManager");
            if (gm != null)
            {
                gm.GetComponent<GameManager>().AddScore(100);
            }

            Destroy(other.gameObject); // Détruit l’ennemi
            Destroy(gameObject);       // Détruit le projectile
        }
    }
}
