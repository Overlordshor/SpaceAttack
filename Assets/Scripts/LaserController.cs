using UnityEngine;

public class LaserController : MonoBehaviour
{
    private float speed = 20f;
    private void Start()
    {
        
    }


    private void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);

        if (transform.position.y >= 5.36f)
        {
            Destroy(gameObject, 0.1f);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
