using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public Transform explosionParticle;
    public Transform particleControl;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void Begin()
    {
        Transform explodeObject = Instantiate(explosionParticle, gameObject.transform.position,gameObject.transform.rotation);
        //explodeObject.SetParent();
        explodeObject.GetComponent<ParticleSystem>().Play();
        Destroy(gameObject);
       
        
       
    }
    // Update is called once per frame
    void Update()
    {
   
    }
}
