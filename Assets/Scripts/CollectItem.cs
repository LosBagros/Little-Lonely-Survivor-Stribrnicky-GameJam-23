using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItem : MonoBehaviour
{
    public GameObject player;
    public float distanceThreshold = 1f;
    public static int SebraneKusy = 0;

    private void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < distanceThreshold)
        {
            Destroy(gameObject);
            SebraneKusy++;
        }
    }
}
