using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingTrap : MonoBehaviour
{
    [SerializeField] private float timer = 5;

    private float bulletTime;

    public GameObject enemyBullet;

    public Transform bulletSpawnPoint;

    public float bulletSpeed;
    
    void Update()
    {
        ShootBullet();
    }

    void ShootBullet()
    {
        bulletTime -= Time.deltaTime;
        
        if(bulletTime > 0 ) return;

        bulletTime = timer;
        
        GameObject bulletObj = Instantiate(enemyBullet, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation) as GameObject;
        Rigidbody bulletRig = bulletObj.GetComponent<Rigidbody>();
        bulletRig.AddForce(bulletRig.transform.forward * bulletSpeed);
    }
}
