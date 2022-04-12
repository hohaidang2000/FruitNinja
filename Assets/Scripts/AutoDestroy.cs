using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    void Start()
    {
        //Start the coroutine we define below named ExampleCoroutine.
        StartCoroutine(End());
    }

    IEnumerator End()
    {
        //Print the time of when the function is first called.
        
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1);

        //After we have waited 5 seconds print the time again.
        Destroy(gameObject);
    }
}
