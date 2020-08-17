using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{

    public Transform target;
    public float lookSmooth = 0.09f;
    public Vector3 offsetFromTarget = new Vector3(0, 6, -8);
    public float xTilt = 10;

    [SerializeField] Vector3 velocity = Vector3.zero;
    [SerializeField] Vector3 destination = Vector3.zero;
    [SerializeField] CharacterController charController;
    [SerializeField] float rotateVel = 0;

    // Start is called before the first frame update
    void Start()
    {
        SetCameraTarget(target);
    }

    void Update()
    {
        transform.LookAt(target);
        MoveToTarget();
    }

    void LateUpdate()
    {
        // Moving, Rotating, Looking, etc.
        //MoveToTarget();
        //LookAtTarget();
    }

    void MoveToTarget()
    {
        // Moving
        //destination = charController.TargetRotation * offsetFromTarget;
        //destination += target.position;
        //destination = target.position + offsetFromTarget;
        //transform.position = destination;
        Vector3 targetPosition = target.TransformPoint(offsetFromTarget);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, lookSmooth);
    }

    void LookAtTarget()
    {
        // Rotating
        float eulerYAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y,
            target.eulerAngles.y,
            ref rotateVel,
            lookSmooth);

        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, eulerYAngle, 0);
    }

    public void SetCameraTarget(Transform t)
    {
        target = t;

        if (target == null)
        {
            Debug.LogError("#SetCameraTarget camera needs a target");
            return;
        }

        charController = target.GetComponent<CharacterController>();

        if (charController == null)
        {
            Debug.LogError("#SetCameraTarget target needs a CharacterController");
            return;
        }


    }
}
