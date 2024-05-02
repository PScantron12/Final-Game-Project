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

    void OnTriggerEnter2D(Collider2D collision)
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
   /* void Shoot() 
    {
        GameObject bulletToShoot;
        switch(playerDefaultRender.material.color) {
            case 'sprayGunColor':
            bulletToShoot = bulletSprayGunPrefab;
            break;
            case 'lazerGunColor':
            bulletToShoot = bulletLazerGunPrefab;
            break;
            default:
            bulletToShoot = bulletDefaultPrefab;
            break;
        }
        
        Instantiate(bulletToShoot, bulletPoint.position, bulletPoint.rotation);
    } */
    void Shoot() 
    {
        GameObject bulletToShoot = DetermineBulletType();
        if (bulletToShoot != null)
        {
            Instantiate(bulletToShoot, bulletPoint.position, bulletPoint.rotation);
        }
        else
        {
            Debug.LogError("Bullet type not recognized.");
        }
    }

    GameObject DetermineBulletType()
    {
        if (playerDefaultRender.material.color == sprayGunColor)
        {
            return bulletSprayGunPrefab;
        }
        else if (playerDefaultRender.material.color == lazerGunColor)
        {
            return bulletLazerGunPrefab;
        }
        else
        {
            return bulletDefaultPrefab;
        }
    }

}
