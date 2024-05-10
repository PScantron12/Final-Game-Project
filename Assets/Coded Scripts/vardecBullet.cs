using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vardecBullet : MonoBehaviour
{
    public float vardecBulletSpeed = 30f;
    public Rigidbody2D vardecRb;

    // Start is called before the first frame update
    void Start()
    {
        vardecRb.velocity = (transform.right * -1) * vardecBulletSpeed;
    }

    // Update is called once per frame
    void OnTriggerEnter2D (Collider2D hitInfo)
    {

        Debug.Log(hitInfo.name);
    }
}