using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    public Transform leftFoot;
    public Transform rightFoot;
    public Transform runTarget;

    Quaternion targetRotation;

    public Quaternion TargetRotation
    {
        get { return targetRotation; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Run()
    {

    }

    private void Turn()
    {

    }
}
