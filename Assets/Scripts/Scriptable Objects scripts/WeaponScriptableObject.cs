using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerWeapon", menuName = "ScriptableObjects/PlayerWeapon", order = 1)]
public class WeaponScriptableObject : ScriptableObject
{
    public string weaponName;
    public float damage;
    public float coolDown;
    public float projectileSpeed;
    public float projectileLifeTime;
    public bool arced;
    public Sprite icon;
    public GameObject projectile;

    //This method shoots a projectile in a straight line
    //Projectile will hit first enemy it comes into contact with
    public void starightShoot(Transform shootingOrigin, Vector3 shootingDirection)
    {
        Vector3 originPosition = new Vector3(shootingOrigin.position.x, 1.5f, shootingOrigin.position.z);

        GameObject _projectile = Instantiate(projectile, originPosition, Quaternion.identity);

        Rigidbody projectileRB = _projectile.GetComponent<Rigidbody>();
        _projectile.GetComponent<PlayerProjectile>().setStats(damage, projectileLifeTime);

        projectileRB.AddForce(projectileSpeed * shootingDirection * 10, ForceMode.Acceleration);
    }

    //Shoots projectile in an arc to mouse position
    //Projectile only damages at that location
    public void arcShoot(Transform shootingOrigin, Transform targetPoint)
    {
        Vector3 originPosition = new Vector3(shootingOrigin.position.x, 1.5f, shootingOrigin.position.z);
        GameObject _projectile = Instantiate(projectile, originPosition, Quaternion.identity);
        _projectile.GetComponent<PlayerProjectile>().setStats(damage, projectileLifeTime);
        _projectile.GetComponent<PlayerProjectile>().arcTowardsTarget(originPosition, targetPoint.position, projectileSpeed);
    }

}
