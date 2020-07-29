using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterUpright : MonoBehaviour
{
    new protected Rigidbody rigidbody;
    public bool keepUpright = true;
    public float uprightForce = 10;
    public float uprightOffset = 1.45f;
    public float additionalUpwardForce = 10;
    public float dampenAngularForce = 0;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.maxAngularVelocity = 40;
        /* CANNOT apply high angular forces unless the max angular velocity is increased */
    }

    void FixedUpdate()
    {
        if (keepUpright)
        {
            /*
             * Use two forces pulling up and down at the top and bottom of the object to keep it upright
             * this technique can be used for pulling an object to face any vector           
             */
            rigidbody.AddForceAtPosition(new Vector3(0, (uprightForce + additionalUpwardForce), 0), transform.position + transform.TransformPoint(new Vector3(0, uprightOffset, 0)), ForceMode.Force);
            rigidbody.AddForceAtPosition(new Vector3(0, -uprightForce, 0),
                transform.position + transform.TransformPoint(new Vector3(0, -uprightOffset, 0)), ForceMode.Force);
        }

        if (dampenAngularForce > 0)
        {
            rigidbody.angularVelocity *= (1 - Time.deltaTime * dampenAngularForce);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
