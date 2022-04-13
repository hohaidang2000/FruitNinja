using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    public float waitTime = 1f;
    void Start()
    {
        //Start the coroutine we define below named ExampleCoroutine.
        
    }

    void Update()
    {
        //Print the time of when the function is first called.
        waitTime -= Time.deltaTime;
        //yield on a new YieldInstruction that waits for 5 seconds.
        if(waitTime <= 0)
            Destroy(gameObject);
        //After we have waited 5 seconds print the time again.

    }
}
