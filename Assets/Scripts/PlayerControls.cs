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
        transform.Translate(Vector3.right * Time.deltaTime * Speed * horizontalInput);
        horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.up * Time.deltaTime * Speed * verticalInput);
        verticalInput = Input.GetAxis("Vertical");
    }
}
