using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float moveSpeed = 5f;
    float horizontalInput;
    float verticalInput;

    float rotationSpeed = 130f;


    Rigidbody rb;
    Animator anim;

    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        rb.velocity = Vector2.zero;
        
    }

    
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");


        Vector3 movement = (horizontalInput * transform.right + verticalInput * transform.forward) * moveSpeed * Time.deltaTime;
        rb.MovePosition(transform.position + movement);

        if (horizontalInput != 0)
        {
            float rotationAmount = rotationSpeed * horizontalInput * Time.deltaTime;
            transform.Rotate(Vector3.up, rotationAmount);
        }


        anim.SetFloat("vertical", verticalInput);
        anim.SetFloat("horizontal", horizontalInput);

    }
}
