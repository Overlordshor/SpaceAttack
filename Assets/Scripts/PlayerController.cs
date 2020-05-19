using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : Ship
{
    public GameObject ExplosionPrefab;
    public GameObject BigExplosionPrefab;
    public Animator PlayerAnimator;

    private float horizontalInput;
    private float verticalInput;

    private AudioSource laserShot;
    public void LifeSubstraction()
    {
        lives--;

        if (lives < 1)
        {
            Instantiate(BigExplosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }
    private void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        laserShot = GetComponent<AudioSource>();
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
        if (collision.collider.CompareTag("Asteroid"))
        {
            Asteroid asteroid = collision.gameObject.GetComponent<Asteroid>();
            Instantiate(asteroid.ExplosionPrefab, asteroid.transform.position, Quaternion.identity);
            Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);

            LifeSubstraction();

            Destroy(asteroid.gameObject);
        }
    }

    private void SpaceMovement()
    {
        MoveThroughScreen();

        MoveHorizontal();
        MoveVertical();

        TurnAnimation();
    }

    private void MoveVertical()
    {
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * Time.deltaTime * speed * verticalInput);     
    }

    private void MoveHorizontal()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);   
    }

    private void MoveThroughScreen()
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
    }

    private void TurnAnimation()
    {
        if (horizontalInput > 0)
        {
            PlayerAnimator.SetBool("Left", false);
            PlayerAnimator.SetBool("Right", true);
        }
        if (horizontalInput < 0)
        {
            PlayerAnimator.SetBool("Left", true);
            PlayerAnimator.SetBool("Right", false);
        }
        if (horizontalInput == 0)
        {
            PlayerAnimator.SetBool("Left", false);
            PlayerAnimator.SetBool("Right", false);
        }
        horizontalInput = 0;
    }

    protected override void LaserFire()
    {
        base.LaserFire();

        if (timeReloadFire < 0)
        {
            Instantiate(LaserPrefab, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
            laserShot.Play();
            timeReloadFire = timeFire;
        }
    }
}
