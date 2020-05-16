using UnityEngine;

public class LaserEnemyController : MonoBehaviour
{
    private float speed = 20f;
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);

        if (transform.position.y <= -5.55f)
        {
            Destroy(gameObject, 0.1f);
        }
    }
}
