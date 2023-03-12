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

    [SerializeField]
    private int bossLifeCount;

    [SerializeField]
    private Transform bigMeteorPre;

    private Rigidbody mrb;

    [SerializeField]
    private int metCount;

    [SerializeField]
    private int howManyToKill;

    private int destroyed;

    [SerializeField]
    private float secondsToSpawn;
    [SerializeField]
    private float speed;

    private float SecondsToSpawn;

    [SerializeField]
    private int whereToSpawn;
   

    void Start()
    {
        
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

        if (howManyToKill <= destroyed)
        {
            Debug.Log("BOSSFIGHT");
            var meteorBOSS = Instantiate(meteorPre, new Vector3(transform.position.x, 400, transform.position.z), Quaternion.identity);



            if (bossLifeCount <= 0)
            {
                Destroy(meteorBOSS, 0.1f);
            }
        }
        else
        {
            Vector3 spawn = new Vector3(UnityEngine.Random.Range(transform.position.x + whereToSpawn, transform.position.x - whereToSpawn), transform.position.y, UnityEngine.Random.Range(transform.position.z + whereToSpawn, transform.position.z - whereToSpawn));

            var meteor = Instantiate(meteorPre, spawn, Quaternion.identity);

            mrb = meteor.GetComponent<Rigidbody>();

            mrb.AddForce(-Vector3.up * speed, ForceMode.Acceleration);

            destroyed++;
        }  
    }
}
