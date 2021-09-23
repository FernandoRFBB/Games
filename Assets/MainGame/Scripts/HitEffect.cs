using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
        StartCoroutine(waiter());
    }

    IEnumerator waiter() {       
        yield return new WaitForSecondsRealtime(0.2f);
        Destroy(gameObject);
    }
}
