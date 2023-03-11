using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planeta : MonoBehaviour
{
    public float attractForce = 10f; // Síla pøitahování
    public float attractRange = 999f; // Vzdálenost, na které se zaène hráè pøitahovat

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                float distance = Vector3.Distance(transform.position, other.transform.position);
                if (distance <= attractRange)
                {
                    float force = attractForce * (attractRange - distance) / attractRange;
                    rb.AddForce((transform.position - other.transform.position).normalized * force);
                }
            }
        }
    }
}
