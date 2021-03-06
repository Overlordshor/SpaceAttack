﻿using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public GameObject ExplosionPrefab;

    private float speed;
    public Asteroid()
    {
        speed = 2.5f;
    }

    private void Update()
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

        if (collision.collider.CompareTag("LaserEnemy") || collision.collider.CompareTag("Laser"))
        {
            Destroy(collision.gameObject);
            Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
