using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingLineBackGround : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Destroy(other.gameObject);
        }
    }
}
