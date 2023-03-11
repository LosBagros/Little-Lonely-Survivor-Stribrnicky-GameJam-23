using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6.0f;
    public float rotateSpeed = 3.0f;
    public GameObject planet;

    private float MaxStamina = 100.0f;
    private float CurrentStamina = 100.0f;
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;
    private Rigidbody planetRigidbody;

    private Animator animator;



    void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        planetRigidbody = planet.GetComponent<Rigidbody>();
    }

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, 10.0f))
        {
            Vector3 surfaceNormal = hit.normal;
            transform.rotation = Quaternion.FromToRotation(transform.up, surfaceNormal) * transform.rotation;


        }

        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;

        // p�id�me gravitaci k pohybu hr��e
        moveDirection.y -= 9.8f * Time.deltaTime;

        controller.Move(moveDirection * Time.deltaTime);

        if (moveDirection != Vector3.zero)
        {
            //animator.SetBool("isWalking", true);

            Quaternion newRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * rotateSpeed);

            Vector3 groundNormal = transform.position - planet.transform.position;
            transform.rotation = Quaternion.FromToRotation(transform.up, groundNormal) * transform.rotation;
        }
        else
        {
            //animator.SetBool("isWalking", false);
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (horizontal != 0 || vertical != 0)
        {
            animator.SetBool("isWalking", true);
            if (Input.GetKey(KeyCode.LeftShift) && CurrentStamina > 10)
            {
                animator.SetBool("isRunning", true);
                speed = 8.0f;
                CurrentStamina -= 0.05f;
            }
            else
            {
                animator.SetBool("isRunning", false);
                speed = 6.0f;
                CurrentStamina += 0.5f;
            }
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        
    }

    void FixedUpdate()
    {
        planetRigidbody.AddTorque(transform.right * -Input.GetAxis("Horizontal") * rotateSpeed);
        planetRigidbody.AddTorque(transform.forward * Input.GetAxis("Vertical") * rotateSpeed);
    }

}
