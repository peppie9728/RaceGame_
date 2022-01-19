using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController_ : MonoBehaviour
{

    public float driftStrength;

    public CarController carController;

    private void Awake()
    {
        carController = GetComponent<CarController>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float rotation = Input.GetAxis("Horizontal");
        float driving = Input.GetAxis("Vertical");
        bool isBreaking = Input.GetKey(KeyCode.Space);


        carController.HandleSteering(rotation);
        carController.HandleMotor(driving, isBreaking);

    }
}
