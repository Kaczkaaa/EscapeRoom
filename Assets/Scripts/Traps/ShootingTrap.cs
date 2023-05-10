using System;
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

    private IEnumerator coroutine1;

    private void Start()
    {
        coroutine1 = Shooting();
        StartCoroutine(coroutine1);
    }
    

    IEnumerator Shooting()
    {
        while (true)
        {
            yield return new WaitForSeconds(timer);
            GameObject bulletObj = Instantiate(enemyBullet, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation) as GameObject;
            Rigidbody bulletRig = bulletObj.GetComponent<Rigidbody>();
            bulletRig.AddForce(bulletRig.transform.forward * bulletSpeed);
            yield return null;
        }

    }
}


/* void ShootBullet()
     {
         bulletTime -= Time.deltaTime;
         
         if(bulletTime > 0 ) return;
 
         bulletTime = timer;
         
         GameObject bulletObj = Instantiate(enemyBullet, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation) as GameObject;
         Rigidbody bulletRig = bulletObj.GetComponent<Rigidbody>();
         bulletRig.AddForce(bulletRig.transform.forward * bulletSpeed);
     }*/
