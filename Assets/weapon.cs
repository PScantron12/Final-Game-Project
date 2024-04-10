using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public Transform bulletPoint;
    public GameObject bulletPrefab;
    void Update()
    {
        if (Input.GetButtonDown("Fire3"))
        {
            Shoot();
        }
        
    }
    void Shoot() 
    {
        Instantiate(bulletPrefab, bulletPoint.position, bulletPoint.rotation);
    }
}
