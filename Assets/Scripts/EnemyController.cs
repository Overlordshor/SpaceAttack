using UnityEngine;
using System.Collections;

public class EnemyController : Ship
{
    public EnemyController()
    {
        timeFire = 1.5f;
        speed = 1f;
    }
    void Start()
    {
    }

    void Update()
    {
        SpaceMovement();
        LaserFire();
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
