using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class despawnPowerUp : MonoBehaviour
{
    

    void Start()
    {
        
    }

    void OnCollision2D(Collider2D hitInfo)
    {
        Debug.Log(hitInfo.name);
        Destroy(gameObject);
    }
}
