using UnityEngine;

public class EnemyController : Ship
{
    public GameObject EnemyExplosionPrefab;
    public EnemyController()
    {
        timeFire = 1.5f;
        speed = 3f;
    }
    void Start()
    {
    }

    void Update()
    {
        SpaceMovement();
        LaserFire();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Laser"))
        {
            Destroy(collision.gameObject);
            Instantiate(EnemyExplosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if (collision.collider.CompareTag("Player"))
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            player.LifeSubstraction();
            Instantiate(player.ExplosionPrefab, player.transform.position, Quaternion.identity);
            Instantiate(EnemyExplosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    private void SpaceMovement()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
        if (transform.position.y < -5.63f)
        {
            transform.position = new Vector3(Random.Range(-7.88f, 8.01f), 6.38f, 0);
        }
    }

    protected override void LaserFire()
    {
        base.LaserFire();

        if (timeReloadFire < 0)
        {
            Instantiate(LaserPrefab, transform.position - new Vector3(0, 0.5f, 0), Quaternion.identity);
            timeReloadFire = timeFire;
        }
    }
}
