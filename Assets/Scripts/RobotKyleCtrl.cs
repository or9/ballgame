using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.PackageManager;
using System;

[RequireComponent(typeof(Rigidbody))]
public class RobotKyleCtrl : MonoBehaviour
{

    public float inputDelay = 0.1f;
    public float forwardVel = 12;
    public float rotateVel = 100;

    [SerializeField]
    private Rigidbody rBody;
    [SerializeField]
    private float forwardInput;
    [SerializeField]
    private float turnInput;
    [SerializeField]
    private float lookInput;

    Quaternion targetRotation;

    public Quaternion TargetRotation
    {
        get { return targetRotation; }
    }

    void Start()
    {
        targetRotation = transform.rotation;
        rBody = GetComponent<Rigidbody>();
        forwardInput = 0;
        turnInput = 0;
        //rBody.isKinematic = true;
        if (rBody.isKinematic)
        {
            Debug.LogError("The Rigidbody must NOT be kinematic");
        }
    }

    void GetInput()
    {
        forwardInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");
        lookInput = Input.GetAxis("Mouse X");
    }

    void Update()
    {
        // Happens once per frame
        GetInput();
        Turn();
        Look();
    }

    void FixedUpdate()
    {
        // Can happen multiple times per frame
        Run();
    }

    void Run()
    {
        if (Mathf.Abs(forwardInput) > inputDelay)
        {
            //float zAxis = transform.forward * forwardInput * forwardVel;
            float x = rBody.velocity.x;
            float y = rBody.velocity.y;
            float z = forwardInput * forwardVel;
            rBody.velocity = new Vector3(x, y, z);
        }
        else
        {
            //rBody.velocity = Vector3.zero;
            rBody.velocity = new Vector3(rBody.velocity.x, rBody.velocity.y, 0);
        }
    }

    void Turn()
    {
        if (Mathf.Abs(turnInput) > inputDelay)
        {
            float angle = rotateVel * turnInput * Time.deltaTime;
            Vector3 axis = Vector3.up;

            targetRotation *= Quaternion.AngleAxis(angle, axis);

            transform.rotation = targetRotation;
        }
        else
        {

        }
       
    }

    void Look()
    {
        //if (Mathf.Abs(lookInput) > inputDelay)
        //{
        //    float angle = rotateVel * lookInput * Time.deltaTime;
        //    Vector3 axis = Vector3.left;

        //    targetLook *= Quaternion.AngleAxis(angle, axis);

        //    transform.
        //}
    }
}
