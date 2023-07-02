using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float horizontalInput;
    float zAxisInput;

    public float speed;
    public Rigidbody rb;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector3 (horizontalInput * speed, rb.velocity.y, rb.velocity.z);

        zAxisInput = Input.GetAxis("Vertical");
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, zAxisInput * speed);

    }
}
