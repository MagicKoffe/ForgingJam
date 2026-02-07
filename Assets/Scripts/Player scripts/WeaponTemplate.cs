using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponTemplate : MonoBehaviour
{
    public WeaponScriptableObject wpnScriptableObject;
    public Image iconLocation;
    public Image iconCooldown;

    float weaponCooldown; //The cooldonw of the wepaon
    float cooldownTimer;  //Timer used to keep track of the cooldown coutdown

    private void Start()
    {
        weaponCooldown = wpnScriptableObject.coolDown;
        iconLocation.sprite = wpnScriptableObject.icon;
    }

    public void shoot(Transform _shootingOrigin, Vector3 _shootingDirection, Transform _targetPoint)
    {
        if (cooldownTimer > 0)
            return;
        cooldownTimer = weaponCooldown;
        if (!wpnScriptableObject.arced)
        {
            wpnScriptableObject.starightShoot(_shootingOrigin, _shootingDirection);
        }
        else
        {
            wpnScriptableObject.arcShoot(_shootingOrigin, _targetPoint);
        }
    }


    private void Update()
    {
        cooldownTimer -= Time.deltaTime;

        if (cooldownTimer > 0)
        {
            iconCooldown.fillAmount = cooldownTimer / weaponCooldown;
        }
        else
        {
            iconCooldown.fillAmount = 0;
        }
    }
}
