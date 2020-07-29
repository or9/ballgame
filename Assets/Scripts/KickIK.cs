using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickIK : MonoBehaviour
{
    [SerializeField] Vector3 m_axis;
    [SerializeField] float m_rotationRate = 10f;

    private Quaternion rotation;

    // Start is called before the first frame update
    void Start()
    {
        rotation = transform.rotation;    
    }

    // Update is called once per frame
    void LateUpdate()
    {
        rotation *= Quaternion.Euler(m_axis * m_rotationRate * Time.deltaTime);
        transform.rotation = rotation;
    }
}
