using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float Speed = 5;
    private float horizontalInput;
    private float verticalInput;
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    
    void Update()
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
        transform.Translate(Vector3.right * Time.deltaTime * Speed * horizontalInput);
        horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.up * Time.deltaTime * Speed * verticalInput);
        verticalInput = Input.GetAxis("Vertical");
    }
}
