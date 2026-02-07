using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    Transform player;
    Vector3 aimDirection;

    public GameObject enemyProjectile;
    public float projectileSpeed;
    public float damage;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        getAimDirection();
    }

    public void shootTarget()
    {
        Vector3 originPosition = new Vector3(transform.position.x, 1.5f, transform.position.z);

        GameObject _projectile = Instantiate(enemyProjectile, originPosition, Quaternion.identity);
        Rigidbody projectileRB = _projectile.GetComponent<Rigidbody>();
        _projectile.GetComponent<PlayerProjectile>().setDamage(damage);

        projectileRB.AddForce(projectileSpeed * aimDirection * 10, ForceMode.Acceleration);
    }

    private void getAimDirection()
    {
        aimDirection = (player.position - transform.position).normalized;
        aimDirection.y = 0;
        Debug.DrawLine(transform.position, aimDirection * 300);
    }
}
