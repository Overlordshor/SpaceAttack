using UnityEngine;

public class LaserController : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }
}
