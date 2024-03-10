using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConTeen : MonoBehaviour
{
    float moveSpeed = 5f;
    float rotationSpeed = 130f;
    float jumpForce = 5f;

    float horizontalInput;
    float verticalInput;
    bool isRunning = false;
    bool isAttacking = false;
    bool isGrounded = false;


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

        // When I press shift, the character will run
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = 10f;
            isRunning = true;
        }
        else
        {
            isRunning = false;
            moveSpeed = 5f;
        }

        //if we press the left click, the character will attack
        if (Input.GetMouseButton(0))
        {
            isAttacking = true;
        }
        else
        {
            isAttacking = false;
        }

        //when we press space, the character will jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            anim.SetTrigger("jump");
            isGrounded = false;
        }


        anim.SetFloat("vertical", verticalInput);
        anim.SetFloat("horizontal", horizontalInput);
        anim.SetBool("isRunning", isRunning);
        anim.SetBool("isAttacking", isAttacking);
        anim.SetBool("isGrounded", isGrounded);

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
