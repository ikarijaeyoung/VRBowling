using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPinBtn : MonoBehaviour
{
    [SerializeField] List<GameObject> bowlingPins;
    private Dictionary<GameObject, Vector3> initPinPositions = new Dictionary<GameObject, Vector3>();
    private Dictionary<GameObject, Quaternion> initPinRotations = new Dictionary<GameObject, Quaternion>();
    [SerializeField] Canvas canvas;
    void Start()
    {
        foreach (GameObject pin in bowlingPins)
        {
            if (pin != null)
            {
                initPinPositions[pin] = pin.transform.position;
                initPinRotations[pin] = pin.transform.rotation;
            }
            else
            {
                Debug.Log("Init error : Pin이 할당되지 않음.");
            }
        }
    }
    public void ResetBowlingPins()
    {
        foreach (GameObject pin in bowlingPins)
        {
            if (pin != null)
            {
                pin.transform.position = initPinPositions[pin];
                pin.transform.rotation = initPinRotations[pin];

                Rigidbody rb = pin.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.velocity = Vector3.zero;
                    rb.angularVelocity = Vector3.zero;
                }
            }
            else
            {
                Debug.Log("Reset error : Pin이 할당되지 않음.");
            }
        }
        Debug.Log("Bowling Pins Reset Success");
    }
}
