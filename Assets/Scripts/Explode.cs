using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public Transform explosionParticle;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Begin()
    {
        Instantiate(explosionParticle);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
