using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPin : MonoBehaviour
{
    [SerializeField] GameObject pin;
    [SerializeField] private float pinHideDelay = 2f;
    Vector3 initPos;
    Quaternion initQuaternion;
    Rigidbody rb;
    bool isFalled;
    void Start()
    {
        // pin = GetComponent<GameObject>(); 이거 왜 안 되지..
        rb = GetComponentInParent<Rigidbody>();
        initPos = pin.transform.position;
        initQuaternion = pin.transform.rotation;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball") || !isFalled) StartCoroutine(CheckAndResetPin());

        if (other.gameObject.CompareTag("Ground"))   // 넘어져서 트리거가 땅에 닿으면
        {
            StopCoroutine(CheckAndResetPin());
            isFalled = true;
            if (isFalled)
            {
                Debug.Log("넘어짐");
                StartCoroutine(HidePin());           // 비활성화(숨김)
            }
        }
        // else                                      // 넘어지지않고, 핀 끼리 부딪혀 애매한 위치일 경우
        // {
        //     StartCoroutine(CheckAndResetPin());   // 초기위치로 원위치.
        // }

    }
    public IEnumerator HidePin()
    {
        Debug.Log("Hide Pin : 코루틴 입장.");
        yield return new WaitForSeconds(pinHideDelay);
        pin.SetActive(false);
        Debug.Log("Hide Pin : 코루틴 끝.");
    }
    private IEnumerator CheckAndResetPin()
    {
        yield return new WaitForSeconds(4f);
        ResetPinPositionAfterHit();
        Debug.Log("안 넘어졌으니 다시 원위치");
    }
    public void ResetPinPositionAfterHit()
    {
        pin.transform.position = initPos;
        pin.transform.rotation = initQuaternion;
        rb.velocity = Vector3.zero;
        isFalled = false;
    }
}
