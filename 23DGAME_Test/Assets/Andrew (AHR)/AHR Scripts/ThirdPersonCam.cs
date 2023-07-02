using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCam : MonoBehaviour
{
    public Transform orientation;
    public Transform player;
    public Transform playerBody;
    public Rigidbody rb;

    public float rotationSpeed;

    public Transform combatPerspective;

    public CameraModes currentStyle;

    public enum CameraModes
    {
        Default,
        Combat,
        TopDown
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 viewDirection = player.position - new Vector3(transform.position.x, transform.position.y, transform.position.z);
        orientation.forward = viewDirection.normalized;


        if(currentStyle == CameraModes.Default)
        {
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float verticalInput = Input.GetAxisRaw("Vertical");

            Vector3 inputDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

            if (inputDirection != Vector3.zero)
            {
                playerBody.forward = Vector3.Slerp(playerBody.forward, inputDirection.normalized, Time.deltaTime * rotationSpeed);
            }
        }

        else if(currentStyle == CameraModes.Combat)
        {
            Vector3 combatDirection = combatPerspective.position - new Vector3(transform.position.x, transform.position.y, transform.position.z);
            orientation.forward = combatDirection.normalized;

            playerBody.forward = combatDirection.normalized;
        }
       
    }
}
