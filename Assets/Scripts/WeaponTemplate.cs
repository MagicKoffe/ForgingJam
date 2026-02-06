using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTemplate : MonoBehaviour
{
    public WeaponScriptableObject wpnScriptableObject;

    public void shoot(Transform _shootingOrigin, Vector3 _shootingDirection, Transform _targetPoint)
    {
        if (!wpnScriptableObject.arced)
        {
            wpnScriptableObject.starightShoot(_shootingOrigin, _shootingDirection);
        }
        else
        {
            wpnScriptableObject.arcShoot(_shootingOrigin, _targetPoint);
        }
    }
}
