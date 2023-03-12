using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControls : MonoBehaviour
{
    [SerializeField]
    private Transform gunHead;

    [SerializeField]
    private Transform gunBody;

    [SerializeField] 
    private Transform spawnPoint;

    [SerializeField]
    private Rigidbody ballPrefab;

    [SerializeField]
    private float force;

    private Vector3 rot;
    private Vector3 baseRotation;

    [SerializeField]
    private int xRotationMin;

    [SerializeField]
    private int xRotationMax;

    [SerializeField]
    private int yRotationLimit;


    [SerializeField]
    private float sensitivity;

    void Start()
    {
        baseRotation = transform.rotation.eulerAngles;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {


        RotateCamera();

        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Mouse Clicked");
            var rb = Instantiate(ballPrefab, spawnPoint.position, gunHead.rotation);

            rb.AddForce(GetDirection() * force, ForceMode.Impulse);

            Destroy(rb.gameObject, 5f);

        }
    }

    private void RotateCamera()
    {
        rot.x += -Input.GetAxis("Mouse Y") * sensitivity;
        rot.y += Input.GetAxis("Mouse X") * sensitivity;
        rot.z = 0;

        rot.x = Mathf.Clamp(rot.x, xRotationMin, xRotationMax);

        float yRotation = rot.y;
        if (yRotation > 180f)
        {
            yRotation -= 360f;
        }
        yRotation = Mathf.Clamp(yRotation, -yRotationLimit, yRotationLimit);
        rot.y = yRotation;

        gunHead.transform.rotation = Quaternion.Euler(baseRotation + rot);
    }


    private Vector3 GetDirection()
    {
        return spawnPoint.transform.forward;
    }
}
