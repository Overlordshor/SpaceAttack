using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : Ship
{
    public GameObject ExplosionPrefab;
    public GameObject BigExplosionPrefab;
    public Animator PlayerAnimator;

    public int Score;

    public Slider HealthBar;
    public GameObject HealthBarFill;

    private float horizontalInput;
    private float verticalInput;

    private AudioSource laserShot;
    public void LifeSubstraction()
    {
        Lifes--;

        if (Lifes < 1)
        {
            Instantiate(BigExplosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }

    public void AddScore()
    {
        Score++;
    }

    private void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        laserShot = GetComponent<AudioSource>();
    }
  
    private void Update()
    {
        SetHealthBar();
        SpaceMovement();
        LaserFire();
    }

    private void SetHealthBar()
    {
        HealthBar.value = Lifes;
        switch (Lifes)
        {
            case 5: HealthBarFill.GetComponent<Image>().color = new Color(0, 1f, 0); break;
            case 4: HealthBarFill.GetComponent<Image>().color = new Color(0.5f, 1f, 0); break;
            case 3: HealthBarFill.GetComponent<Image>().color = new Color(1f, 1f, 0); break;
            case 2: HealthBarFill.GetComponent<Image>().color = new Color(1f, 0.5f, 0); break;
            case 1: HealthBarFill.GetComponent<Image>().color = new Color(1f, 0, 0); break;

        }
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 100), "Очки: " + Score);
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
