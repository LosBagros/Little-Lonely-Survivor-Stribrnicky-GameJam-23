using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    [SerializeField]
    private Transform playerRef;

    [SerializeField]
    private Transform meteorPre;

    private Rigidbody mrb;

    [SerializeField]
    private int metCount;

    private int maxMeteorCount;

    [SerializeField]
    private float secondsToSpawn;
    [SerializeField]
    private float speed;

    private float SecondsToSpawn;

    [SerializeField]
    private int whereToSpawn;
   

    void Start()
    {
        maxMeteorCount = metCount;
        SecondsToSpawn = secondsToSpawn;
        
    }

    void Update()
    {
        if (metCount > 0)
        {
            secondsToSpawn -= Time.deltaTime;
            Debug.Log(secondsToSpawn);
            if (secondsToSpawn < 0)
            {

                DoSpawn();
                Debug.Log("voeouvebavbaebvoabnev");
                secondsToSpawn = SecondsToSpawn;
            }
            

        }

    }

    private void DoSpawn()
    {



        Vector3 spawn = new Vector3(UnityEngine.Random.Range(transform.position.x + whereToSpawn, transform.position.x - whereToSpawn), transform.position.y, UnityEngine.Random.Range(transform.position.z + whereToSpawn, transform.position.z - whereToSpawn));

        var meteor = Instantiate(meteorPre, spawn, Quaternion.identity);
        
        mrb = meteor.GetComponent<Rigidbody>();

        
        
        mrb.AddForce(Vector3.down * speed, ForceMode.Acceleration);

        maxMeteorCount--;
    }
}
