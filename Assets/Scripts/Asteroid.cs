using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public GameObject ExplosionPrefab;

    private float speed;
    public Asteroid()
    {
        speed = 2.5f;    }

    void Update()
    {
        SpaceMovement();
    }

    private void SpaceMovement()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
        if (transform.position.x < -9.2f)
        {
            transform.position = new Vector3(9.2f, Random.Range(-4.08f, 3.82f), 0);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if (collision.collider.CompareTag("Laser"))
        {
            Destroy(collision.gameObject);
            Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if (collision.collider.CompareTag("Player"))
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            player.LifeSubstraction();
            Instantiate(player.ExplosionPrefab, player.transform.position, Quaternion.identity);
            Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
