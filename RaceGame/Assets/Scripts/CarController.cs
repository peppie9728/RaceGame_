using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
        private float steerAngle;

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

    public void HandleSteering(float direction)
    {
        steerAngle = maxSteeringAngle * direction;
        frontLeftWheelCollider.steerAngle = steerAngle;
        frontRightWheelCollider.steerAngle = steerAngle;
    }

    public void HandleMotor(float throttle, bool isBreaking)
    {
        if (throttle != 0)
        {
            rearLeftWheelCollider.motorTorque = throttle * motorForce;
            rearRightWheelCollider.motorTorque = throttle * motorForce;
            
        }
        else
        {
            rearLeftWheelCollider.motorTorque = 0;
            rearRightWheelCollider.motorTorque = 0;
        }
        brakeForce = isBreaking ? 10000f : 0f;
        frontLeftWheelCollider.brakeTorque = brakeForce;
        frontRightWheelCollider.brakeTorque = brakeForce;
        rearLeftWheelCollider.brakeTorque = brakeForce;
        rearRightWheelCollider.brakeTorque = brakeForce;

        Debug.Log(rearLeftWheelCollider.motorTorque);
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
