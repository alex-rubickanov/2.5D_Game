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
    public event EventHandler OnShotAction;

    [SerializeField] private float timeToReload;
    private bool isReloading;

    [SerializeField] private GameObject shootingVFX;

    [SerializeField] private AudioClip gunShotSFX;
    [SerializeField] private AudioClip reloadingSFX;

    private void Start()
    {
        gameInput.OnLeftShootAction += GameInput_OnLeftShootAction;
        gameInput.OnRightShootAction += GameInput_OnRightShootAction;
        gameInput.OnReloadAction += GameInput_OnReloadAction;

        leftGunCurrentAmmo = maxAmmoInGun;
        rightGunCurrentAmmo = maxAmmoInGun;
        OnShotAction?.Invoke(this, EventArgs.Empty);
    }

    private void GameInput_OnReloadAction(object sender, System.EventArgs e)
    {
        if(!isReloading) {
            StartCoroutine(Reloading());
        }
    }

    private void GameInput_OnRightShootAction(object sender, System.EventArgs e)
    {
        if(rightGunCurrentAmmo > 0 && !isReloading) {
            Shoot(rightSpawner);
            rightGunCurrentAmmo--;

            OnShotAction?.Invoke(this, EventArgs.Empty);

            GameObject particle = Instantiate(shootingVFX, rightSpawner.position, rightSpawner.rotation);
            AudioSource.PlayClipAtPoint(gunShotSFX, rightSpawner.position);
            Destroy(particle, 3f);
        }
    }

    private void GameInput_OnLeftShootAction(object sender, System.EventArgs e)
    {
        if(leftGunCurrentAmmo > 0 && !isReloading) {
            Shoot(leftSpawner);
            leftGunCurrentAmmo--;

            OnShotAction?.Invoke(this, EventArgs.Empty);

            GameObject particle = Instantiate(shootingVFX, leftSpawner.position, leftSpawner.rotation);
            AudioSource.PlayClipAtPoint(gunShotSFX, leftSpawner.position);
            Destroy(particle, 3f);
        }
    }

    private void Shoot(Transform bulletSpawnerTransform)
    {
        Transform bulletTransform = Instantiate(bulletPrefab, bulletSpawnerTransform.position, rightSpawner.rotation);
        bulletTransform.GetComponent<Rigidbody>().AddForce(bulletSpawnerTransform.forward * bulletSpeed, ForceMode.Impulse);

        Destroy(bulletTransform.gameObject, 3f);
    }

    public (int, int) GetCurrentAmmo()
    {
        return (leftGunCurrentAmmo, rightGunCurrentAmmo);
    }

    private IEnumerator Reloading()
    {
        AudioSource.PlayClipAtPoint(reloadingSFX, gameObject.transform.position);
        isReloading = true;
        yield return new WaitForSeconds(timeToReload);

        leftGunCurrentAmmo = maxAmmoInGun;
        rightGunCurrentAmmo = maxAmmoInGun;
        isReloading = false;
        OnShotAction?.Invoke(this, EventArgs.Empty);
    }

    public bool IsReloading()
    {
        return isReloading;
    }
}
