using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroytBall : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pin")) StartCoroutine(DestroyBall());
    }
    private IEnumerator DestroyBall()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
