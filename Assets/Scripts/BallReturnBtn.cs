using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnBallButton : MonoBehaviour
{
    [SerializeField] GameObject _ballPrefab;
    [SerializeField] Transform _ballReturnPoint;
    public void ReturnBall()
    {
        Instantiate(_ballPrefab, _ballReturnPoint.position, _ballReturnPoint.rotation);
    }
}
