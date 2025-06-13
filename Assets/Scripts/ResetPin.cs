using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPin : MonoBehaviour
{
    [SerializeField] private float pinHideDelay = 2f;
    Vector3 initPos;
    Quaternion initQuaternion;
    void Start()
    {
        initPos = gameObject.transform.position;
        initQuaternion = gameObject.transform.rotation;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("넘어짐");
            HidePin();
        }
        else
        {
            // TODO : 2초 기다리고, 넘어져 있지 않으면 위치 기울기 초기 위치로 재설정.
            new WaitForSeconds(2f); // 여기도 코루틴으로 최적화 할 수 있나?
            if (!other.gameObject.CompareTag("Ground"))
            {
                ResetPinPositionAfterHit();
                Debug.Log("안 넘어졌으니 다시 원위치");
            }
        }

    }
    public IEnumerator HidePin()
    {
        Debug.Log("Hide Pin : 코루틴 입장.");
        yield return new WaitForSeconds(pinHideDelay);
        gameObject.SetActive(false);
        Debug.Log("Hide Pin : 코루틴 끝.");
    }
    public void ResetPinPositionAfterHit()
    {
        gameObject.transform.position = initPos;
        gameObject.transform.rotation = initQuaternion;
    }
}
