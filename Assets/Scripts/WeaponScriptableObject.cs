using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerWeapon", menuName = "ScriptableObjects/PlayerWeapon", order = 1)]
public class WeaponScriptableObject : ScriptableObject
{
    public string weaponName;
    public float coolDown;
    public float projectileSpeed;
    public Sprite icon;
    public GameObject projectile;
    
    //This method shoots a projectile in a straight line
    //Projectile will hit first enemy it comes into contact with
    public void starightShoot(Transform shootingOrigin, Vector3 shootingDirection)
    {
        GameObject _projectile = Instantiate(projectile, shootingOrigin.position, Quaternion.identity);
        Rigidbody projectileRB = _projectile.GetComponent<Rigidbody>();

        projectileRB.AddForce(projectileSpeed * shootingDirection, ForceMode.Acceleration);
    }

    //Shoots projectile in an arc to mouse position
    //Projectile only damages at that location
    public void arcShoot(Transform shootingOrigin, Transform targetPoint)
    {
        GameObject _projectile = Instantiate(projectile, shootingOrigin.position, Quaternion.identity);
    }

}
