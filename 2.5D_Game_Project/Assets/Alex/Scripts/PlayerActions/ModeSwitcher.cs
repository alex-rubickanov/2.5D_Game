using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeSwitcher : MonoBehaviour
{
    [SerializeField] private bool isFPS = false;

     private PlayerMovementTopDown topDownMovement;
     private PlayerMovement fpsMovement;

     private PlayerRotationTopDown topdownRotation;

    [SerializeField] private GameObject fpsCamera;
    [SerializeField] private GameObject topdownCamera;


    private void Awake()
    {
        topDownMovement = GetComponent<PlayerMovementTopDown>();
        fpsMovement = GetComponent<PlayerMovement>();

        topdownRotation = GetComponent<PlayerRotationTopDown>();
    }

    private void Start()
    {
        ChangeMode();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            ChangeMode();
        }
    }

    private void ChangeMode()
    {
        if(isFPS) // Make topdown
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;

            isFPS = false;
            topdownCamera.SetActive(true);
            topDownMovement.enabled = true;
            topdownRotation.enabled = true;

            fpsCamera.SetActive(false);
            fpsMovement.enabled = false;
        } else
        {
            Cursor.visible = false;

            isFPS=true;

            fpsCamera.SetActive(true);
            fpsMovement.enabled = true;


            topdownCamera.SetActive(false);
            topDownMovement.enabled = false;
            topdownRotation.enabled = false;
        }
    }
}
