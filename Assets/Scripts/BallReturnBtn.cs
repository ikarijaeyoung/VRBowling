using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnBallButton : MonoBehaviour
{
    [SerializeField] GameObject _ballPrefab;
    [SerializeField] Transform _ballReturnPoint;
    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _audioClip;
    void Start()
    {
        if (_audioSource == null) Debug.Log("Audio Source가져오지 못함.");
    }
    public void ReturnBall()
    {
        if (_audioSource != null) _audioSource.PlayOneShot(_audioClip);
        else Debug.Log("Audio Source가 없음");
        Debug.Log("Audio 재생");
        
        Instantiate(_ballPrefab, _ballReturnPoint.position, _ballReturnPoint.rotation);
        Debug.Log("공 생성");
    }
}
