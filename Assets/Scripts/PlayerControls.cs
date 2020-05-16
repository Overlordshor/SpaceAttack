using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public GameObject LaserPrefab;

    private float speed;
    private float horizontalInput;
    private float verticalInput;

    private float timeFire = 0.5f;
    private float timeReloadFire;
    public PlayerControls()
    {
        speed = 5f;
        timeReloadFire = timeFire;
    }
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    
    void Update()
    {
        SpaceMovement();
        LaserFire();

    }

    private void LaserFire()
    {
        if (timeReloadFire > 0)
        {
            timeReloadFire -= Time.deltaTime;
        }       
        if (timeReloadFire < 0)
        {
                Instantiate(LaserPrefab, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
                timeReloadFire = timeFire;
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
}
