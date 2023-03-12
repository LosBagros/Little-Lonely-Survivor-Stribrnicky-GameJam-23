using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletParticles : MonoBehaviour
{
    private ParticleSystem ps;

    void Start()
    {
        //ps = GameObject.Find("ExplosionMAIN").GetComponent<ParticleSystem>();
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {

        
        Destroy(gameObject);
    }

    
}