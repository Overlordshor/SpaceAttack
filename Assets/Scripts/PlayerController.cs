﻿using UnityEngine;

public class PlayerController : Ship
{
    public GameObject ExplosionPrefab;
    public GameObject BigExplosionPrefab;

    private float horizontalInput;
    private float verticalInput;

    public void LifeSubstraction()
    {
        lives--;

        if (lives < 1)
        {
            Instantiate(BigExplosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }
  
    private void Update()
    {
        SpaceMovement();
        LaserFire();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.collider.CompareTag("LaserEnemy"))
        {
            LifeSubstraction();
            Destroy(collision.gameObject);
            Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
        }
    }

    private void SpaceMovement()
    {
        if (transform.position.x < -8.3f)
        {
            transform.position = new Vector3(-8.3f, transform.position.y, 0);
        }
        if (transform.position.x > 8.35f)
        {
            transform.position = new Vector3(8.35f, transform.position.y, 0);
        }
        if (transform.position.y < -4.321f)
        {
            transform.position = new Vector3(transform.position.x, -4.321f, 0);
        }
        if (transform.position.y > 4.33f)
        {
            transform.position = new Vector3(transform.position.x, 4.33f, 0);
        }
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
        horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.up * Time.deltaTime * speed * verticalInput);
        verticalInput = Input.GetAxis("Vertical");
    }

    protected override void LaserFire()
    {
        base.LaserFire();

        if (timeReloadFire < 0)
        {
            Instantiate(LaserPrefab, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
            timeReloadFire = timeFire;
        }
    }
}
