using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameInput gameInput;
    [SerializeField] private float moveSpeed;

    private Rigidbody rb;
    private Vector3 movementVector;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        movementVector = new Vector3(inputVector.x, 0, inputVector.y);

        rb.velocity = movementVector * moveSpeed;

        Debug.Log(movementVector);
    }

    public Vector3 GetMovementVector()
    {
        return movementVector;
    }
}
