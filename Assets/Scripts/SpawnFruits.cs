using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFruits : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bal;
    void Start()
    {
        bal.GetComponent<Rigidbody>().AddForce(Vector3.up * 80);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
