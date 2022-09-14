using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMover : MonoBehaviour
{
    Rigidbody2D rb;
    float speed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        RBVelocityHandler();
        SpeedHandler();
    }

    void SpeedHandler()
    {
        if (TriggerController.score < 11)
            speed = 2;
        else if (TriggerController.score < 21)
            speed = 2.5f;
        else if (TriggerController.score < 31)
            speed = 3;
        else if (TriggerController.score < 41)
            speed = 4;
        else if (TriggerController.score < 51)
            speed = 5;
        else if (TriggerController.score < 61)
            speed = 6;
        else if (TriggerController.score < 71)
            speed = 7;
        else if (TriggerController.score < 81)
            speed = 8;
        else if (TriggerController.score < 91)
            speed = 10;
        else if (TriggerController.score < 101)
            speed = 12;
        else
            speed = 15;
    }

    void RBVelocityHandler()
    {
        rb.velocity = transform.rotation == Quaternion.Euler(0, 0, 0) ? new Vector3(0, speed, 0) :
            transform.rotation == Quaternion.Euler(0, 0, 90) ? new Vector3(-speed, 0, 0) :
            transform.rotation == Quaternion.Euler(0, 0, -180) ? new Vector3(0, -speed, 0) :
            new Vector3(speed, 0, 0);
    }
}
