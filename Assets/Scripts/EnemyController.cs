﻿using UnityEngine;

public class EnemyController : Ship
{
    public GameObject EnemyExplosionPrefab;
    
    private AudioSource laserShot;

    private GameObject playerObject;
    private PlayerController player;
    public EnemyController()
    {
        timeFire = 1.5f;
        speed = 3f;
    }

    private void Start()
    {
        laserShot = GetComponent<AudioSource>();
        playerObject = GameObject.Find("Player");
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
            player = playerObject.gameObject.GetComponent<PlayerController>();
            player.AddScore();
            Destroy(collision.gameObject);
            Instantiate(EnemyExplosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
           
        }
        if (collision.collider.CompareTag("Player"))
        {
            player = collision.gameObject.GetComponent<PlayerController>();
            player.LifeSubstraction();
            Instantiate(player.ExplosionPrefab, player.transform.position, Quaternion.identity);
            Instantiate(EnemyExplosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if (collision.collider.CompareTag("Asteroid"))
        {
            Asteroid asteroid = collision.gameObject.GetComponent<Asteroid>();
            Instantiate(asteroid.ExplosionPrefab, asteroid.transform.position, Quaternion.identity);
            Instantiate(EnemyExplosionPrefab, transform.position, Quaternion.identity);

            Destroy(asteroid.gameObject);
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
            laserShot.Play();
            timeReloadFire = timeFire;
        }
    }
}
