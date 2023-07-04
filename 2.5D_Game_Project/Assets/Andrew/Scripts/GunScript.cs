using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public Camera fpsCamera;

    public float fireRate;
    public float reloadTime;
    public float range;
    public int ammoCapacity;
    private int bulletsRemaining;

    bool shooting, readyToFire, reloading;

    public RaycastHit rayHit;

    public LayerMask whatIsEnemy;

    // Start is called before the first frame update
    void Start()
    {
        bulletsRemaining = ammoCapacity;
        readyToFire = true;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();
    }

    void PlayerInput()
    {
        shooting = (Input.GetKey(KeyCode.Mouse0));

        if (Input.GetKeyDown(KeyCode.R) && bulletsRemaining < ammoCapacity && !reloading) Reload();

        ///conditions to shoot
        if (readyToFire && shooting && !reloading && bulletsRemaining > 0)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        readyToFire = false;

        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out rayHit, range, whatIsEnemy))
        {
            Debug.Log(rayHit.collider.name);
        }

        bulletsRemaining--;

        Invoke("ResetShot", fireRate);
    }

    void ResetShot()
    {
        readyToFire = true;
    }

    void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }

    void ReloadFinished()
    {
        bulletsRemaining = ammoCapacity;
        reloading = false;
    }

   
}
