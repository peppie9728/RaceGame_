using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController_ : MonoBehaviour
{
    public float maxSpeed = 10;
    public float turnSpeed = 50;
    public float accel = 2.5f;
    public float decel = 1;
    public float brake = 6;
    public Rigidbody rb;

    public void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void ControlCar(float throttle,float direction)
    {
       if (throttle > 0 && rb.velocity.magnitude < maxSpeed)
        {
            rb.AddForce(transform.forward * accel);
        }
       else if (throttle < 0 && rb.velocity.magnitude < 5)
        {
            rb.AddForce(transform.forward * -accel);
        }
    }
}