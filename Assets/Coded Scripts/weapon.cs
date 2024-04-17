using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public Transform bulletPoint;
    public GameObject bulletDefaultPrefab;
    public GameObject bulletSprayGunPrefab;
    public GameObject bulletLazerGunPrefab;
    public Color defaultColor;
    public Color shieldColor;
    public Color sprayGunColor;
    public Color lazerGunColor;
    public Renderer playerDefaultRender;

    void Start()
    {
        playerDefaultRender = GetComponent<Renderer>();
        defaultColor = playerDefaultRender.material.color;
    }

    void OnTriggerEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("ShieldTag"))
        {
            
            playerDefaultRender.material.color = shieldColor;
   
        }
        if (collision.gameObject.CompareTag("SprayGunTag"))
        {

            playerDefaultRender.material.color = sprayGunColor;

        }
        if (collision.gameObject.CompareTag("LazerPower"))
        {

            playerDefaultRender.material.color = lazerGunColor;

        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire3"))
        {
            Shoot();
        }
        
    }
    void Shoot() 
    {
        GameObject bulletToShoot;
        if (playerDefaultRender.material.color == sprayGunColor)
        {
            bulletToShoot = bulletSprayGunPrefab;
        }
        else if (playerDefaultRender.material.color == lazerGunColor)
        {
            bulletToShoot = bulletLazerGunPrefab;
        }
        else
        {
            bulletToShoot = bulletDefaultPrefab;
        }
        Instantiate(bulletToShoot, bulletPoint.position, bulletPoint.rotation);
    }
}
