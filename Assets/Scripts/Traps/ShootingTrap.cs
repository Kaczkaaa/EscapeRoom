using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;


public class ShootingTrap : MonoBehaviour
{
    [SerializeField] private float timer = 5;

    private float bulletTime;

    public GameObject enemyBullet;

    public Transform bulletSpawnPoint;

    public float bulletSpeed;
    
    private bool isInTrigger;

    private AudioSource shootSound;

    private void Awake()
    {
        shootSound = GetComponent<AudioSource>();
    }

    private void Start()
    {
        isInTrigger = false;
    }
    
    IEnumerator Shooting()
    {
        while (isInTrigger)
        {
            yield return new WaitForSeconds(timer);
            GameObject bulletObj = Instantiate(enemyBullet, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation) as GameObject;
            Rigidbody bulletRig = bulletObj.GetComponent<Rigidbody>();
            bulletRig.AddForce(bulletRig.transform.forward * bulletSpeed);
            shootSound.Play();
            yield return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isInTrigger = true;
            StartCoroutine(Shooting());
            Debug.Log(isInTrigger);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isInTrigger = false;
            StopCoroutine(Shooting());
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
