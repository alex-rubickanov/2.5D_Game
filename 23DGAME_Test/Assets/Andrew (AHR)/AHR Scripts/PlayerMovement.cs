using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float x;
    [SerializeField] private float z;
    [SerializeField] private float speed;

    public Transform orientation;

    public Rigidbody rb;

    Vector3 moveDirect;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        orientation.rotation = Quaternion.Euler(0, transform.rotation.y, 0);
        PlayerInput();
    }

    private void FixedUpdate()
    {
        PlayerMove();
    }

    void PlayerInput()
    {
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");
    }

    void PlayerMove()
    {
        moveDirect = orientation.forward * z + orientation.right * x;
    }
}
