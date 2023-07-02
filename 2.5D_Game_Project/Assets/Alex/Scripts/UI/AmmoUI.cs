using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class AmmoUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ammoText;
    [SerializeField] private ShootHandler shootScript;
    [SerializeField] private GameObject reloadingIcon;
    private Animator reloadingAnimator;

    private const string IS_RELOADING = "IsReloading";

    private void Start()
    {
        shootScript.OnShotAction += ShootScript_OnAmmoValueChanged;

        reloadingAnimator = reloadingIcon.GetComponent<Animator>();
        Hide(reloadingIcon);
    }

    private void Update()
    {
        ReloadingAnimation();
    }

    private void ReloadingAnimation()
    {
        if (shootScript.IsReloading()) {
            Hide(ammoText.gameObject);
            Show(reloadingIcon);
            reloadingAnimator.SetBool(IS_RELOADING, true);
        } else {
            Hide(reloadingIcon);
            Show(ammoText.gameObject);
            reloadingAnimator.SetBool(IS_RELOADING, false);
        }
    }

    private void ShootScript_OnAmmoValueChanged(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        ammoText.text = shootScript.GetCurrentAmmo().Item1.ToString() + "/" + shootScript.GetCurrentAmmo().Item2.ToString(); 
    }

    private void Show(GameObject ui)
    {
        ui.SetActive(true);
    }

    private void Hide(GameObject ui)
    {
        ui.SetActive(false);
    }
}
