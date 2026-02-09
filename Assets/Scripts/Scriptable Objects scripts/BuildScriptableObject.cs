using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerBuilding", menuName = "ScriptableObjects/PlayerBuilding", order = 2)]

public class BuildScriptableObject : ScriptableObject
{
    public string buildingName;
    public float damage;
    public float health;
    public float range;
    public int cost;

    public float fireRate;
    public float projectileSpeed;
    public float projectileLifeTime;
    public bool tracking;
    public Sprite icon;
    public GameObject buildingModel;
    public GameObject projectile;
}
