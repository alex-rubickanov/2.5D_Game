using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ShootHandler : MonoBehaviour
{
    [SerializeField] private GameInput gameInput;

    [SerializeField] private Transform leftSpawner;
    [SerializeField] private Transform rightSpawner;

    [SerializeField] private Transform bulletPrefab;
    [SerializeField] private float bulletSpeed = 10f;

    [SerializeField] private int maxAmmoInGun = 12;
    
    private int leftGunCurrentAmmo;
    private int rightGunCurrentAmmo;
    public event EventHandler OnAmmoValueChanged;

    [SerializeField] private float timeToReload;
    private bool isReloading;

    [SerializeField] private GameObject shootingVFX; 

    private void Start()
    {
        gameInput.OnLeftShootAction += GameInput_OnLeftShootAction;
        gameInput.OnRightShootAction += GameInput_OnRightShootAction;
        gameInput.OnReloadAction += GameInput_OnReloadAction;

        leftGunCurrentAmmo = maxAmmoInGun;
        rightGunCurrentAmmo = maxAmmoInGun;
        OnAmmoValueChanged?.Invoke(this, EventArgs.Empty);
    }

    private void GameInput_OnReloadAction(object sender, System.EventArgs e)
    {
        StartCoroutine(Reloading());
    }

    private void GameInput_OnRightShootAction(object sender, System.EventArgs e)
    {
        if(rightGunCurrentAmmo > 0) {
            Shoot(rightSpawner);
            rightGunCurrentAmmo--;

            OnAmmoValueChanged?.Invoke(this, EventArgs.Empty);
            GameObject particle = Instantiate(shootingVFX, rightSpawner.position, Quaternion.identity);
            Destroy(particle, 3f);
        }
    }

    private void GameInput_OnLeftShootAction(object sender, System.EventArgs e)
    {
        if(leftGunCurrentAmmo > 0) {
            Shoot(leftSpawner);
            leftGunCurrentAmmo--;

            OnAmmoValueChanged?.Invoke(this, EventArgs.Empty);
            GameObject particle = Instantiate(shootingVFX, leftSpawner.position, Quaternion.identity);
            Destroy(particle, 3f);
        }
    }

    private void Shoot(Transform bulletSpawnerTransform)
    {
        Transform bulletTransform = Instantiate(bulletPrefab, bulletSpawnerTransform.position, Quaternion.identity);
        bulletTransform.GetComponent<Rigidbody>().AddForce(bulletSpawnerTransform.forward * bulletSpeed, ForceMode.Impulse);

        Destroy(bulletTransform.gameObject, 3f);
    }

    public (int, int) GetCurrentAmmo()
    {
        return (leftGunCurrentAmmo, rightGunCurrentAmmo);
    }

    private IEnumerator Reloading()
    {
        isReloading = true;
        yield return new WaitForSeconds(timeToReload);

        leftGunCurrentAmmo = maxAmmoInGun;
        rightGunCurrentAmmo = maxAmmoInGun;
        isReloading = false;
        OnAmmoValueChanged?.Invoke(this, EventArgs.Empty);
    }

    public bool IsReloading()
    {
        return isReloading;
    }
}
