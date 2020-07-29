using UnityEngine;
using System.Collections;

//public interface PickupInterface
//{

//}

public class PickupRotator : MonoBehaviour
{

    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //other.gameObject.SetActive(false);
            //gameObject.SetActive(false);
            //other.gameObject.powerups += 1;
        }

        if (other.gameObject.CompareTag("Ball"))
        {
            //Vector3 movement = new Vector3();
            // maybe just rotate it more?
        }
    }
}