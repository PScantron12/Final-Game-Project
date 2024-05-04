using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

public class Vardecweapon : MonoBehaviour
{
    public Transform vardecBulletPoint;
    public GameObject vardecBulletPrefab;

    void Start()
    {
        
    }
    void Update()
    {
        Timer vardecBulletCooldown = new Timer();
        vardecBulletCooldown.Interval = 3000;
        vardecBulletCooldown.Elapsed += VardecBulletCooldown_Elapsed;
    }

    private void VardecBulletCooldown_Elapsed(object sender, ElapsedEventArgs e)
    {
        vardecShoot();
    }

    void vardecShoot()
    {
        GameObject vardecBulletToShoot = vardecBulletPrefab;
        Instantiate(vardecBulletToShoot, vardecBulletPoint.position, vardecBulletPoint.rotation);
    }
}

