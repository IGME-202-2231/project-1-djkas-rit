using System;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField]
    GameObject bulletPrefab;
    [SerializeField]
    Transform firePoint;
    [SerializeField]
    float fireRate = 0.1f;

    private float nextFireTime;

    private void Update()
    {
        // TODO: use new input system
        /*
        if (Input.GetKey(KeyCode.Z) && Time.time > nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        */
    }

    private void Shoot()
    {
        //Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Console.WriteLine("fire");
    }
}
