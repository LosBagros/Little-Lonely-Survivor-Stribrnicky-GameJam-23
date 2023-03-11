using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    // Start is called before the first frame update
    public float dayDurationInMinutes = 2.0f;

    private float anglePerSecond;

    void Start()
    {
        anglePerSecond = 360.0f / (dayDurationInMinutes * 60.0f);
    }

    void Update()
    {
        float angleThisFrame = anglePerSecond * Time.deltaTime;
        transform.Rotate(Vector3.right, angleThisFrame);
    }
}
