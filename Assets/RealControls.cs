using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Speeds { slow = 0, normal = 1, fast = 2, faster = 3, fastest = 4 };
public class RealControls : MonoBehaviour
{
    //takes selected speed 1-4
    public Speeds currentSpeed;
    //correlates to selected speed
    float[] speedVals = { 8.6f, 10.4f, 12.96f, 15.6f, 20.77f };

    public Transform GroundCheckTrans;
    public float GroundCheckRad;
    public LayerMask GroundMask;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        //transforms position by x number of units determined by selected speed i.e. 8.6 units per second for slower, 10.4 for normal, etc
        transform.position += Vector3.right * speedVals[(int)currentSpeed] * Time.deltaTime;

        //determines jump button
        if (Input.GetKey("space"))
        {
            if (isOnGround())
            {
                rb.velocity = Vector2.zero;
                rb.AddForce(Vector2.up * 35f, ForceMode2D.Impulse);
            }
        }
    }

    bool isOnGround()
    {
        return Physics2D.OverlapCircle(GroundCheckTrans.position, GroundCheckRad, GroundMask);
    }
}
