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

    private Rigidbody bmrb;
    private Rigidbody mrb;

    [SerializeField]
    private int metCount;

    [SerializeField]
    private int howManyToKill;

    private int destroyed = 0;

    [SerializeField]
    private float secondsToSpawn;

    [SerializeField]
    private float speed;

    private float SecondsToSpawn;

    [SerializeField]
    private int whereToSpawn;

    [SerializeField]
    public static int bossLifes;

    private bool bossIsAlive = false;

    void Start()
    {
        SecondsToSpawn = secondsToSpawn;
        bossLifes = bossLifeCount;
    }

    void Update()
    {
        if (metCount > 0)
        {
            secondsToSpawn -= Time.deltaTime;

            if (secondsToSpawn < 0)
            {
                DoSpawn();
                secondsToSpawn = SecondsToSpawn;
            }
        }
    }

    private void DoSpawn()
    {
        if (howManyToKill <= destroyed)
        {
            if (!bossIsAlive)
            {
                Debug.Log("BOSSFIGHT");
                var meteorBOSS = Instantiate(bigMeteorPre, new Vector3(transform.position.x, 400, transform.position.z), Quaternion.identity);
                bossIsAlive = true;

                bmrb = meteorBOSS.GetComponent<Rigidbody>();

                bmrb.AddForce(-Vector3.up * speed, ForceMode.Acceleration);

                
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
