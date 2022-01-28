using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
        private float steerAngle;
        public Rigidbody rb;

        public WheelCollider frontLeftWheelCollider;
        public WheelCollider frontRightWheelCollider;
        public WheelCollider rearLeftWheelCollider;
        public WheelCollider rearRightWheelCollider;
        public Transform frontLeftWheelTransform;
        public Transform frontRightWheelTransform;
        public Transform rearLeftWheelTransform;
        public Transform rearRightWheelTransform;

        public float maxSteeringAngle = 30f;
        public float motorForce = 50f;
        public float brakeForce = 0f;
        public float maxSpeed;
        private float speed;

    private void start ()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void HandleSteering(float direction)
    {
        steerAngle = maxSteeringAngle * direction;
        frontLeftWheelCollider.steerAngle = steerAngle;
        frontRightWheelCollider.steerAngle = steerAngle;
    }

    public void HandleMotor(float throttle, bool isBreaking)
    {
        speed = rb.velocity.sqrMagnitude;
        Debug.Log(speed);
        if (throttle != 0 && speed < maxSpeed)
        {
            rearLeftWheelCollider.motorTorque = throttle * motorForce;
            rearRightWheelCollider.motorTorque = throttle * motorForce;

        }
        else
        {
            rearLeftWheelCollider.motorTorque = 0;
            rearRightWheelCollider.motorTorque = 0;
        }
        brakeForce = isBreaking ? 25000f : 0f;
        rearLeftWheelCollider.brakeTorque = brakeForce;
        rearRightWheelCollider.brakeTorque = brakeForce;
    }

    public void FixedUpdate()
    {
        UpdateWheels();
    }
    
    private void UpdateWheels()
    {
        UpdateWheelPos(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateWheelPos(frontRightWheelCollider, frontRightWheelTransform);
        UpdateWheelPos(rearLeftWheelCollider, rearLeftWheelTransform);
        UpdateWheelPos(rearRightWheelCollider, rearRightWheelTransform);
    }

    private void UpdateWheelPos(WheelCollider wheelCollider, Transform transform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        transform.rotation = rot;
        transform.position = pos;
    }
}
